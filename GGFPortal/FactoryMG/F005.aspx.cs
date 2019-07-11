using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GGFPortal.FactoryMG
{
    public partial class F005 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
            if (Convert.ToInt32(GridView1.PageIndex) != 0)
            {
                //==如果不加上這行IF判別式，假設當我們看第四頁時， 
                //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
                GridView1.PageIndex = 0;
            }
            DbInit();
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(GridView1.PageIndex) != 0)
            {
                //==如果不加上這行IF判別式，假設當我們看第四頁時， 
                //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
                GridView1.PageIndex = 0;
            }
            DbInit();
        }

        private string[] SplitEnter(string strPur)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = strPur.Split(stringSeparators, StringSplitOptions.None);
            return lines;
        }

        private void DbInit()
        {
            string sqlstr = selectsql();

            this.SqlDataSource1.SelectCommand = sqlstr;
            this.SqlDataSource1.DataBind();
            GridView1.DataBind();

        }

        private string selectsql()
        {
            string strwhere = "";
            strwhere = string.Format(@" and a.Date between '{0}' and '{1}' {2}"
                                        , (String.IsNullOrEmpty(StartDayTB.Text)) ? "19000101" : StartDayTB.Text
                                        , (String.IsNullOrEmpty(EndDayTB.Text)) ? "29991231" : EndDayTB.Text
                                        , (FlagDDL.SelectedValue=="%")?"":" and a.Flag = '"+FlagDDL.SelectedValue+"' "
                                        );
            
            string sqlstr = string.Format(@"
                                SELECT a.Date, b.Remark, CASE WHEN a.Flag = 1 THEN N'Thêm mới' WHEN a.Flag = 2 THEN N'Loại bỏ' ELSE '' END AS 狀態, a.CreateDate, a.ModifyDate 
                                FROM Productivity_Head AS a LEFT OUTER JOIN Mapping AS b ON a.Team = b.Data AND b.UsingDefine = 'Productivity'
                                where a.Flag>0  and Area ='VGG' {0}
                                order by Date
                            ", strwhere);


            return sqlstr;
        }

        private string SplitArray(string strtext, string strwhere, string strType)
        {
            string[] strtextarry = SplitEnter(strtext);
            if (strtextarry.Length > 1)
            {
                string strIn = " and " + strType + " in ( ";
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (i == 0)
                            strIn += " '" + strtextarry[i].Trim() + "' ";
                        else
                            strIn += " ,'" + strtextarry[i].Trim() + "' ";
                }
                strIn += " ) ";
                strwhere += strIn;
            }
            else
                strwhere += " and " + strType + " = '" + strtext + "' ";
            return strwhere;
        }

        private string GetDateString(string strtext)
        {
            string[] words = strtext.Split('/');
            string rstr = "";
            foreach (string s in words)
            {
                rstr = (s.Length < 2) ? rstr + "0" + s : rstr + s;
            }
            return rstr;
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString.ToString());
            SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(), Conn);
            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            //匯出Excel
            GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(ds.Tables["ACP"], @"xlsx");
        }

        
        
    }
}