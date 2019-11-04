using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.ReferenceCode;
using System.Linq;

namespace GGFPortal.FactoryMG
{

    public partial class F010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        
        static string StrArea, StrPageName = "F010", StrProgram = "F010.aspx";
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
            //StartTB.Attributes["readonly"] = "readonly";
            //EndTB.Attributes["readonly"] = "readonly";
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
            //StartTB.Text = "";
            //EndTB.Text = "";
            StyleNoTB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
           MessageLT.Text = "";
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
                    string[] StyleArray = StyleNoTB.Text.Trim().Split(stringSeparators, StringSplitOptions.None);
                    #region 匯入
                    string[] parameters = StyleArray.Select((s, i) => "@StyleNo" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"SELECT  [Team]
                                                ,[款號]
                                                ,[今日產量]
                                            FROM [dbo].[View工時資料] where 地區 =@Area {1} {0}"
                                 , (!string.IsNullOrEmpty(StyleNoTB.Text)) ? string.Format(" and StyleNo in ( {0} ) ", string.Join(",", parameters)) : ""
                                 , string.Format(" and 工作時間 between '{0}' and '{1}'", DateRangeTB.Text.Substring(0, 8), DateRangeTB.Text.Substring(11)));
                    if (!string.IsNullOrEmpty(StyleNoTB.Text))
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
                ReportDataSource source = new ReportDataSource("產量統計", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                F_ErrorShow("沒有資料");
            }
        }

        //private StringBuilder selectsql()
        //{
            
        //    StringBuilder strsql = new StringBuilder(@" 
        //                                    SELECT  [Team]
        //                                        ,[款號]
        //                                        ,[今日產量]
        //                                    FROM [dbo].[View工時資料]
        //                                ");
        //    //string strDept = "";
        //    strsql.AppendFormat(" where 工作時間 between '{0}' and '{1}'  and [地區] ='VGG' ", (!String.IsNullOrEmpty(StartTB.Text))?StartTB.Text:"20000101", (!String.IsNullOrEmpty(EndTB.Text)) ? EndTB.Text : "29990101");
        //    //for (int i = 0; i < DeptCBL.Items.Count; i++)
        //    //{
        //    //    if (DeptCBL.Items[i].Selected)
        //    //    {
        //    //        strDept += (string.IsNullOrEmpty(strDept) ? "'" + DeptCBL.Items[i].Value + "'" : ",'" + DeptCBL.Items[i].Value + "'");
        //    //    }
        //    //}
        //    //if(!string.IsNullOrEmpty(strDept))
        //    //    strsql.AppendFormat(" and 部門 in ( {0} ) " , strDept);
        //    string 款號 = 多款號.字串多筆資料搜尋(StyleNoTB.Text).ToString();
        //    if (款號.Length > 0)
        //        strsql.AppendFormat(" and 款號 in {0} ",款號);
        //    return strsql;
        //}
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}