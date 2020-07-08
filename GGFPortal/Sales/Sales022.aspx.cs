﻿using AjaxControlToolkit;
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
    public partial class Sales022 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "採購入庫查詢", StrProgram = "Sales022.aspx";
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
                    string Str搜尋參數 = "cus_item_no";
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@"select
								a.site,
                                dbo.F_NationName(e.site,nation_no) as '產區'
                                ,dbo.F_VendorName(d.site,c.vendor_id) as '代工廠'
                                ,a.pur_nbr as '採購單號'
                                ,g.transatn_term as '交易條件'
								,cus_item_no as '款號'
								,pur_qty as '採購量'
                                ,b.vendor_id as '廠商代號'
								,i.UnCountQty as '不計價總量'
                                ,a.rec_qty as '入庫數量'
								,i.RecQty  as '已入庫量'
								,a.pur_unit as '單位'
                                ,a.pur_price   as '單價'
                                ,a.pur_amt  as '金額'
                                ,employee_name as '業務'
                                ,a.overage_allow as '允收上限'
                                ,h.item_no as '料號'
								,a.org_item_no as '原始料號'
                                ,f.item_name as '料號名稱'
                                ,case when b.pur_kind = 'M' then '主料' when b.pur_kind = 'S' then '副料' else b.pur_kind end as '料號別'
                                ,h.color_cname,h.color_ename ,f.item_spk as '英文料號'
                                ,d.transatn_term 訂單交易條件
                                from purc_purchase_detail a
                                left join purc_purchase_master b on a.site=b.site and a.pur_nbr=b.pur_nbr 
                                left join ordc_bah1 c on c.site=b.site and c.ord_nbr=b.ord_nbr
                                left join ordc_bah2 d on d.site=c.site and d.ord_nbr=c.ord_nbr
                                left join bas_employee e on e.site=b.site and b.buyer=e.employee_no
                                left join bas_vendor_mgt g on b.vendor_id=g.vendor_id and b.site=g.site
                                left join bas_item_master f on a.item_no =f.item_no and a.site=f.site
                                left join v_color h on h.item_no =a.item_no and h.site=a.site
                                left join View入庫數量 i on a.site=i.site and a.pur_nbr=i.pur_nbr and a.pur_seq =i.pur_seq
                                where pur_head_status<>'CA' and bah_status<>'CA'
								and pur_detail_status <> 'CA' and item_status <>'CA' 
                                where {1}  ( {0} ) and a.site='GGF' "
                                , (!string.IsNullOrEmpty(MutiTB.Text))?string.Join(",", parameters):""
                                , (!string.IsNullOrEmpty(MutiTB.Text))?Str搜尋參數:""
                                ,(string.IsNullOrEmpty(客戶TB.Text))?string" and cus_id = "
                                );
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
            switch (e.CommandName)
            {
                case "EditData":

                    break;
                case "DeleteData":
                    break;
                case "SelectData":
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //抓key
                    string strid = GV.DataKeys[row.RowIndex].Values[0].ToString();
                    //抓資料
                    Session["Uid"] = GV.Rows[row.RowIndex].Cells[3].Text;
                    Response.Redirect("Sample008.aspx");
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
            DataTable dt振大主表 = new DataTable(), dt振大布類 = new DataTable(), dt振大顏色 = new DataTable();
            string StrError = "";
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(Selectsql("振大主表").ToString(), Conn);
                myAdapter.Fill(dt振大主表);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                myAdapter.SelectCommand.CommandText = Selectsql("振大布類").ToString();
                myAdapter.Fill(dt振大布類);
                myAdapter.SelectCommand.CommandText = Selectsql("振大顏色").ToString();
                myAdapter.Fill(dt振大顏色);
            }

            if (dt振大主表 == null)
            {
                StrError += "振大主表無資料<br/>";
            }
            if (dt振大布類 == null)
            {
                StrError += "振大布料無資料<br/>";
            }
            if (dt振大布類 == null)
            {
                StrError += "振大布類無資料";
            }
            if (StrError.Length > 0)
                F_ErrorShow(StrError);
            else
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt振大主表, "振大主表");
                    wb.Worksheets.Add(dt振大布類, "振大布類");
                    wb.Worksheets.Add(dt振大顏色, "振大顏色");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "檔案名稱"));
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

        }

    }
}