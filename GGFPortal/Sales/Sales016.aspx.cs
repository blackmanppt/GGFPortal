using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
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
    public partial class Sales016 : System.Web.UI.Page
    {
        字串處理 切字串 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        string StrError名稱, StrProgram;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題
            //網頁標題
            string StrPageName = "布價歷史資料查詢", StrProgram = "Sales016.aspx";
            TitleLB.Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }

        protected void RemarkShowBT_Click(object sender, EventArgs e)
        {
            RemarkPanel_ModalPopupExtender.Show();
            
        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (dt.Rows.Count > 0)
            {
                TempRV.Visible = true;
                TempRV.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("主料資料查詢", dt);
                TempRV.LocalReport.DataSources.Clear();
                TempRV.LocalReport.DataSources.Add(source);
                TempRV.DataBind();
                TempRV.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(@" select  ordc_bah1.cus_item_no as 款號,bas_vendor_master.vendor_name_brief 供應商簡稱,bas_item_master.item_spk 料品規格,purc_purchase_master.currency_id 幣別,
                                                            purc_purchase_detail.pur_price 採購單價,sum(purc_purchase_detail.pur_qty) 採購總數量,purc_purchase_detail.pur_unit 單位
                                                            from bas_item_master,bas_vendor_master,purc_purchase_master,ordc_bah1,purc_purchase_detail
                                                            where ordc_bah1.ord_nbr =purc_purchase_master.ord_nbr and ordc_bah1.site =purc_purchase_master.site
                                                            and purc_purchase_master.pur_nbr = purc_purchase_detail.pur_nbr and purc_purchase_master.site = purc_purchase_detail.site
                                                            and purc_purchase_detail.org_item_no = bas_item_master.item_no and purc_purchase_detail.site = bas_item_master.site
                                                            and purc_purchase_master.vendor_id = bas_vendor_master.vendor_id and purc_purchase_master.site = bas_vendor_master.site
                                                            and purc_purchase_master.pur_kind='M'
                                                            and purc_purchase_master.pur_head_status <> 'CA'
                                                         
            ");
            if (!string.IsNullOrEmpty(成分DDL.SelectedValue))
                strsql.AppendFormat(" and  upper(purc_purchase_detail.org_item_no)  like '{0}%' ", 成分DDL.SelectedValue.ToUpper());
            if (!string.IsNullOrEmpty(布種DDL.SelectedItem.Text))
                strsql.AppendFormat(" and upper(purc_purchase_detail.org_item_no)  like '%{0}%' ", 布種DDL.SelectedValue.ToUpper());
            if (!string.IsNullOrEmpty(供應商TB.Text))
                strsql.AppendFormat(" and (upper( purc_purchase_master.vendor_id )  = '{0}'  or bas_vendor_master.vendor_name_brief = '{0}')", 供應商TB.Text.ToUpper());
            if (!string.IsNullOrEmpty(客戶代號TB.Text))
                strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 客戶代號TB.Text.ToUpper());
            if (!string.IsNullOrEmpty(採購日期TB.Text))
                strsql.AppendFormat(" and purc_purchase_master.pur_date between '{0}' and '{1}' ", 採購日期TB.Text.Substring(0, 10).ToUpper(), 採購日期TB.Text.Substring(採購日期TB.Text.Length - 10, 10).ToUpper());
            if (!string.IsNullOrEmpty(布種規格TB.Text))
                strsql.AppendFormat(" and ( {0} )", 切字串.逗點字串模糊搜尋("bas_item_master.item_spk", 布種規格TB.Text.ToUpper()).ToString());
            strsql.Append(@" group by ordc_bah1.cus_item_no,bas_vendor_master.vendor_name_brief,bas_item_master.item_spk,purc_purchase_master.currency_id,
                            purc_purchase_detail.pur_price, purc_purchase_detail.pur_unit ");
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = true;
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
            if (!string.IsNullOrEmpty(採購日期TB.Text))
                try
                {
                    DateTime dt1, dt2;
                    dt1 = Convert.ToDateTime(採購日期TB.Text.Substring(0, 10).ToUpper());
                    dt2 = Convert.ToDateTime(採購日期TB.Text.Substring(採購日期TB.Text.Length - 10, 10).ToUpper());
                }
                catch (Exception)
                {
                    bCheck = false;
                    throw;
                }

            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}