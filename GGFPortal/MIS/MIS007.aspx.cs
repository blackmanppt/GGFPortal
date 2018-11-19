using GGFPortal.DataSetSource;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{

    public partial class MIS007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 字串處理 = new 字串處理();
        //GGFEntitiesMGT db = new GGFEntitiesMGT();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DBBind();
        }

        private void DBBind()
        {
            if (string.IsNullOrEmpty(採購單TB.Text) && string.IsNullOrEmpty(款號TB.Text) && string.IsNullOrEmpty(供應商TB.Text))
            {
                MessageLB.Text = "請輸入搜尋條件";
                AlertPanel_ModalPopupExtender.Show();
            }
            else if (string.IsNullOrEmpty(款號TB.Text) && !string.IsNullOrEmpty(供應商TB.Text))
            {
                MessageLB.Text = "使用供應商查詢需輸入款號";
                AlertPanel_ModalPopupExtender.Show();
            }
            else
            { 
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT [採購單號碼]
                                  ,[主副料]
                                  ,[訂單號碼]
                                  ,[款號]
                                  ,[採購單狀態]
                              FROM [dbo].[View未核准採購單] where 1=1 ");
                if (!string.IsNullOrEmpty(採購單TB.Text))
                    sb.AppendFormat(" and 採購單號碼 in {0}", 字串處理.字串多筆資料搜尋(採購單TB.Text).ToString());
                if (!string.IsNullOrEmpty(款號TB.Text))
                    sb.AppendFormat(" and 款號 in {0}", 字串處理.字串多筆資料搜尋(款號TB.Text).ToString());
                if (!string.IsNullOrEmpty(供應商TB.Text))
                    sb.AppendFormat(" and  (供應商簡稱 ='{0}' or  供應商代號 = '{0}')", 供應商TB.Text);
                if (sb.Length > 0)
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                        myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                    }
                    確認GV.DataSource = dt;
                    確認GV.DataBind();
                    if (dt.Rows.Count > 0)
                    {
 
                    }
                    else
                    {
                        MessageLB.Text = "搜尋不到資料";
                        AlertPanel_ModalPopupExtender.Show();
                    }
                }
            }
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            採購單TB.Text = "";
            款號TB.Text = "";
            供應商TB.Text = "";
        }

        protected void UpDateBT_Click(object sender, EventArgs e)
        {
            int icount = 0;
            if (確認GV.Rows.Count>0)
            { 
                icount = 確認GV.Rows.Count;
                StringBuilder sb = new StringBuilder();
                CheckBox CHK = (CheckBox)(確認GV.HeaderRow.Cells[0].FindControl("全部更新CB"));

                //List<string> L櫃號 = new List<string>();
                for (int i = 0; i < icount; i++)
                {
                    if (CHK.Checked)
                    {
                        sb.Append(string.IsNullOrEmpty(確認GV.Rows[i].Cells[1].Text.Trim()) ? "" : (sb.Length > 0)?" , '"+確認GV.Rows[i].Cells[1].Text.Trim()+"' ": " '" + 確認GV.Rows[i].Cells[1].Text.Trim() + "' ");
                    }
                    else
                    {
                        CheckBox CHK2 = (CheckBox)(確認GV.Rows[i].Cells[0].FindControl("UpdateCB"));
                        if (CHK2.Checked)
                        {
                            sb.Append(string.IsNullOrEmpty(確認GV.Rows[i].Cells[1].Text.Trim()) ? "" : (sb.Length > 0) ? " , '" + 確認GV.Rows[i].Cells[1].Text.Trim() + "' " : " '" + 確認GV.Rows[i].Cells[1].Text.Trim() + "' ");
                        }
                    }
                }

                if(sb.Length>0)
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand command1 = conn1.CreateCommand();
                        SqlTransaction transaction1;
                        conn1.Open();
                        transaction1 = conn1.BeginTransaction("UpdatePur");

                        command1.Connection = conn1;
                        command1.Transaction = transaction1;
                        try
                        {


                            command1.CommandText = string.Format(@"
                                        update purc_purchase_master
                                            set pur_head_status='OP',pur_approver='105020',pur_approve_date=getdate()
                                        where pur_head_status in ('NA','O1') and
                                        pur_nbr in
                                        (
                                        {0}
                                        )
                                        ", sb.ToString());
                            command1.ExecuteNonQuery();
                            command1.Parameters.Clear();
                            command1.CommandText = string.Format(@"
                                        update purc_purchase_detail
                                            set pur_detail_status='OP'
                                        where pur_detail_status in ('NA','O1') and
                                        pur_nbr
                                        in
                                        (
                                        {0}
                                        )
                                        ", sb.ToString());
                            command1.ExecuteNonQuery();

                            transaction1.Commit();
                            DBBind();
                            MessageLB.Text = "採購單核准完畢";
                            AlertPanel_ModalPopupExtender.Show();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "採購單核准失敗 :", "MIS007.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "採購單核准失敗 Error:", "MIS007.aspx");
                            }
                            finally
                            {
                                transaction1.Rollback();
                                MessageLB.Text = "採購單核准失敗請連絡MIS";
                                AlertPanel_ModalPopupExtender.Show();
                                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('核准失敗請連絡MIS');</script>");
                            }
                        }
                        finally
                        {
                            conn1.Close();
                            conn1.Dispose();
                            command1.Dispose();
                            //Session.RemoveAll();
                        }
                    }
            }
        }
    }
}