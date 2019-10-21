using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using GGFPortal.ReferenceCode;
using System.Text;
using System.Linq;

namespace GGFPortal.FactoryMG
{
    public partial class F007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string StrArea, StrPageName = "F007", StrProgram = "TempCode.aspx";
        字串處理 切字串 = new 字串處理();
        static 多語 lang = new 多語();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                StrArea = Session["Area"].ToString();
                lang.讀取多語資料(StrPageName);
            }
            catch (Exception)
            {
                Session["Error"] = "timeout";
                Response.Redirect("Findex.aspx");
            }
            #region 網頁Layout基本參數
            //網頁標題

            BrandLB.Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Area"] is null)
            {

                Response.Redirect("Findex.aspx");
            }
            //if (IsPostBack)
            //    DbInit();
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        
        private void DbInit()
        {
            DataTable dt = new DataTable();
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
                    string[] StyleArray = StyleNoSeachTB.Text.Trim().Split(stringSeparators, StringSplitOptions.None);
                    #region 匯入
                    string[] parameters = StyleArray.Select((s, i) => "@StyleNo" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"select Team,sum(b.Person* b.Time) as SumTime from  Productivity_Head a left join Productivity_Line b on a.uid=b.uid
                                                            where Flag=1 and Area=@Area {0} {1}
                                                            group by Team "
                                 ,(!string.IsNullOrEmpty(StyleNoSearchMutiTB.Text))? string.Format(" and StyleNo in ( {0} ) ", string.Join(",", parameters)):""
                                 ,string.Format(" and Date between '{0}' and '{1}'",DateRangeTB.Text.Substring(0,8),DateRangeTB.Text.Substring(11)));
                    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    for (int i = 0; i < StyleArray.Length; i++)
                        command1.Parameters.AddWithValue(parameters[i], StyleArray[i]);
                    command1.Parameters.Add("@Area", SqlDbType.NVarChar).Value = StrArea;
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    //Log.ErrorLog(ex, "上傳失敗", StrProgram);
                    transaction1.Rollback();
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                }
            }
            #endregion
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
                //ReportViewer1.Visible = true;
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportDataSource source = new ReportDataSource("採購單料號訂單資料", dt);
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(source);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");

            //GridView2.DataBind();
            //ReportViewer1.LocalReport.Refresh();
        }
        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");
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
                    cmd.CommandText = "select distinct b.StyleNo from Productivity_Head a left join Productivity_Line b on a.uid=b.uid where a.Flag=1 and (upper(b.StyleNo) like '%'+  @SearchText + '%' ) ";
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