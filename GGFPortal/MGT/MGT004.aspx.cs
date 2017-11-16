using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{

    public partial class MGT004 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            快遞時間TB.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            提單TB.Text = "";
            快遞時間TB.Text = "";
            //EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( 快遞時間TB.Text))
            {
                Session["提單日期"] = 快遞時間TB.Text;
                SelectPanel_ModalPopupExtender.Show();
            }
            else
                DbInit(0);
        }
        protected void DbInit(int iid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("明細",iid).ToString(), Conn);
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
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("單頭",iid).ToString(), Conn);
                    myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                ReportDataSource source2 = new ReportDataSource("MGT004_1", dt2);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }

        private StringBuilder selectsql(string strType,int iid)
        {
            
            StringBuilder strsql = new StringBuilder();
            if (strType== "明細")
            {
                strsql.Append(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.*
                                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id
                                    where b.IsDeleted = 0 ");
                if (iid > 0)
                    strsql.AppendFormat(@" and  b.id={0} ",iid);
                else
                    strsql.AppendFormat(@" and  UPPER(b.[提單號碼]) = '{0}' ", 提單TB.Text.Trim().ToUpper());
                //strsql.AppendFormat(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.*
                //                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id
                //                    where (UPPER(b.[提單號碼]) = '{0}' or b.id={1} ) and b.IsDeleted = 0  
                //                                    ", 提單TB.Text.Trim().ToUpper(),iid);
            }
            else
            {

                strsql.Append(@"SELECT top 1 * FROM [快遞單] 
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

    }
}