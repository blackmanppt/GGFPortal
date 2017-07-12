using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.ReferenceCode;

namespace GGFPortal.VN
{

    public partial class VN010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 多款號 = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartTB.Attributes["readonly"] = "readonly";
            EndTB.Attributes["readonly"] = "readonly";
            //if (YearDDL.Items.Count == 0)
            //{
            //    //int iCountYear = DateTime.Now.Year - 2015;
            //    DateTime dtNow = DateTime.Now;
            //    //dtNow = DateTime.Parse("2020-12-01"); //測試用
            //    int iCountMonth = (DateTime.Now.Year - 2015);


            //    for (int i = 1; i < iCountMonth; i++)
            //    {
            //        if (i == 1)
            //        {
            //            YearDDL.Items.Add("");
            //        }
            //        YearDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyy"));
            //    }
            //}
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            StartTB.Text = "";
            EndTB.Text = "";
            StyleNoTB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
           MessageLT.Text = "";
           DbInit();
        }
        protected void DbInit()
        {
            if (!String.IsNullOrEmpty(StartTB.Text) && !String.IsNullOrEmpty(EndTB.Text))
            {
                //if (DateTime.Parse( StartTB.Text)> DateTime.Parse(EndTB.Text))
                //{
                //    MessageLT.Text = @"                            
                //                    <div class='form-group'>
                //                        <h3 class='text-info text-center'>訂單日期錯誤 </ h3 >
                //                    </div>";
                //}
                //else
                //{
                    DataTable dt = new DataTable();
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                        myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                    }
                    if (dt.Rows.Count > 0)
                    {
                        ReportViewer1.Visible = true;
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportDataSource source = new ReportDataSource("產量統計", dt);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(source);
                        ReportViewer1.DataBind();
                        ReportViewer1.LocalReport.Refresh();
                    }
                    else
                    {
                        MessageLT.Text = @"                            
                                    <div class='form-group'>
                                        <h3 class='text-info text-center'>沒有資料 </ h3 >
                                    </div>";
                    }
                }
            //}
            //else
            //{
                
            //}

        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" 
                                            SELECT  [Team]
                                                ,[款號]
                                                ,[今日產量]
                                            FROM [dbo].[View工時資料]
                                        ");
            //string strDept = "";
            strsql.AppendFormat(" where 工作時間 between '{0}' and '{1}' ",(!String.IsNullOrEmpty(StartTB.Text))?StartTB.Text:"20000101", (!String.IsNullOrEmpty(EndTB.Text)) ? EndTB.Text : "29990101");
            //for (int i = 0; i < DeptCBL.Items.Count; i++)
            //{
            //    if (DeptCBL.Items[i].Selected)
            //    {
            //        strDept += (string.IsNullOrEmpty(strDept) ? "'" + DeptCBL.Items[i].Value + "'" : ",'" + DeptCBL.Items[i].Value + "'");
            //    }
            //}
            //if(!string.IsNullOrEmpty(strDept))
            //    strsql.AppendFormat(" and 部門 in ( {0} ) " , strDept);
            string 款號 = 多款號.字串多筆資料搜尋(StyleNoTB.Text).ToString();
            if (款號.Length > 0)
                strsql.AppendFormat(" and 款號 in {0} ",款號);
            return strsql;
        }
        
    }
}