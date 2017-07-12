using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales004 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
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
            //YearDDL.SelectedValue = "";
            //MonthDDL.SelectedValue = "";
            //AreaDDL.SelectedValue = "";
            StartTB.Text = "";
            EndTB.Text = "";
            for (int i = 0; i < DeptCBL.Items.Count; i++)
            {
                DeptCBL.Items[i].Selected = false;
            }
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
                if (DateTime.Parse( StartTB.Text)> DateTime.Parse(EndTB.Text))
                {
                    MessageLT.Text = @"                            
                                    <div class='form-group'>
                                        <h3 class='text-info text-center'>訂單日期錯誤 </ h3 >
                                    </div>";
                }
                else
                {
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
                        ReportDataSource source = new ReportDataSource("訂單資料", dt);
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
            }
            else
            {
                
            }

        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" 
                                        select * from (
                                            SELECT [部門]
                                                  ,[工廠代號]
                                                  ,[工廠名稱]
                                                  ,[訂單日期]
                                                  ,[代理商代號]
                                                  ,[代理商名稱]
                                                  ,[StyleNo]
                                                  ,[訂單號碼]
                                                  ,[公司別]
                                                  ,[客戶名稱]
                                                  ,[訂單月份]
                                                  ,[地區]
                                                  ,[訂單數量]
                                                  ,[ForMGF]
                                                  ,[工號]
                                                  ,[處理人員]
                                                  ,[未沖數量]
                                                  ,[預告單]
                                                  ,[客戶PO]
                                                  ,[出貨金額]
                                                  ,[訂單金額]
                                                  ,[訂單本幣金額]
                                                  ,[預估工繳]
                                                  ,[hts]
                                                  ,[單價]
                                                  ,[實際單價]
                                              FROM [dbo].[View訂單資料]
                                              union all
                                              SELECT [部門]
                                                  ,[工廠代號]
                                                  ,[工廠名稱]
                                                  ,[訂單日期]
                                                  ,[代理商代號]
                                                  ,[代理商名稱]
                                                  ,[StyleNo]
                                                  ,[訂單號碼]
                                                  ,[公司別]
                                                  ,[客戶名稱]
                                                  ,[訂單月份]
                                                  ,[地區]
                                                  ,[訂單數量]
                                                  ,[ForMGF]
                                                  ,[工號]
                                                  ,[處理人員]
                                                  ,[未沖數量]
                                                  ,[預告單]
                                                  ,[客戶PO]
                                                  ,[出貨金額]
                                                  ,[訂單金額]
                                                  ,[訂單本幣金額]
                                                  ,[預估工繳]
                                                  ,[hts]
                                                  ,[單價]
                                                  ,[實際單價]
                                              FROM [dbo].[View預告單]
                                            ) x 
                                        ");
            string strDept = "";
            strsql.AppendFormat(" where 訂單日期 between '{0}' and '{1}' ",(!String.IsNullOrEmpty(StartTB.Text))?StartTB.Text:"2000-01-01", (!String.IsNullOrEmpty(EndTB.Text)) ? EndTB.Text : "2999-01-01");
            for (int i = 0; i < DeptCBL.Items.Count; i++)
            {
                if (DeptCBL.Items[i].Selected)
                {
                    strDept += (string.IsNullOrEmpty(strDept) ? "'" + DeptCBL.Items[i].Value + "'" : ",'" + DeptCBL.Items[i].Value + "'");
                }
            }
            if(!string.IsNullOrEmpty(strDept))
                strsql.AppendFormat(" and 部門 in ( {0} ) " , strDept);
            return strsql;
        }
        
    }
}