using GGFPortal.ReferenceCode;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using GGFPortal.DataSetSource;
using System.Web.UI.WebControls;

namespace GGFPortal.FactoryMG
{
    public partial class F005 : System.Web.UI.Page
    {
        //字串處理 切字串 = new 字串處理();
        //static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        //SysLog Log = new SysLog();
        static string StrPageName = "F005";
        static string StrArea;
        static 多語 lang = new 多語();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                lang.gg.Clear();
                if (Session["Area"].ToString() == "")
                {
                    Response.Redirect("Findex.aspx");
                }
                lang.讀取多語資料("Program", "F005");

                StrArea = Session["Area"].ToString();
                #region 網頁Layout基本參數
                //網頁標題
                if (StrArea == "TW")
                {
                    AreaDDL.Visible = true;
                    AreaLB.Visible = true;
                }
                else
                {
                    AreaDDL.Visible = false;
                    AreaLB.Visible = false;
                }
                if (FlagDDL.Items.Count == 0)
                {
                    var statusData = lang.gg.FindAll(p => p.資料代號 == "Status");
                    statusData.Sort(delegate (GGF多語對照表 x, GGF多語對照表 y) {
                        if (x.說明 == null && y.說明 == null) return 0;
                        else if (x.說明 == null) return -1;
                        else if (y.說明 == null) return 1;
                        else return x.說明.CompareTo(y.說明);
                    });
                    foreach (var item in statusData)
                    {
                        switch (StrArea)
                        {
                            case "GAMA":
                                FlagDDL.Items.Add(new ListItem(item.英文, item.說明));
                                break;
                            case "VGG":
                                FlagDDL.Items.Add(new ListItem(item.越文, item.說明));
                                break;
                            default:
                                FlagDDL.Items.Add(new ListItem(item.中文, item.說明));
                                break;
                        }

                    }
                    statusData.Clear();
                }
                
                BrandLB.Text = lang.翻譯("Program", StrPageName, StrArea); 
                Page.Title = lang.翻譯("Program", StrPageName, StrArea); 
                #endregion
            }
            catch (Exception)
            {
                Response.Redirect("Findex.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Convert.ToInt32(GridView1.PageIndex) != 0)
            //{
            //    //==如果不加上這行IF判別式，假設當我們看第四頁時， 
            //    //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
            //    GridView1.PageIndex = 0;
            //}
            if(Page.IsPostBack)
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
            //string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString.ToString());
            SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(), Conn);
            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            GridView1.DataSource = ds.Tables["ACP"];
            GridView1.DataBind();

        }

        private string selectsql()
        {
            string strwhere = "",StrColumn="";
            switch (StrArea)
            {
                case "VGG":
                    StrColumn = "CASE WHEN a.Flag = 1 THEN N'Thêm mới' WHEN a.Flag = 2 THEN N'Loại bỏ' ELSE '' END AS ";
                    break;
                case "GAMA":
                    StrColumn = "CASE WHEN a.Flag = 1 THEN N'New' WHEN a.Flag = 2 THEN N'Deleted' ELSE '' END AS "; 
                    break;
                case "TW":
                    StrColumn = "CASE WHEN a.Flag = 1 THEN N'新增' WHEN a.Flag = 2 THEN N'已刪除' ELSE '' END AS ";
                    break;
                default:
                    break;
            }
            strwhere = string.Format(@" and a.Date between '{0}' and '{1}' {2}"
                                        , DateRangeTB.Text.Substring(0, 8)
                                        , DateRangeTB.Text.Substring(11)
                                        , (FlagDDL.SelectedValue=="0")?"":" and a.Flag = '"+FlagDDL.SelectedValue+"' "
                                        );
            
            string sqlstr = string.Format(@"
                                SELECT a.Date, b.Remark, {2} 'Status',CONVERT(varchar(10), a.CreateDate,111) as 'Create Date', CONVERT(varchar(10), a.ModifyDate ,111) as 'Modify Date'
                                FROM Productivity_Head AS a LEFT OUTER JOIN Mapping AS b ON a.Team = b.Data AND b.UsingDefine = 'Productivity'
                                where a.Flag>0  and Area ='{1}' {0}
                                order by Date
                            ", strwhere, (StrArea=="TW")?AreaDDL.SelectedValue:StrArea, StrColumn);


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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DbInit();
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