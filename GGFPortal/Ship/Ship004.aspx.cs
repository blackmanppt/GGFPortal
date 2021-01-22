using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Ship
{

    public partial class Ship004 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 字串處理 = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            ETDStartDay.Attributes["readonly"] = "readonly";
            ETDEndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {

            StartDay.Text = "";
            EndDay.Text = "";
            ETDStartDay.Text = "";
            ETDEndDay.Text = "";
            顯示直送CB.Checked = false;
            櫃號TB.Text = "";
            款號TB.Text = "";

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            GridDB();
        }
        protected void DbInit()
        {


            if (櫃號GV.Rows.Count > 0)
            {
                
                StringBuilder sb = new StringBuilder();
                CheckBox CHK = (CheckBox)(櫃號GV.HeaderRow.Cells[0].FindControl("全部搜尋CB"));
                if(!CHK.Checked)
                {
                    sb = selectsql("搜尋採購單資料");
                    List<string> L櫃號 = new List<string>();
                    for (int i = 0; i < 櫃號GV.Rows.Count; i++)
                    {
                        CheckBox CHK2 = (CheckBox)(櫃號GV.Rows[i].Cells[0].FindControl("搜尋CB"));
                        if (CHK2.Checked)
                        {
                            L櫃號.Add(string.IsNullOrEmpty( 櫃號GV.Rows[i].Cells[1].Text.Trim())?"": 櫃號GV.Rows[i].Cells[1].Text.Trim());
                        }
                    }
                    if (L櫃號.Count > 0)
                    {
                        sb.Append("and 櫃號 in (");
                        for (int i = 0; i < L櫃號.Count; i++)
                        {
                            sb.AppendFormat(" {0} '{1}' ",(i>0)?",":"", L櫃號[i]);
                        }
                        sb.Append(")");
                    }
                    else
                        sb = null;

                }
                else
                {
                    sb = selectsql("搜尋全部資料");
                }
                if(sb.Length>0)
                { 
                    DataTable dt = new DataTable();
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                        myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                    }
                    if (dt.Rows.Count > 0)
                    {
                        ReportViewer1.Visible = true;
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportDataSource source = new ReportDataSource("入庫櫃號", dt);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(source);
                        ReportViewer1.DataBind();
                        ReportViewer1.LocalReport.Refresh();
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
                }
            }

        }
        protected void GridDB()
        {


            if (搜尋確認())
            {
                搜尋BT.Visible = true;
                DataTable dt = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("搜尋櫃號").ToString(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                if (dt.Rows.Count > 0)
                {
                    櫃號GV.DataSource = dt;
                    櫃號GV.DataBind();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
            else
            {
                搜尋BT.Visible = false;
            }
        }

        private bool 搜尋確認()
        {
            bool bcheck=true;
            if (!string.IsNullOrEmpty(StartDay.Text) 
                && !string.IsNullOrEmpty(EndDay.Text) 
                && !string.IsNullOrEmpty(ETDStartDay.Text) 
                && !string.IsNullOrEmpty(ETDEndDay.Text) 
                && !string.IsNullOrEmpty(櫃號TB.Text)  )
            {
                bcheck = false;
            }

            return bcheck;
        }
        private bool GV確認()
        {
            bool bcheck = true;
            if (櫃號GV.Rows.Count>0)
            {
                bcheck = false;
            }
            return bcheck;
        }

        private StringBuilder selectsql(string sType)
        {
            
            StringBuilder strsql = new StringBuilder();
            switch (sType)
            {
                //搜尋櫃號
                case "搜尋櫃號":
                    strsql.Append(@" SELECT distinct
                                          [ETA]
                                          ,[ETD]
                                          ,[櫃號]
                                          
                                      FROM [dbo].[View入庫櫃號查詢] where 1 = 1");
                    //eta
                    if (!string.IsNullOrEmpty(StartDay.Text)|| !string.IsNullOrEmpty(EndDay.Text))
                        strsql.AppendFormat(" and [ETA]  between '{0}' and '{1}' ",
                            (!String.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text :  "2000-01-01" ,
                            (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "2099-12-31");
                    //etd
                    if (!string.IsNullOrEmpty(ETDStartDay.Text) || !string.IsNullOrEmpty(ETDEndDay.Text))
                        strsql.AppendFormat(" and [ETD]  between '{0}' and '{1}' ",
                            (!String.IsNullOrEmpty(ETDStartDay.Text)) ? ETDStartDay.Text : "2000-01-01",
                            (!String.IsNullOrEmpty(ETDEndDay.Text)) ? ETDEndDay.Text : "2099-12-31");
                    //櫃號
                    if(!string.IsNullOrEmpty(櫃號TB.Text))
                        strsql.AppendFormat(" and [櫃號]  in {0} ", 字串處理.字串多筆資料搜尋(櫃號TB.Text).ToString());
                    //款號
                    if (!string.IsNullOrEmpty(款號TB.Text))
                        strsql.AppendFormat(" and [款號]  in {0} ", 字串處理.字串多筆資料搜尋(款號TB.Text).ToString());
                    //排除直送資料
                    if (!顯示直送CB.Checked)
                        strsql.Append(" and [櫃號] not in  ('越南直送','宜蘭直送','廠商直送','染缸費')");
                    break;
                case "搜尋採購單資料":
                    strsql.Append(@" SELECT *
                                      FROM [dbo].[View入庫櫃號查詢] where 1 = 1");

                    if (!顯示直送CB.Checked)
                        strsql.Append(" and [櫃號] not in  ('越南直送','宜蘭直送','廠商直送','染缸費')");
                    break;
                case "搜尋全部資料":
                    strsql.Append(@" SELECT *
                                      FROM [dbo].[View入庫櫃號查詢] where 1 = 1");
                    //eta
                    if (!string.IsNullOrEmpty(StartDay.Text) || !string.IsNullOrEmpty(EndDay.Text))
                        strsql.AppendFormat(" and [ETA]  between '{0}' and '{1}' ",
                            (!String.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : "2000-01-01",
                            (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "2099-12-31");
                    //etd
                    if (!string.IsNullOrEmpty(ETDStartDay.Text) || !string.IsNullOrEmpty(ETDEndDay.Text))
                        strsql.AppendFormat(" and [ETD]  between '{0}' and '{1}' ",
                            (!String.IsNullOrEmpty(ETDStartDay.Text)) ? ETDStartDay.Text : "2000-01-01",
                            (!String.IsNullOrEmpty(ETDEndDay.Text)) ? ETDEndDay.Text : "2099-12-31");
                    //櫃號
                    if (!string.IsNullOrEmpty(櫃號TB.Text))
                        strsql.AppendFormat(" and [櫃號]  in {0} ", 字串處理.字串多筆資料搜尋(櫃號TB.Text).ToString());
                    //款號
                    if (!string.IsNullOrEmpty(款號TB.Text))
                        strsql.AppendFormat(" and [款號]  in {0} ", 字串處理.字串多筆資料搜尋(款號TB.Text).ToString());
                    //排除直送資料
                    if (!顯示直送CB.Checked)
                        strsql.Append(" and [櫃號] not in  ('越南直送','宜蘭直送','廠商直送','染缸費')");
                    break;
                default:
                    break;
            }


            return strsql;
        }


        protected void 搜尋BT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
    }
}