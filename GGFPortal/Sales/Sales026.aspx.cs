using AjaxControlToolkit;
using ClosedXML.Excel;
using GGFPortal.ReferenceCode;
using Syncfusion.XlsIO.Implementation.XmlSerialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales026 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VNNGGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "VGG AMZ Stock", StrProgram = "Sales026.aspx";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MutiTB.Visible = MutiCB.Checked ? true : false;
        }
        protected void DbInit(string strtype = null)
        {
            DataTable dt = new DataTable();
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

                    #region 查詢
                    string Str搜尋參數 = "";
                    string Strsql = "";
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    Strsql = ((MutiTB.Text.Length > 0) ?  Str搜尋參數 + " in (" + string.Join(",", parameters) + ") ":"");
                    if (SearchTB.Text.Length>0)
                    {
                        Strsql = (MutiTB.Text.Length > 0) ? $"   ( {Strsql} or item_no = '{SearchTB.Text}' " : $"  item_no ='{SearchTB.Text}'";
                    }
                    Strsql = Strsql.Length > 0 ? " where " + Strsql : "";
                    command1.CommandText = string.Format($@"select * from View_AMZStock {Strsql} "
                    );
                    for (int i = 0; i < StrArrary.Length; i++)
                        command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                    transaction1.Rollback();
                    throw;
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
                GV.DataSource = dt;
                GV.DataBind();
                ExportBT.Visible = true;
            }
            else
            {
                ExportBT.Visible = false;
                F_ErrorShow("搜尋不到資料");
            }
                
            if(!string.IsNullOrEmpty(strtype))
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "AMZ_Stock");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "AMZ_Stock"));
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void ExportBT_Click(object sender, EventArgs e)
        {
            DbInit("Excel");
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            SearchTB.Text = "";
            MutiTB.Text = "";
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}