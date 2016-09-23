using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{
    public partial class MIS004 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                DbInit();
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

        }
        private void DbInit()
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                DataTable dt = new DataTable();
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(dt);
                PhoneGV.DataSource = dt;
                PhoneGV.DataBind();
            }
        }

        private string selectsql()
        {
            string strSearch;
            string strwhere = "";
            strSearch = (SearchTB.Text.Trim().Length > 0) ? SearchTB.Text.Trim() : "";

            //string sqlstr = @"SELECT * FROM [ViewACP] ";
            string sqlstr = @"
                                SELECT [phone] as '分機'
                                      ,[name] as '員工姓名'
                                      ,[empolyee_no] as '電話'
                                      ,[eng_name] as '英文姓名'
                                      ,[email] as 'Email'
                                      ,[skype_account] as 'Skype'
                                      ,[location] as '位置'
                                  FROM [dbo].[GGFPhoneNumber]
                            ";

            strwhere = " where [phone] like '%"+strSearch+ "%' or [name] like '%" + strSearch + "%' or [empolyee_no] like '%" + strSearch + "%' or [eng_name] like '%" + strSearch + "%' or [email] like '%" + strSearch + "%' or [skype_account] like '%" + strSearch + "%' or [location] like '%" + strSearch + "%'";
            sqlstr += strwhere ;
            return sqlstr;
        }
    }
}