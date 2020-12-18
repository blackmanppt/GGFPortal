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

namespace GGFPortal.Sales
{
    public partial class Sales023 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "庫存調撥單查詢", StrProgram = "Sales023.aspx";
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
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@"
                       select  a.inv_nbr 庫存調撥單, b.inv_seq 庫存調撥序號,b.item_no 料號,d.item_spk 料號規格,b.ord_nbr 轉出號碼
                        ,e.cus_item_no 轉出款號,b.ord_nbr_to 轉入號碼,f.cus_item_no 轉入款號
                        ,case when c.pur_unit = 'KGS' then  (b.transaction_qty*c.cloth_y_weight)/1000
						when c.pur_unit ='LBS' then  (b.transaction_qty*c.cloth_y_weight*2.2046)/1000
						else b.transaction_qty end as 調撥數量
						,case when c.pur_unit = 'KGS' or c.pur_unit ='LBS' then  c.pur_unit
						else b.transaction_unit end as 調撥單位
						,c.pur_price 採購單價,c.pur_unit 採購單位
                        from 
                        inv_transaction_master  a left join 
                        inv_transaction_detail b on a.site=b.site and a.inv_nbr=b.inv_nbr 
                        left join (select distinct site,item_no,ord_nbr,pur_price,pur_unit,cloth_y_weight from purc_purchase_detail) c on b.site=c.site and b.item_no=c.item_no and b.ord_nbr=c.ord_nbr
                        left join bas_item_master d on b.site=d.site and b.item_no=d.item_no
                        left join ordc_bah1 e on b.ord_nbr=e.ord_nbr and b.site=e.site
                        left join ordc_bah1 f on b.ord_nbr_to=f.ord_nbr and b.site=f.site
                        where b.inv_detail_status is not null and b.ord_nbr <> b.ord_nbr_to {0} {1}
                        order by a.inv_nbr,b.inv_seq "

                        , (!string.IsNullOrEmpty(款號TB.Text)) ? string.Format(" and e.cus_item_no = '{0}'", 款號TB.Text) : ""
                        , (!string.IsNullOrEmpty(轉入款號TB.Text)) ? string.Format(" and f.cus_item_no = '{0}'", 轉入款號TB.Text) : ""
                        );
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                    //transaction1.Rollback();
                    //throw;
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
                Session["Sales023Data"] = dt;
                GV.DataSource = dt;
                GV.DataBind();
                ExportBT.Visible = true;
            }
            else
            {
                ExportBT.Visible = false;
                F_ErrorShow("搜尋不到資料");
            }   
        }


        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditData":

                    break;
                case "DeleteData":
                    break;
                case "SelectData":
                    //GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    ////抓key
                    //string strid = GV.DataKeys[row.RowIndex].Values[0].ToString();
                    ////抓資料
                    //Session["Uid"] = GV.Rows[row.RowIndex].Cells[3].Text;
                    //Response.Redirect("Sample008.aspx");
                    break;
                default:
                    break;
            }
        }
        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
        protected void ExcelDbInit()
        {
            DataTable dt調撥資料 = (DataTable)Session["Sales023Data"];
            string StrError = "";

            if (dt調撥資料 == null)
            {
                StrError += "無調撥資料";
            }
            if (StrError.Length > 0)
                F_ErrorShow(StrError);
            else
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt調撥資料, "調撥資料");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "調撥資料"));
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

        protected void ExportBT_Click(object sender, EventArgs e)
        {
            ExcelDbInit();
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            款號TB.Text = "";
            轉入款號TB.Text = "";
            Session["Sales023Data"] = null;
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (Session["Sales023Data"] != null)
                Session["Sales023Data"] = null;
            if ( !string.IsNullOrEmpty(款號TB.Text) || !string.IsNullOrEmpty(轉入款號TB.Text))
            {
                DbInit();
            }
            else
                F_ErrorShow("請輸入搜尋條件:款號/轉入款號");
        }

    }
}