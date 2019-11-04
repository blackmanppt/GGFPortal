using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace GGFPortal.FactoryMG
{

    public partial class F011 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string StrArea, StrPageName = "F011", StrProgram = "F011.aspx";
        字串處理 切字串 = new 字串處理();
        static 多語 lang = new 多語();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                //清空Error資料
                Session.Remove("Error");
                if (Session["Area"].ToString() == "")
                {
                    Response.Redirect("Findex.aspx");
                }
                StrArea = Session["Area"].ToString();
                //網頁標題
                if (StrArea == "TW")
                {
                    AreaDDL.Visible = true;
                    AreaLB.Visible = true;
                }
                else
                {
                    AreaDDL.Visible = false;
                    AreaLB.Visible = false;
                }
                lang.gg.Clear();

                lang.讀取多語資料("Program", StrPageName);
            }
            catch (Exception)
            {
                Session["Error"] = "timeout";
                Response.Redirect("Findex.aspx");
            }
            #region 網頁Layout基本參數
            //網頁標題

            BrandLB.Text = lang.翻譯("Program", StrPageName, StrArea);
            Page.Title = lang.翻譯("Program", StrPageName, StrArea);
            DateRangeLB.Text = lang.翻譯("Program", "DateRange", StrArea);
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            StyleTB.Text = "";
            //StartDay.Text = "";
            //EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = Conn.CreateCommand();
                SqlTransaction transaction1;
                Conn.Open();
                transaction1 = Conn.BeginTransaction("createExcelImport");
                try
                {
                    command1.Connection = Conn;
                    command1.Transaction = transaction1;
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] StyleArray = StyleTB.Text.Trim().Split(stringSeparators, StringSplitOptions.None);
                    #region 匯入
                    string[] parameters = StyleArray.Select((s, i) => "@StyleNo" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"SELECT a.*,(a.[今日產量]/12)*a.[工繳收入] as 今日工繳收入,b.estimate_ie as 訂單工繳
                                                        FROM [dbo].[View工時資料]  a 
                                                        LEFT JOIN ordc_bah1 b on a.款號=b.cus_item_no and b.chn_turn_out='N'  where 地區 =@Area {1} {0}"
                                 , (!string.IsNullOrEmpty(StyleTB.Text)) ? string.Format(" and StyleNo in ( {0} ) ", string.Join(",", parameters)) : ""
                                 , string.Format(" and 工作時間 between '{0}' and '{1}'", DateRangeTB.Text.Substring(0, 8), DateRangeTB.Text.Substring(11)));
                    if (!string.IsNullOrEmpty(StyleTB.Text))
                        for (int i = 0; i < StyleArray.Length; i++)
                            command1.Parameters.AddWithValue(parameters[i], StyleArray[i]);
                    command1.Parameters.Add("@Area", SqlDbType.NVarChar).Value = (StrArea == "TW") ? AreaDDL.SelectedValue : StrArea;
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader();
                    dt.Load(dr);

                    #endregion
                }
                catch (Exception ex)
                {
                    //Log.ErrorLog(ex, "上傳失敗", StrProgram);
                    //transaction1.Rollback();
                }
                finally
                {
                    Conn.Close();
                    transaction1.Dispose();
                }
            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("VNReport", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}