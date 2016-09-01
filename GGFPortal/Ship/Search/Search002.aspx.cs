using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace GGFPortal.Ship.Search
{
    public partial class Search002 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridView1.PageIndex) != 0)
            {
                //==如果不加上這行IF判別式，假設當我們看第四頁時， 
                //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
                GridView1.PageIndex = 0;
            }
            if (IsPostBack)
            {
                DbInit();
            }
            
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
            string strPur, strAcp, strStyleno;
            string strwhere = "";
            strPur = (PurSearchTB.Text.Trim().Length > 0) ? PurSearchTB.Text.Trim() : "";
            strAcp = (ACPTB.Text.Trim().Length > 0) ? ACPTB.Text.Trim() : "";
            strStyleno = (StyleNoSeachTB.Text.Trim().Length > 0) ? StyleNoSeachTB.Text.Trim() : "";

            //string sqlstr = @"SELECT * FROM [ViewACP] ";
            string sqlstr = @"
                            select style_no, acp_qty AS 數量, unit_price AS 單價, detail_amt AS 明細金額, CASE WHEN pur_nbr IS NULL 
                            THEN '' ELSE pur_nbr END AS pur_nbr, acp_nbr, acp_seq, item_no AS 料品代號, offset_currency AS 立帳幣別 ,unit
                            FROM dbo.acp_trnd WHERE      ( ( (kind = 'AP18') AND (transaction_class = 15)) OR ((kind = 'AP01') AND (transaction_class = 01)))
                            ";

            if (strPur.Length > 0 || strAcp.Length > 0 || strStyleno.Length > 0)
            {
                ReferenceCode.StringConvert SplitString = new ReferenceCode.StringConvert();
                if (strPur.Length > 0)
                    strwhere = SplitString.SplitArray(strPur, strwhere, "pur_nbr");
                if (strAcp.Length > 0)
                    strwhere = SplitString.SplitArray(strAcp, strwhere, "acp_nbr");
                if (strStyleno.Length > 0)
                    strwhere = SplitString.SplitArray(strStyleno, strwhere, "style_no");
            }
            sqlstr = sqlstr + strwhere + " ORDER BY [acp_nbr] ";
            return sqlstr;
        }



        protected void Export_Click(object sender, EventArgs e)
        {
            //check資料
            if (String.IsNullOrEmpty(PurSearchTB.Text) && String.IsNullOrEmpty(ACPTB.Text) && String.IsNullOrEmpty(StyleNoSeachTB.Text))
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Please enter Search Data');</script>");

            }
            else
            {
                
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString1"].ConnectionString.ToString());
                //----(2). 執行SQL指令（Select陳述句）----
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(), Conn);
                DataSet ds = new DataSet();

                myAdapter.Fill(ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                //匯出Excel
                GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
                xx.ExcelWithNPOI(ds.Tables["ACP"], @"xlsx");
            }

        }


        
    }
}