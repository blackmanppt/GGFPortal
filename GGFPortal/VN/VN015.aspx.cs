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

namespace GGFPortal.VN
{
    public partial class VN015 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();

        static string StrPageName = "Search For Grid", StrProgram = "TempCode.aspx";
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
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@"SELECT d* from 
                                 where {1} in ( {0} ) and a.site='GGF'
                                 ", string.Join(",", parameters), Str搜尋參數);
                    command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
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
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
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
                            //ModalPopupExtender modalPopupExtender = (ModalPopupExtender)FindControl("ContentPlaceHolder1_AlertPanel_ModalPopupExtender");
                            //modalPopupExtender.Show();
                            //EditLB.Text = "sfse";
                            int iId= (int)GV.DataKeys[row.RowIndex].Values[0];
                            Session["UpdateId"] = iId;
                            using (SqlConnection conn= new SqlConnection(strConnectString))
                            {
                                conn.Open();

                                using (SqlCommand command=new SqlCommand())
                                {
                                    command.CommandText = $"select DataModifyDate,款號,料號,Qty,ReasonCode from GGF收料報告 where id= {iId} ";
                                    command.Connection = conn;//資料庫連接
                                    SqlDataReader dr = command.ExecuteReader();//執行並回傳DataReader
                                    if (dr.HasRows)//檢查是否有資料列
                                    {
                                        
                                        string strDDL = dr["ReasonCode"].ToString();
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
                                        備註TB.Visible = (strDDL == "其他");
                                        備註TB.Text = (strDDL == "其他") ? dr["備註"].ToString() : "";
                                        收料人員TB.Text = dr["收料人員"].ToString();


                                    }
                                }

                            }
                            EditPanel_ModalPopupExtender.Show();
                            break;
                        //case "DeleteData":
                        //    break;
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
                    string Str上傳路徑 = @"~\ExcelUpLoad\VN\工廠驗收報告\";
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
                    using (SqlConnection conn = new SqlConnection(strConnectString))
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
                            command1.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = 錯誤原因DDL.SelectedValue;
                            command1.Parameters.Add("@ReasonCode", SqlDbType.NVarChar).Value = 錯誤原因DDL.SelectedValue;
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
                            GV.DataBind();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), StrProgram);
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), StrProgram);
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
                string StrLink = e.Row.Cells[4].ToString();
                if(!string.IsNullOrEmpty(StrLink))
                {
                    Label label = (Label)e.Row.FindControl("LinkLB");
                    StringBuilder SbLinkScr = new StringBuilder();
                    string[] stringSeparators = new string[] { "," };
                    string[] vs = StrLink.Split(stringSeparators, StringSplitOptions.None);
                    for (int i = 0; i < vs.Length; i++)
                    {
                        SbLinkScr.AppendFormat(@"{0} <a href=""{1}"">{2}</a>", i > 0 ? "," : "",vs[i],i.ToString());
                    }
                    label.Text = SbLinkScr.ToString();
                }
            }
        }

        protected void 錯誤原因DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            備註TB.Visible = 錯誤原因DDL.SelectedValue == "OTHER";
            EditPanel_ModalPopupExtender.Show();
        }


    }
}