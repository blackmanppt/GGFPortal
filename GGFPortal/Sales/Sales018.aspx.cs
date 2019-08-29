using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.DataSetSource;
using GGFPortal.ReferenceCode;

namespace GGFPortal.Sales
{
    public partial class Sales018 : System.Web.UI.Page
    {
        字串處理 切字串 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        string StrError名稱, StrProgram;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題
            BrandLB.Text = "訂單樣衣完工";
            StrError名稱 = "訂單樣衣完工上傳失敗";
            StrProgram = "Sales018.aspx";
            #endregion

            DateRangeTB.Attributes["readonly"] = "readonly";
            if (Page.IsPostBack)
            {
                //DbInit();
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();

        }

        private void DbInit()
        {
            string strwhere = (!string.IsNullOrEmpty(款號TB.Text.Trim())) ? " and cus_item_no in " + 切字串.字串多筆資料搜尋(款號TB.Text).ToString() : "";
            StringBuilder strsql = new StringBuilder();

            //日期
            string StrDate = DateRangeTB.Text;

            //款號

            strsql.AppendFormat(@"SELECT distinct TOP (100)  a.site,a.ord_nbr,b.cus_item_no, doc_item,a.color_id, color_cname, color_ename,req_date, material_flag, material_check_date , sum(a.doc_qty) as 'SumQty'
                    FROM ordc_sample a left join ordc_bah1 b on a.site=b.site and a.ord_nbr=b.ord_nbr
                    where a.material_flag=1 {0} and substring( CONVERT(varchar(10),req_date,111),1,7) between '{1}' and '{2}' and b.vendor_id like'{3}'
                    group by a.site,a.ord_nbr,b.cus_item_no, doc_item,a.color_id, color_cname, color_ename,req_date, material_flag, material_check_date
                    order by req_date"
                    , strwhere
                    , StrDate.Substring(0, 7)
                    , StrDate.Substring(10, 7)
                    , 代工廠DDL.SelectedItem.Value
                    );
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(strsql.ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (dt.Rows.Count > 0)
            {
                MaterialGV.DataSource = dt;
                MaterialGV.DataBind();
            }
            else
            {
                MaterialGV.DataSource = null;
                MaterialGV.DataBind();
                F_ErrorShow("搜尋不到資料");
            }
                
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            F_Clear();
        }

        private void F_Clear()
        {
            DateRangeTB.Text = "";
            代工廠DDL.SelectedIndex = 0;
            款號TB.Text = "";
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void MaterialGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "結案")
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string StrSite = "", StrOrd = "", StrOrdSam = "",StrColor_id="";
                    StrSite = MaterialGV.Rows[row.RowIndex].Cells[1].Text;
                    StrOrd = MaterialGV.Rows[row.RowIndex].Cells[2].Text;
                    StrOrdSam = MaterialGV.Rows[row.RowIndex].Cells[4].Text;
                    StrColor_id = MaterialGV.Rows[row.RowIndex].Cells[5].Text.Replace("&nbsp;","");
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("UpdateOrdSamClose");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        command1.CommandText = string.Format(@"
                                        update ordc_sample
                                            set material_flag = 99 ,material_check_date =getdate()
                                        where 
                                        site = '{0}' and 
                                        ord_nbr = '{1}' and doc_item = '{2}' and color_id= '{3}' and material_flag = 1
                                        ", StrSite, StrOrd, StrOrdSam, StrColor_id);
                        command1.ExecuteNonQuery();
                        transaction1.Commit();
                        DbInit();
                        //MessageLB.Text = "主副到料日結案上傳完畢";

                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, StrError名稱 + " :", StrProgram);
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, StrError名稱 + " Error:", StrProgram);
                        }
                        finally
                        {
                            transaction1.Rollback();
                            MessageLB.Text = StrError名稱 + "請連絡MIS";
                            AlertPanel_ModalPopupExtender.Show();
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                        //Session.RemoveAll();
                        //AlertPanel_ModalPopupExtender.Show();
                    }
                }
        }
    }
}