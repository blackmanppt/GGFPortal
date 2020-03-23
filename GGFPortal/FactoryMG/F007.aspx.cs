using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using GGFPortal.ReferenceCode;
using System.Text;
using System.Linq;
using Microsoft.Reporting.WebForms;

namespace GGFPortal.FactoryMG
{
    public partial class F007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string StrArea, StrPageName = "F007";
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
            Label3.Text = lang.翻譯("Program", "DateRange", StrArea);
            //StrError名稱 = "";
            //StrProgram = "TempCode.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (IsPostBack)
            //    DbInit();
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            DbInit();
        }
        
        private void DbInit()
        {
            DataTable dt = new DataTable(), dt2 = new DataTable();
            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
            //    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
            #region query 使用 In
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("createExcelImport");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] StyleArray = StyleNoSearchMutiTB.Text.Trim().Split(stringSeparators, StringSplitOptions.None);
                    #region 匯入
                    string[] parameters = StyleArray.Select((s, i) => "@StyleNo" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"select Team,sum(b.Person* b.Time) as SumTime from  Productivity_Head a left join Productivity_Line b on a.uid=b.uid
                                                            where Flag=1 and Area=@Area {0} {1} {2}
                                                            group by Team "
                                 ,(!string.IsNullOrEmpty(StyleNoSearchMutiTB.Text))? string.Format(" and (StyleNo in ( {0} )  )", string.Join(",", parameters)) :""
                                 ,string.Format(" and Date between '{0}' and '{1}'",DateRangeTB.Text.Substring(0,8),DateRangeTB.Text.Substring(11))
                                 , (string.IsNullOrEmpty(StyleNoSeachTB.Text)) ? "" : "and StyleNo = '" + StyleNoSeachTB.Text + "'");
                    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    for (int i = 0; i < StyleArray.Length; i++)
                        command1.Parameters.AddWithValue(parameters[i], StyleArray[i]);
                    command1.Parameters.Add("@Area", SqlDbType.NVarChar).Value = (StrArea == "TW") ? AreaDDL.SelectedValue : StrArea;
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader();
                    dt.Load(dr);
                    command1.CommandText = string.Format(@"select * from [View工時資料]
                                                                                   where  [地區]=@Area {0} {1} {2}"
                                 , (!string.IsNullOrEmpty(StyleNoSearchMutiTB.Text)) ? string.Format(" and [款號] in ( {0} ) ", string.Join(",", parameters)) : ""
                                 , string.Format(" and [工作時間] between '{0}' and '{1}'", DateRangeTB.Text.Substring(0, 8), DateRangeTB.Text.Substring(11))
                                 , (string.IsNullOrEmpty(StyleNoSeachTB.Text)) ? "" : "and 款號 = '" + StyleNoSeachTB.Text + "'");
                    command1.ExecuteNonQuery();
                    SqlDataReader dr2 = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt2.Load(dr2);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception)
                {
                    //Log.ErrorLog(ex, "上傳失敗", StrProgram);
                    //transaction1.Rollback();
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                }
            }
            #endregion
            if (dt.Rows.Count > 0 && dt2.Rows.Count>0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("工時資料", dt2);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");

            //GridView2.DataBind();
            //ReportViewer1.LocalReport.Refresh();
        }
        public void FClear()
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            ReportViewer1.Visible = false;
        }
        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(@" SELECT          a.Team, a.Date, a.Flag, a.CreateDate, a.ModifyDate, b.SheetName AS 頁簽名稱, b.Dept AS 部門, b.Customer AS 客戶, 
                                            b.StyleNo AS 款號, b.OrderQty AS 訂單量, b.OrderShipDate AS 訂單交期, b.OnlineDate AS 上線日期, 
                                            b.StandardProductivity AS 標準產量, b.TeamProductivity AS 組生產量, b.GoalProductivity AS 今日目標產量, 
                                            b.DayProductivity AS 今日產量, b.PreProductivity AS 前天累積產量, b.TotalProductivity AS 累積產量, 
                                            b.Person AS 實際工作人數, b.Time AS 工時, b.TotalTime AS 總時數, b.Difference AS 差異量, 
                                            b.Efficiency AS 組各別效率, b.TotalEfficiency AS 組效率, b.ReturnPercent AS 返修率, 
                                            b.Rmark1 AS 責任歸屬及上線天數, b.Rmark2 AS 顏色, b.DayCost1 AS 今日各組成本, b.DayCost2 AS 今日生產成本, 
                                            b.DayCost3 AS 工繳收入, b.DayCost4 AS 今日工繳收入, b.DayCost5 AS 今日生產損益, b.DayCost6 AS CM損益, 
                                            b.DayCost7 AS 累積損益, b.QCQty AS QC檢驗數量, b.ErrorQty AS 瑕疵數, b.OnlineDay AS 上線天數
                FROM              Productivity_Head AS a LEFT OUTER JOIN
                                            Productivity_Line AS b ON a.uid = b.uid
                WHERE          (a.Flag = @Flag) AND (a.Date BETWEEN @Date1 AND @Date2) AND (b.StyleNo LIKE @StyleNo)  and Area ='VGG' 
                ");
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            //if (主料CB.Checked)
            //    strsql.Append(" and upper([主副料])  = 'M' ");
            //if (入庫CB.Checked)
            //    strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            return strsql;
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchStyleNo(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct b.StyleNo from Productivity_Head a left join Productivity_Line b on a.uid=b.uid where a.Flag=1 and (upper(b.StyleNo) like '%'+  @SearchText + '%'  ) ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["StyleNo"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }

    }
}