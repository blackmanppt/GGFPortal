using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{

    public partial class MGT009 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            StartDay.Text = "";
            EndDay.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (SearchCheck())
            {
                DbInit();
            }
            else
            {
                F_ErrorShow("請輸入搜尋資料");
            }
            
        }
        protected void DbInit(int iid=0)
        {

            DataTable dt = new DataTable(), dt2 = new DataTable();
            if (iid==0)
            {
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(iid).ToString(), Conn);
                    myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                if (dt2.Rows.Count > 1)
                {
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SelectPanel_ModalPopupExtender.Show();
                }
                else if (dt2.Rows.Count == 1)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    iid = int.Parse(dt2.Rows[0]["id"].ToString());
                }

            }
            if(iid>0)
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(iid).ToString(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
            if (dt.Rows.Count >0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("INVOICE", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else if(iid==0&& dt.Rows.Count==0)
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(int iid)
        {
            StringBuilder strsql = new StringBuilder();
            if (iid > 0)
            { 
                strsql.Append(@" SELECT b.提單號碼,b.提單日期,b.快遞廠商,b.送件地點     ,[寄件人]
                                          ,[寄件人工號]
                                          ,[寄件人分機]
                                          ,[寄件人部門]
                                          ,[收件人]
                                          ,[客戶名稱]
                                          ,[明細]
                                          ,[重量]
                                          ,[責任歸屬]
                                          ,[付款方式]
                                          ,備註
                                          ,送件部門
                                          ,原因歸屬
                                          ,[email]
                                          ,c.dept_name as 寄件人部門2
                                          ,[結案時間]
                                          ,[檢貨時間]
                                          ,case when a.[修改日期] is null then a.[建立日期] else a.[修改日期] end as 最後修改時間
										  ,[快遞數量],[快遞數量]
                                    FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id  left join bas_dept c on c.site='GGF' and a.寄件人部門=c.dept_no
                                    where    b.IsDeleted = 0  and a.IsDeleted = 0 and 
									快遞廠商 in ('DHL','FedEx')  ");
                strsql.AppendFormat(" and a.id  = {0} ", iid);
            }
            else
            {
                strsql.Append(@" SELECT *
                                    FROM  [快遞單] 
                                    where    IsDeleted = 0  and
									快遞廠商 in ('DHL','FedEx')  ");
                string strdate = "";
                strdate =string.Format("{0}{1}", (string.IsNullOrEmpty(StartDay.Text)) ? "0" : "1" , (string.IsNullOrEmpty(EndDay.Text)) ? "0" : "1");
                switch (strdate)
                {
                    case "11":
                        strsql.AppendFormat(" and 提單日期  between '{0}' and '{1}'", StartDay.Text,EndDay.Text);
                        break;
                    case "00":
                        break;
                    default:
                        strsql.AppendFormat(" and 提單日期  = '{0}{1}'", StartDay.Text.Trim(), EndDay.Text.Trim());
                        break;
                }
                if (!string.IsNullOrEmpty(提單TB.Text))
                {
                    strsql.AppendFormat(" and b.提單號碼 = {0}",提單TB.Text);
                }
            }
            
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = true;
            if(string.IsNullOrEmpty(StartDay.Text)&& string.IsNullOrEmpty(EndDay.Text) &&string.IsNullOrEmpty(提單TB.Text))
                bCheck = false;
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
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
            }
        }
    }
}