using AjaxControlToolkit;
using ClosedXML.Excel;
using GGFPortal.ReferenceCode;
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

namespace GGFPortal.TempCode
{
    public partial class GGFTempCodeGridViewEdite : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string Str上傳路徑 = @"~\ExcelUpLoad\VN\工廠驗收報告\";
        static string StrPageName = "UpLoad ", StrProgram = "TempCode3.aspx";
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
            if (!Page.IsPostBack)
                DbInit();

            //if (Convert.ToInt32(GridView1.PageIndex) != 0)
            //{
            //    //==如果不加上這行IF判別式，假設當我們看第四頁時， 
            //    //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
            //    GridView1.PageIndex = 0;
            //}
        }
        protected void DbInit()
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
                SqlCommand command1 = new SqlCommand();
                conn1.Open();
                try
                {
                    command1.Connection = conn1;
                    #region 查詢
                    string Str搜尋參數 = "款號";
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format($@"SELECT [id], [DataModifyDate], [款號], [料號], [Qty], [file_name], [Reason], [ReasonCode] FROM [GGF收料報告]
                                 where DataModifyDate > getdate()-9 {(!string.IsNullOrEmpty(MutiTB.Text)?" and "+Str搜尋參數 +string.Format( " in ({0}) ", string.Join(",", parameters)):"")}");
                    if(!string.IsNullOrEmpty(MutiTB.Text))
                        for (int i = 0; i < StrArrary.Length; i++)
                            command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                }
            }
            #endregion

            if (dt.Rows.Count > 0)
            {
                GV.DataSource = dt;
                GV.DataBind();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(" SELECT [id], [DataModifyDate], [款號], [料號], [Qty], [file_name], [Reason], [ReasonCode] FROM [GGF收料報告] where  ");

            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            return bCheck;

        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="EditData"||e.CommandName=="DeleteData")
                using (GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer)
                {
                    ////抓key
                    //string strid = GV.DataKeys[row.RowIndex].Values[0].ToString();
                    ////抓資料
                    //Session["Uid"] = GV.Rows[row.RowIndex].Cells[3].Text;
                    switch (e.CommandName)
                    {
                        case "EditData":
                            int iId= (int)GV.DataKeys[row.RowIndex].Values[0];
                            Session["UpdateId"] = iId;
                            using (SqlConnection conn= new SqlConnection(strConnectString))
                            {
                                using (SqlCommand command=new SqlCommand())
                                {
                                    command.CommandText = $"select DataModifyDate,款號,料號,Qty,ReasonCode,收料人員,備註 from GGF收料報告 where id= {iId} ";
                                    command.Connection = conn;//資料庫連接
                                    conn.Open();
                                    using (SqlDataReader dr = command.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {
                                            string strDDL = dr.IsDBNull(dr.GetOrdinal("ReasonCode")) ? "" : dr["ReasonCode"].ToString();
                                            備註TB.Text = (strDDL == "OTHER") ? dr.IsDBNull(dr.GetOrdinal("備註")) ? "" : dr["備註"].ToString() : "";
                                            收料人員TB.Text = dr.IsDBNull(dr.GetOrdinal("收料人員")) ? "" : dr["收料人員"].ToString();
                                            StyleLB.Text = dr["款號"].ToString();
                                            收料日期LB.Text = dr["DataModifyDate"].ToString();
                                            備註TB.Visible = (strDDL == "OTHER") ? true : false;
                                            if (!string.IsNullOrEmpty(strDDL))
                                                if (錯誤原因DDL.Items.Contains(錯誤原因DDL.Items.FindByValue(strDDL)) == true)
                                                {
                                                    錯誤原因DDL.SelectedValue = 錯誤原因DDL.Items.FindByValue(strDDL).Value;
                                                }
                                                else
                                                {
                                                }
                                            else
                                            {
                                                錯誤原因DDL.SelectedValue = "";
                                            }
                                        }
                                    }
                                }
                            }
                            EditPanel_ModalPopupExtender.Show();
                            break;
                        default:
                            break;
                    }
                }

        }
        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }


        protected void SaveBT_Click(object sender, EventArgs e)
        {
            File_Upload();
        }

        private void File_Upload()
        {
            int IUpdateId = 0;
            int.TryParse(Session["UpdateId"].ToString(), out IUpdateId);
            if(IUpdateId>0)
            {
                string StrFileName = "";
                string StrUploadFileError = "";
                //沒有強制更新資料
                if ((upload_file.PostedFile != null) && (upload_file.PostedFile.ContentLength > 0))
                {
                    
                    string LocationFiled = Server.MapPath(Str上傳路徑);
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile uploadedFile = Request.Files[i];
                        string fn = Path.GetFileName(uploadedFile.FileName);
                        if (!string.IsNullOrEmpty(fn))
                        {
                            string Str副檔名 = Path.GetExtension(fn);
                            try
                            {
                                while (File.Exists(LocationFiled + fn))
                                {
                                    fn = fn.Substring(0, fn.Length - Str副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Str副檔名;
                                }
                                uploadedFile.SaveAs(LocationFiled + fn);
                                StrFileName += StrFileName.Length > 0 ? "," + fn : fn;
                            }
                            catch (Exception ex)
                            {
                                StrUploadFileError += "FileUpload Error：" + fn + ex.ToString() + "\\n";
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if(StrUploadFileError.Length>0)
                {
                    F_ErrorShow(StrUploadFileError);
                }
                else
                {
                    //sing (SqlConnection conn = new SqlConnection(strConnectString))
                    using (SqlConnection conn = new SqlConnection("TestConnectionString"))
                    {
                        string strSql = "";
                        SqlCommand command1 = conn.CreateCommand();
                        SqlTransaction transaction;
                        conn.Open();
                        transaction = conn.BeginTransaction("Update越南收料");
                        try
                        {
                            strSql = string.IsNullOrEmpty(StrFileName) ? "" : " , file_name = @file_name ";

                            command1.Connection = conn;
                            command1.Transaction = transaction;
                            command1.CommandText = string.Format(@"UPDATE [dbo].[GGF收料報告] SET
                                        Reason=@Reason
                                        ,ReasonCode=@ReasonCode
                                        ,備註=@備註
                                        ,收料人員=@收料人員
                                    {0} WHERE id = @id ", strSql);
                            command1.Parameters.Add("@收料人員", SqlDbType.NVarChar).Value = 收料人員TB.Text.Trim();
                            command1.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = 錯誤原因DDL.SelectedItem.Text;
                            command1.Parameters.Add("@ReasonCode", SqlDbType.NVarChar).Value = 錯誤原因DDL.SelectedItem.Value;
                            command1.Parameters.Add("@備註", SqlDbType.NVarChar).Value = 備註TB.Visible ? 備註TB.Text.Trim() : "";
                            command1.Parameters.Add("@id", SqlDbType.Int).Value = IUpdateId;
                            if(strSql.Length>0)
                            {
                                command1.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = StrFileName;
                            }
                            command1.ExecuteNonQuery();
                            command1.Parameters.Clear();
                            transaction.Commit();
                            Session.Remove("UpdateId");
                            DbInit();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Update Error :" , StrProgram);
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Update Error Error:", StrProgram);
                            }
                            finally
                            {
                                transaction.Rollback();
                                F_ErrorShow("Update Fail");
                            }
                        }
                    }
                }
            }
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string StrLink = e.Row.Cells[6].Text;
                if(!string.IsNullOrEmpty(StrLink) && StrLink != "&nbsp;")
                {
                    Label label = (Label)e.Row.FindControl("LinkLB");
                    StringBuilder SbLinkScr = new StringBuilder();
                    string[] stringSeparators = new string[] { "," };
                    string[] vs = StrLink.Split(stringSeparators, StringSplitOptions.None);
                    for (int i = 0; i < vs.Length; i++)
                    {
                        SbLinkScr.AppendFormat(@"{0} <a href=""/ExcelUpLoad/VN/工廠驗收報告/{1}"">檔案 {2}</a>", i > 0 ? "," : "",vs[i],(i+1).ToString());
                    }
                    label.Text = SbLinkScr.ToString();
                }
            }
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            MutiTB.Text = "";
            GV.PageIndex = 1;
            DbInit();
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            GV.PageIndex = 1;
            DbInit();
        }

        protected void GV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //GV.PageIndex = e.NewSelectedIndex;
            //DbInit();
        }

        protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV.PageIndex = e.NewPageIndex;
            DbInit();
        }
        protected void 錯誤原因DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DDL因為AutoPostback會重刷畫面，因為file_load無法使用UpPanel所以要再將ModalPopupExtender.Show()
            備註TB.Visible = 錯誤原因DDL.SelectedValue == "OTHER";
            EditPanel_ModalPopupExtender.Show();
        }


    }
}