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
    public partial class Sales021 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "德永佳採購單匯出", StrProgram = "Sales021.aspx";
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
            DataTable dt振大主表 = new DataTable(),dt振大布類 =new DataTable(),dt振大顏色 =new DataTable();
            string StrError = "";
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("振大主表").ToString(), Conn);
                myAdapter.Fill(dt振大主表);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                myAdapter.SelectCommand.CommandText = selectsql("振大布類").ToString();
                myAdapter.Fill(dt振大布類);
                myAdapter.SelectCommand.CommandText = selectsql("振大顏色").ToString();
                myAdapter.Fill(dt振大顏色);
            }

            if (dt振大主表 == null)
            {
                StrError += "振大主表無資料<br/>";
            }
            if(dt振大布類==null)
            {
                StrError += "振大布料無資料<br/>";
            }
            if (dt振大布類 == null)
            {
                StrError += "振大布類無資料";
            }
            if (StrError.Length>0)
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
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", StyleNoTB.Text.ToUpper().Trim()));
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

        private StringBuilder selectsql(string Str搜尋條件)
        {
            StringBuilder strsql = new StringBuilder();
            switch (Str搜尋條件)
            {
                case "振大主表":
                    strsql.AppendFormat(@"select b.cus_name_brief 客戶名稱,a.season 季節,a.season_y 季節年度,item_statistic_name 款式
                        ,(select pur_nbr+',' from purc_purchase_master where ord_nbr =a.ord_nbr and vendor_id='F0173'  FOR XML PATH('')) as 採購單  ,cus_item_no as 款號
                        from ordc_bah1 a 
                        left join bas_cus_master b on a.site=b.site and a.agents=b.cus_id
                        left join bas_item_statistic c on a.site=c.site and a.item_statistic=c.item_statistic
                        where cus_item_no ='{0}'",StyleNoTB.Text.ToUpper().Trim());
                    break;
                case "振大布類":
                    strsql.AppendFormat(@"select  
                        a.pur_nbr 採購單,
                        c.cus_item_no 款號,
                        d.item_spk 料號規格,
                        sum(a.pur_qty) as 採購數量,
                        b.currency_id 幣別,a.pur_unit 單位,
                        b.pur_total_amt 採購金額,
                        a.pur_price 採購單價,
                        a.cloth_g_weight 克重
                        ,'GM/M2' 重量單位
                        ,e.cloth_width 幅寬
                        from purc_purchase_detail a left join purc_purchase_master b on a.site=b.site and a.pur_nbr=b.pur_nbr
                        left join ordc_bah1 c on a.site=c.site and a.ord_nbr=c.ord_nbr
                        left join bas_item_master d on a.org_item_no=d.item_no and a.site=d.site
                        left join ordc_material e on a.ord_nbr=e.ord_nbr and a.site=e.site and a.org_item_no =e.item_no AND b.vendor_id=e.vendor_id
                        where b.vendor_id='F0173' and cus_item_no ='{0}' and a.pur_detail_status <>'CA'
                        group by
                        a.pur_nbr,
                        c.cus_item_no,
                        b.pur_total_amt,
                        a.pur_price,
                        a.cloth_g_weight,
                        d.item_spk,b.currency_id
                        ,a.pur_unit,e.cloth_width", StyleNoTB.Text.ToUpper().Trim());
                    break;
                case "振大顏色":
                    strsql.AppendFormat(@"select 
                        a.pur_nbr 採購單,a.pur_seq 採購單流水號,c.cus_item_no 款號,e.color_ename 顏色,a.pur_qty 採購數量,a.pur_unit 採購單位
                        ,a.overage_allow 允收上限,a.shortage_allow 允收下限,'%' as 上下限單位
                        ,a.pur_price 採購單價,b.currency_id 採購幣別,a.pur_amt 採購金額
                        from purc_purchase_detail a left join purc_purchase_master b on a.site=b.site and a.pur_nbr=b.pur_nbr
                        left join ordc_bah1 c on a.site=c.site and a.ord_nbr=c.ord_nbr
                        left join bas_item_master d on a.item_no=d.item_no and a.site=c.site
                        left join ordc_orders_color e on a.site=e.site and a.ord_nbr=e.ord_nbr and d.color_id=e.color_id
                        where b.vendor_id='F0173' and cus_item_no ='{0}' and a.pur_detail_status <>'CA'
                        order by a.pur_nbr,a.pur_seq
                        ", StyleNoTB.Text.ToUpper().Trim());
                    break;
                case "訂單資料":
                    strsql.AppendFormat(@"select a.cus_item_no,a.manual_qty,cus_name_brief,c.employee_name,MappingData as 訂單狀態,d.vendor_name_brief,a.brand from ordc_bah1 a 
                        left join view_bas_cus_master b on a.site=b.site and a.agents=b.cus_id
                        left join bas_employee c on a.site=c.site and a.salesman=c.employee_no
                        left join bas_vendor_master d on a.site=d.site and a.vendor_id =d.vendor_id
                        left join Mapping e on a.bah_status=e.Data and e.UsingDefine='OrderStatus'
                        where a.cus_item_no='{0}'
                        ", StyleNoTB.Text.ToUpper().Trim());
                    break;
                case "採購單資料":
                    strsql.AppendFormat(@"select a.pur_nbr as 採購單號,a.pur_kind as 主副料別,b.vendor_name_brief as 工廠,a.vendor_id as 工廠代號
                        ,a.currency_id as 幣別,a.exchange_rate as 匯率,pur_total_amt 採購金額,MappingData as 採購單狀態 from purc_purchase_master a 
                        left join bas_vendor_master b on a.vendor_id=b.vendor_id and a.site=b.site
                        left join Mapping c on a.pur_head_status=c.Data and c.UsingDefine='PurOrd'
                        where a.ord_nbr = (select top 1 ord_nbr from ordc_bah1 where cus_item_no='{0}')
                        ", StyleNoTB.Text.ToUpper().Trim());
                    break;
                default:
                    break;
            }
            return strsql;
        }


        protected void ExportBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DataTable dt訂單資料 = new DataTable(), dt採購單資料 = new DataTable();
            string StrError = "";
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("訂單資料").ToString(), Conn);
                myAdapter.Fill(dt訂單資料);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                myAdapter.SelectCommand.CommandText = selectsql("採購單資料").ToString();
                myAdapter.Fill(dt採購單資料);

            }
            if (dt訂單資料.Rows.Count > 0)
            {
                foreach (DataRow item in dt訂單資料.Rows)
                {
                    款號LB.Text = "款號：" + item["cus_item_no"].ToString();
                    客戶品牌LB.Text = "客戶品牌：" + item["brand"].ToString();
                    訂單狀態LB.Text = "訂單狀態：" + item["訂單狀態"].ToString();
                    業務人員LB.Text = "業務人員：" + item["employee_name"].ToString();
                    訂單數量LB.Text = "訂單數量：" + item["manual_qty"].ToString();
                    代工廠LB.Text = "代工廠：" + item["vendor_name_brief"].ToString();
                }
            }
            else
                StrError = "訂單無資料<br/>";

            if (dt採購單資料.Rows.Count > 0)
            {
                採購單GV.DataSource = dt採購單資料;
                採購單GV.DataBind();
                DataView dv = new DataView(dt採購單資料);
                dv.RowFilter = "工廠 = '德永佳'";

                ExportBT.Visible = (dv.Count > 0) ? true : false;

            }
            else
                StrError += "採購單無資料";
            if (StrError.Length > 0)
                F_ErrorShow(StrError);
        }

        public void F_ErrorShow(string strError)
        {
            ExportBT.Visible = false;
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}