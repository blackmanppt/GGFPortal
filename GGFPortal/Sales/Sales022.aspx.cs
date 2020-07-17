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
                        ,a.pur_seq as '採購序號'
                        ,g.transatn_term as '交易條件'
                        ,cus_item_no as '款號'
                        ,pur_qty as '採購量'
                        ,b.vendor_id as '廠商代號'
                        ,i.UnCountQty as '不計價總量'
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
                        ,h.color_cname,h.color_ename ,f.item_spk as '料號規格'
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
                        where {0}  a.site='GGF' and pur_head_status<>'CA' and bah_status<>'CA'
                        and pur_detail_status <> 'CA' and item_status <>'CA'
                        {1} {2} {3} {4}"
                        , (!string.IsNullOrEmpty(MutiTB.Text))? Str搜尋參數 +" in ( " + string.Join(",", parameters) + " and " : ""
                        , (!string.IsNullOrEmpty(客戶TB.Text)) ? string.Format(" and cus_id = '{0}'", 客戶TB.Text) : ""
                        , (!string.IsNullOrEmpty(款號TB.Text)) ? string.Format(" and cus_item_no = '{0}'", 款號TB.Text) : ""
                        , string.Format(" and a.ord_nbr in (select ord_nbr from ordc_bat where last_date between '{0}' and '{1}' and bat_status<>'CA' and cancel_yn='N' )", DateRangeTB.Text.Substring(0, 10), DateRangeTB.Text.Substring(13, 10))
                        , (!string.IsNullOrEmpty(工廠DDL.SelectedValue)) ? string.Format(" and c.vendor_id ='{0}'", 工廠DDL.SelectedValue) : ""

                        );
                    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    if (MutiTB.Text.Length>0)
                    {
                        for (int i = 0; i < StrArrary.Length; i++)
                            command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    }
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
                Session["Sales022Data"] = dt;
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

        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");

            return strsql;
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
                    string Str採購單 = "",Str採購序號="",Str規格="";
                    DataTable dt = new DataTable();
                    //抓key
                    //string strid = GV.DataKeys[row.RowIndex].Values[0].ToString();
                    //抓資料
                    Str採購單 = GV.Rows[row.RowIndex].Cells[3].Text;
                    Str採購序號 = GV.Rows[row.RowIndex].Cells[4].Text;
                    Str規格 = GV.Rows[row.RowIndex].Cells[6].Text;
                    規格LB.Text = Str規格;
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter(string.Format(@"select  
                            a.rec_nbr 入庫單號,a.rec_seq 入庫序號,a.rec_qty as 入庫數量
                            ,case when a.posted_acp='P' then '已進應付系統' else '' end as 應付狀態 ,convert(varchar(10),eta_date,120) as ETA
                            from purc_receive_detail a
                            where pur_nbr = '{0}' and pur_seq ='{1}'"
                            , Str採購單,Str採購序號), Conn);
                        myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                    }
                    if (dt.Rows.Count > 0)
                    {
                        PopuGV.DataSource = dt;
                        PopuGV.DataBind();
                        入庫單Panel_ModalPopupExtender.Show();
                    }
                    else
                        F_ErrorShow("無入庫資料");
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
            DataTable dt採購資料 = (DataTable)Session["Sales022Data"];
            string StrError = "";

            if (dt採購資料 == null)
            {
                StrError += "無採購資料";
            }
            if (StrError.Length > 0)
                F_ErrorShow(StrError);
            else
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt採購資料, "採購資料");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "採購資料"));
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

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (Session["Sales022Data"] != null)
                Session["Sales022Data"] = null;
            if (!string.IsNullOrEmpty(MutiTB.Text) || !string.IsNullOrEmpty(款號TB.Text) || !string.IsNullOrEmpty(客戶TB.Text))
            {
                DbInit();
            }
            else
                F_ErrorShow("請輸入搜尋條件:款號/客戶");
        }

        protected void ShowBT_Click(object sender, EventArgs e)
        {
            入庫單Panel_ModalPopupExtender.Show();
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            款號TB.Text = "";
            客戶TB.Text = "";
            MutiTB.Text = "";
            Session["Sales022Data"] = null;
        }
    }
}