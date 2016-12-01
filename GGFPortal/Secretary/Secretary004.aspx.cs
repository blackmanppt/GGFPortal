using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Secretary
{
    public partial class Secretary004 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(IsPostBack)
            {
                //DbInit();
            }
            else
            {
                if (DateDDL.Items.Count == 0)
                {
                    //int iCountYear = DateTime.Now.Year - 2015;
                    DateTime dtNow = DateTime.Now;
                    //dtNow = DateTime.Parse("2020-12-01"); //測試用
                    int iCountMonth = (DateTime.Now.Year - 2015) * 12 + (DateTime.Now.Month - 12);


                    for (int i = 1; i < 9; i++)
                    {
                        if (i == 1)
                        {
                            DateDDL.Items.Add("");
                        }
                        DateDDL.Items.Add(DateTime.Now.AddMonths(i-2).ToString("yyyyMM"));
                    }
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        private void DbInit()
        {
            //if (SearchTB.Text.Trim().Length>0 && DateDDL.SelectedIndex>0)
            //{
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    string strSearch;
                    strSearch = (SearchTB.Text.Trim().Length > 0) ? "%" + SearchTB.Text.Trim().ToUpper() + "%" : "%";
                    DataTable dt = new DataTable();
                    string sqlstr = selectsql();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                    myAdapter.SelectCommand.Parameters.AddWithValue("Search", strSearch);
                    myAdapter.SelectCommand.Parameters.AddWithValue("Search1", strSearch);
                    myAdapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        PhoneGV.DataSource = dt;
                        PhoneGV.DataBind();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
                    }

                }
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入搜尋資料與月份');</script>");
            //}
            
        }

        private string selectsql()
        {
            string strSearch;
            string strwhere = "";
            strSearch = (SearchTB.Text.Trim().Length > 0) ? SearchTB.Text.Trim() : "";

            //string sqlstr = @"SELECT * FROM [ViewACP] ";
            string sqlstr = @"
                                select * from (
                                SELECT 
                                訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 
                                訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, ForMGF, salesman, employee_name , (select distinct top 1 cus_name from   bas_cus_master where 客戶名稱=cus_id ) as cus_name
                                FROM ViewOrderQty 
                                UNION ALL 
                                SELECT 
                                訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 
                                工廠代號, 工廠名稱, 地區, 訂單數量, ForMGF, salesman, employee_name , (select distinct top 1 cus_name from   bas_cus_master where 客戶名稱=cus_id ) as cus_name
                                FROM ViewPreOrderQty ) a
                            ";

            strwhere = string.Format(" where (ForMGF like @Search or 客戶名稱 like @Search1) and 訂單月份 like '{0}'",  DateDDL.SelectedValue);
            sqlstr += strwhere ;
            return sqlstr;
        }

        

        
    }
}