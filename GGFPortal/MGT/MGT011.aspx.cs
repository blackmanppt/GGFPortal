using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{
    public partial class MGT011 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string strConnectEIPString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["EIPConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "快遞核准單";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DateRangeTB.Attributes["readonly"] = "readonly";
        }
        protected void DbInit(int iid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("明細", iid).ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }
            if (dt.Rows.Count > 0)
            {

                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("MGT004", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                DataTable dt2 = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("單頭", iid).ToString(), Conn);
                    myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                ReportDataSource source2 = new ReportDataSource("MGT004_1", dt2);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(string strType, int iid)
        {

            StringBuilder strsql = new StringBuilder();
            if (strType == "明細")
            {
                strsql.Append(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.寄件人,a.寄件人分機,a.重量,a.明細,a.責任歸屬,a.付款方式,a.IsDeleted,c.Dept as'寄件人部門',a.客戶名稱
                                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id left join [192.168.0.116].[EIP].[dbo].[Dept] c on a.寄件人部門 =(c.Dept_ID COLLATE Chinese_Taiwan_Stroke_CI_AS )
                                    where b.IsDeleted = 0  ");
                if (iid > 0)
                    strsql.AppendFormat(@" and  b.id={0} ", iid);
                else
                    strsql.AppendFormat(@" and  UPPER(b.[提單號碼]) = '{0}' ", 提單TB.Text.Trim().ToUpper());
                if(string.IsNullOrEmpty(工號TB.Text))
                { 
                    strsql.AppendFormat(@" and  Dept_ID = '{0}' ", Session["快遞部門"].ToString());
                }
                else
                {
                    using (SqlConnection conn1 = new SqlConnection(strConnectEIPString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = conn1;
                        command.CommandText = @"SELECT  distinct top 1 Dept_ID from [dbo].[Members]   where Account_ID = @Account_ID";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@Account_ID", SqlDbType.NVarChar).Value = 工號TB.Text;
                        conn1.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                //DataReader讀出欄位內資料的方式，通常也可寫Reader[0]、[1]...[N]代表第一個欄位到N個欄位。
                                
                                strsql.AppendFormat(@" and  Dept_ID = '{0}' ", reader.GetString(0));
                            }
                        }
                        reader.Close();
                    }
                }
                //strsql.AppendFormat(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.*
                //                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id
                //                    where (UPPER(b.[提單號碼]) = '{0}' or b.id={1} ) and b.IsDeleted = 0  
                //                                    ", 提單TB.Text.Trim().ToUpper(),iid);
            }
            else
            {

                strsql.Append(@"SELECT top 1  id,提單號碼,提單日期,快遞廠商,快遞單檔案,送件地點+地點備註 as '送件地點',IsDeleted,修改日期,建立日期 FROM [快遞單] 
                                    where  IsDeleted = 0  ");
                if (iid > 0)
                    strsql.AppendFormat(@" and  id={0} ", iid);
                else
                    strsql.AppendFormat(@" and  UPPER([提單號碼]) = '{0}' ", 提單TB.Text.Trim().ToUpper());
                //strsql.AppendFormat(@"( UPPER([提單號碼]) = '{0}' or id={1} and IsDeleted = 0  
                //                    order by 建立日期  desc ", 提單TB.Text.Trim().ToUpper(),iid);
            }
            
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    bCheck = true;
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iid = 0;
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                int.TryParse(strid, out iid);
                if (iid > 0)
                {
                    DbInit(iid);
                }
                Session["提單日期"] = null;
            }
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            Session.Remove("提單日期");
            Session.Remove("快遞部門");
            if (!string.IsNullOrEmpty(DateRangeTB.Text))
            {
                Session["提單日期"] = DateRangeTB.Text;
                Session["快遞部門"] = 寄件人DDL.SelectedValue;
                SelectPanel_ModalPopupExtender.Show();
            }
            else
                DbInit(0);
        }
        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            提單TB.Text = "";
            DateRangeTB.Text = "";
            //EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
        }
    }
}