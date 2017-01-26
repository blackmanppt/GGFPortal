using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales001 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";

            if (IsPostBack)
            {
                if (StartDay.Text.Length > 0)
                {
                    EndDay_CalendarExtender.StartDate = Convert.ToDateTime(StartDay.Text.Substring(0,4) + "-" + StartDay.Text.Substring(4, 2) + "-" + StartDay.Text.Substring(6, 2));
                }
                if (EndDay.Text.Length > 0)
                {
                    StartDay_CalendarExtender.EndDate = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "-" + EndDay.Text.Substring(4, 2) + "-" + EndDay.Text.Substring(6, 2));
                }
            }
            //if (!IsPostBack)
            //{
            //    this.ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportViewer1.LocalReport.EnableExternalImages = true;

            //    //指定 ReportViewer 的報表路徑
            //    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("\\ReportSource\\ReportSales001.rdlc");

            //    //宣告要傳入報表的參數 p_ImgPath，並指定我的照片路徑是存放於 D:\\upload\\duck.jpg
            //    Microsoft.Reporting.WebForms.ReportParameter p_ImgPath = new Microsoft.Reporting.WebForms.ReportParameter("ImgPath", "W:\\26008-V\\1030511512140918173545.jpg");

            //    //把參數傳給報表
            //    ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { p_ImgPath });

            //    //更新頁面上的報表
            //    this.ReportViewer1.LocalReport.Refresh();
            //}
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("Sales001"))
                    Ds.Tables.Remove("Sales001");
                string sqlstr = selectsql(), strStartDay,strEndDay,strVendor,strFactory;
                strStartDay = (string.IsNullOrEmpty(StartDay.Text)) ? "00000000" : StartDay.Text;
                strEndDay = (string.IsNullOrEmpty(EndDay.Text)) ? "99999999" : EndDay.Text;
                strVendor = (string.IsNullOrEmpty(VendorTB.Text)) ? "%" : VendorTB.Text;
                strFactory = (string.IsNullOrEmpty(FactoryDDL.Text)) ? "%" : FactoryDDL.Text;
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.SelectCommand.Parameters.AddWithValue("StartDay", strStartDay);
                myAdapter.SelectCommand.Parameters.AddWithValue("EndDay", strEndDay);
                myAdapter.SelectCommand.Parameters.AddWithValue("客戶名稱", strVendor);
                myAdapter.SelectCommand.Parameters.AddWithValue("工廠名稱", strFactory);
                myAdapter.Fill(Ds, "Sales001");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (Ds.Tables["Sales001"].Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                //ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("Sales001", Ds.Tables["Sales001"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
                //ACPGV.DataSource = Ds.Tables["ACP"];
                //ACPGV.DataBind();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }
        private void DbInit()
        {
            string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            //ACPGV.DataBind();
        }
        private string selectsql()
        {
            string sqlstr = @"
                                select * from (
                                SELECT [訂單號碼]
                                      ,[代理商代號]
                                      ,[代理商名稱]
                                      ,[客戶名稱]
                                      ,[訂單日期]
                                      ,[訂單月份]
                                      ,[工廠代號]
                                      ,[工廠名稱]
                                      ,[地區]
                                      ,[訂單數量]
                                      ,[ForMGF]
                                      ,[salesman]
                                      ,[employee_name]
                                      ,case when [未沖數量]=0 then '無' else '有' end  as 未沖數量
	                                  , (select distinct top 1 cus_name from   bas_cus_master where 客戶名稱=cus_id ) as cus_name
                                        ,[StyleNo]
                                    ,'訂單' as 單別
                                  FROM [dbo].[ViewOrderQty]
                                  union all
                                SELECT [訂單號碼]
                                      ,[代理商代號]
                                      ,[代理商名稱]
                                      ,[客戶名稱]
                                      ,[訂單日期]
                                      ,[訂單月份]
                                      ,[工廠代號]
                                      ,[工廠名稱]
                                      ,[地區]
                                      ,[訂單數量]
                                      ,[ForMGF]
                                      ,[salesman]
                                      ,[employee_name]
	                                  ,'無' as 未沖數量
	                                  , (select distinct top 1 cus_name from   bas_cus_master where 客戶名稱=cus_id ) as cus_name
                                        ,[StyleNo]
                                        ,'預告單' as 單別
                                  FROM [dbo].[ViewPreOrderQty]
                                ) a
                                where 訂單日期  between @StartDay and @EndDay and 客戶名稱 like @客戶名稱 and 工廠名稱 like @工廠名稱
                            ";
            return sqlstr;
        }
        protected void SearchVendorID2_Click(object sender, EventArgs e)
        {
            MessageLB.Text = "";
            if (VendorGV.Rows.Count > 0)
            {
                VendorGV.DataSource = null;
                VendorGV.DataBind();
                //UpdatePanel1.Update();

            }
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {

                if (SearchVendorID2TB.Text.Length > 0)
                {
                    string strsql;
                    strsql = string.Format("select distinct cus_id,cus_name_brief,cus_name from view_bas_cus_master where cus_id like '%{0}%' or cus_name_brief like '%{0}%' or cus_name  like '%{0}%' ", SearchVendorID2TB.Text.ToUpper() );
                    DataTable DT = new DataTable();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(strsql , Conn);
                    myAdapter.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        VendorGV.DataSource = DT;
                        VendorGV.DataBind();
                    }
                    else
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
                        MessageLB.Text = "搜尋不到資料";
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入資料');</script>");
                    MessageLB.Text = "請輸入資料";
                }
            }
            ModalPopupExtender1.Show();
        }



        protected void SearchVendorIDBT_Click(object sender, ImageClickEventArgs e)
        {
            
            //Label4.Text = "客戶名稱或代號：";
            SearchVendorID2TB.Text = "";
            if (VendorGV.Rows.Count>0)
            {

                MessageLB.Text = "";
                VendorGV.DataSource = null;
                VendorGV.DataBind();
                UpdatePanel1.Update();
                
            }
            UpdatePanel3.Update();
            ModalPopupExtender1.Show();
        }

        protected void VendorGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ModalPopupExtender1.Hide();
            //將Ajax的資料丟到其他欄位
            GridViewRow row = VendorGV.Rows[e.NewSelectedIndex];
            VendorTB.Text = row.Cells[1].Text;
            UpdatePanel2.Update();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //AutoComplete
        public static List<string> SearchVendorID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct cus_id,cus_name_brief,cus_name from view_bas_cus_master where (cus_id like '%'+  @SearchText + '%' or cus_name_brief like '%'+@SearchText+'%'  or cus_name like '%'+@SearchText+'%') ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> VendorID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["cus_id"].ToString(), sdr["cus_name_brief"].ToString());
                            VendorID.Add(item);
                        }
                    }
                    conn.Close();
                    return VendorID;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            StartDay.Text = "";
            EndDay.Text = "";
        }
    }
}