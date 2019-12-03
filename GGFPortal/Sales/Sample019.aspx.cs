using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sample019 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "樣品室接收", StrProgram = "Sample019.aspx";
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
                    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
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

        public DataTable DbInit(string StrType)
        {
            DataTable Dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                //SqlCommand command1 = conn1.CreateCommand();
                //SqlTransaction transaction1;
                //conn1.Open();
                //transaction1 = conn1.BeginTransaction("createSelect"+ StrType);
                //try
                //{
                //    command1.Connection = conn1;
                //    command1.Transaction = transaction1;

                //    #region 查詢
                //    string Str搜尋參數 = "";
                //    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                //    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                //    command1.CommandText = string.Format(@"SELECT  from ( select {2} ) a left join View版套借出表 b on a.sam_nbr = b.sam_nbr
                //                 where {1} in ( {0} ) and a.site='GGF'
                //                 ", string.Join(",", parameters), Str搜尋參數, 字串處理.轉換虛擬Select(SearchBT.Text, "sam_nbr"));
                //    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                //    for (int i = 0; i < StrArrary.Length; i++)
                //        command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                //    command1.ExecuteNonQuery();
                //    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                //    Dt.Load(dr);
                //    #endregion
                //    //transaction1.Commit();
                //}
                //catch (Exception ex)
                //{
                //    Log.ErrorLog(ex, "Error", StrProgram);
                //    transaction1.Rollback();
                //    throw;
                //}
                //finally
                //{
                //    conn1.Close();
                //    transaction1.Dispose();
                //}

                try
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(string.Format(@"SELECT *  from (  {0} ) a left join View版套借出 b on a.打樣單號 = b.sam_nbr
                                  
                                 ",  字串處理.轉換虛擬Select(MutiTB.Text, "打樣單號")), Conn);
                    myAdapter.Fill(Dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);

                }
            }
            return Dt;
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

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            Session.Remove("DT正確");
            using (DataTable DT確認資料 = DbInit(""))
            {
                if (DT確認資料.Rows.Count > 0)
                {
                    UpDateBT.Visible = false;
                    UpdateGV.Visible = false;
                    ErrorGV.Visible = false;
                    ErrorLB.Visible = false;
                    using (DataTable DT正確資料 = new DataTable(),DT異常資料 = new DataTable())
                    {
                        DT正確資料.Columns.Add("sam_nbr");
                        DT正確資料.Columns.Add("cus_style_no");
                        DT異常資料.Columns.Add("搜尋單號");
                        DT異常資料.Columns.Add("sam_nbr");
                        DT異常資料.Columns.Add("Error");
                        foreach (DataRow item in DT確認資料.Rows)
                        {
                            try
                            {
                                DataRow DR正確 = DT正確資料.NewRow(), DR異常 = DT異常資料.NewRow();
                                //有款號有借出紀錄
                                if (!string.IsNullOrEmpty(item["cus_style_no"].ToString()) && item["借出狀態"].ToString()=="10")
                                {
                                    DR正確["sam_nbr"] = item["sam_nbr"].ToString();
                                    DR正確["cus_style_no"] = item["cus_style_no"].ToString();
                                    DT正確資料.Rows.Add(DR正確);
                                }
                                //沒有打樣單
                                else
                                {
                                    if (string.IsNullOrEmpty(item["cus_style_no"].ToString()))
                                    {
                                        DR異常["搜尋單號"] = item["打樣單號"].ToString();
                                        DR異常["sam_nbr"] = "";
                                        DR異常["Error"] = "沒有打樣單資料";
                                    }
                                    //有借出紀錄未歸還
                                    else
                                    {
                                        DR異常["搜尋單號"] = item["打樣單號"].ToString();
                                        DR異常["sam_nbr"] = item["sam_nbr"].ToString();
                                        DR異常["Error"] = "有借出狀態不是打版室借出，狀態：" + item["狀態"].ToString(); ;
                                    }
                                    DT異常資料.Rows.Add(DR異常);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.ErrorLog(ex, "Search Error", StrProgram);
                                F_ErrorShow(ex.ToString());
                            }
                            
                            if (DT正確資料.Rows.Count > 0)
                            {
                                Session["DT正確"] = DT正確資料;
                                UpDateBT.Visible = true;
                                UpdateGV.Visible = true;
                                UpdateGV.DataSource = DT正確資料;
                                UpdateGV.DataBind();
                            }
                            //Session["DT異常"] = (DT異常資料.Rows.Count > 0) ? DT異常資料 : null;
                            if (DT異常資料.Rows.Count > 0)
                            {
                                ErrorGV.Visible = true;
                                ErrorLB.Visible = true;
                                ErrorGV.DataSource = DT異常資料;
                                ErrorGV.DataBind();
                            }
                        }
                    }
                }
            }
            

        }

        protected void UpDateBT_Click(object sender, EventArgs e)
        {
            using(DataTable DT= (DataTable)Session["DT正確"])
            {
                if (DT.Rows.Count>0)
                {
                    using(SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        try
                        {
                            #region 查詢資否是否有異動
                            DataTable DTCheck = new DataTable();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                            
                            string[] parameters = DT.Rows.OfType<DataRow>().Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
                            SqlCommand Cmd = new SqlCommand(string.Format(@"select * from View版套借出 where sam_nbr in ({0}) ", string.Join(",", parameters)),Conn);
                            sqlDataAdapter.SelectCommand = Cmd;
                            for (int i = 0; i < DT.Rows.Count; i++)
                                Cmd.Parameters.AddWithValue(parameters[i], DT.Rows[i]["sam_nbr"]);
                            Conn.Open();
                            sqlDataAdapter.Fill(DTCheck);
                            Cmd.ExecuteNonQuery();
                            Conn.Dispose();
                            DataView dv = new DataView(DTCheck);
                            dv.RowFilter = "借出狀態 <> 10";
                            DataTable DTReCheck = new DataTable();
                            DTReCheck = dv.ToTable();
                            //必須無借出資料
                            if (DTReCheck.Rows.Count>0)
                            {
                                F_ErrorShow("資料有異動紀錄，請重新搜尋");
                            }
                            #endregion
                            else
                            {
                                
                                Cmd.Dispose();
                                #region 匯入租借紀錄
                                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                                {
                                    SqlCommand command1 = conn1.CreateCommand();
                                    SqlTransaction transaction1;
                                    conn1.Open();
                                    transaction1 = conn1.BeginTransaction("UpdateRent1");

                                    command1.Connection = conn1;
                                    command1.Transaction = transaction1;
                                    try
                                    {
                                        command1.CommandText = string.Format(@"UPDATE [GGFSampleRent]
                                                                                           SET [樣品室收到時間]=getdate(),
                                                                                               [借出狀態]=20,
                                                                                               [RentModifyDate]=getdate()
                                                                                           WHERE [sam_nbr] in ({0}) and [借出狀態]=10
                                                                                     ", string.Join(",", parameters));
                                        for (int i = 0; i < DT.Rows.Count; i++)
                                            command1.Parameters.AddWithValue(parameters[i], DT.Rows[i]["sam_nbr"]);
                                        command1.ExecuteNonQuery();
                                        //上傳成功更新Head狀態
                                        //command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 1 ,[Date] = @Date WHERE uid = {0} ", iIndex);
                                        //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
                                        //command1.ExecuteNonQuery();
                                        transaction1.Commit();
                                        //Label1.Text = "DataUpSuccess";
                                        F_ErrorShow("資料上傳成功");
                                        
                                    }
                                    catch (Exception ex1)
                                    {
                                        try
                                        {
                                            Log.ErrorLog(ex1, "UPDATE Error", StrProgram);
                                        }
                                        catch (Exception ex2)
                                        {
                                            Log.ErrorLog(ex2, "UPDATE Error Error", StrProgram);
                                        }
                                        finally
                                        {
                                            transaction1.Rollback();
                                            //Label1.Text = "UpdateError";
                                            F_ErrorShow("UPDATE Error");
                                        }
                                    }
                                    finally
                                    {
                                        conn1.Close();
                                        conn1.Dispose();
                                        command1.Dispose();
                                        UpDateBT.Visible = false;
                                    }
                                }
                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            F_ErrorShow("上傳失敗，請重新上傳或通知資訊部，錯誤訊息：" + ex.ToString());

                        }
                        finally
                        {
                            Conn.Close();
                        }
                        
                    }

                }
            }
        }

        protected void CancelBT_Click(object sender, EventArgs e)
        {
            MutiTB.Text = "";
            ErrorGV.Visible = false;
            UpdateGV.Visible = false;
            UpDateBT.Visible = false;
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}