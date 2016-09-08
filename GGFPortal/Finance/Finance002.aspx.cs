using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance002 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
            if (Convert.ToInt32(ACPGV.PageIndex) != 0)
            {
                //==如果不加上這行IF判別式，假設當我們看第四頁時， 
                //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
                ACPGV.PageIndex = 0;
            }
            if (IsPostBack)
            {
                DbInit();
            }
            
            
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

        }
        private void DbInit()
        {
            string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            ACPGV.DataBind();
        }
        private string selectsql()
        {
            string strStartDay, strEndDay, strStyleno;
            string strwhere = " where 1 = 1 ";

            strwhere = (SiteDDL.SelectedValue == "全部") ? strwhere : strwhere + " and a.site ='" + SiteDDL.SelectedValue + "'";
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "";
            strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : "";
            strwhere += " and between '" + strStartDay + "' and '" + strEndDay + "' ";

            //string sqlstr = @"SELECT * FROM [ViewACP] ";
            string sqlstr = @"
                                select a.site,
                                dbo.F_NationName(e.site,e.nation_no) as '產區'
                                ,dbo.F_VendorName(d.site,d.vendor_id) as '代工廠'
                                ,a.eta_date,a.etd_date
                                ,g.transatn_term as '交易條件'
                                , c.pur_request_date as '需求日'
                                ,b.rec_date as '入庫日'
                                ,a.rec_qty as '入庫數量'
                                ,a.pur_price as '單價'
                                ,a.rec_qty*a.pur_price as '金額'
                                ,f.employee_name as '業務'
                                ,a.rec_nbr as '入庫單號'
                                ,c.pur_nbr as '採購單號'
                                ,case when a.posted_acp='P' then '已轉應付' else a.posted_acp end  as '是否轉應付'
                                ,h.overage_allow as '允收上限'
                                ,h.item_no
                                ,i.item_name
                                ,c.pur_kind
                                from purc_receive_detail a 
                                left join purc_receive_master b on a.site=b.site and a.rec_nbr=b.rec_nbr and a.kind=b.kind
                                left join purc_purchase_master c on a.site=c.site and a.pur_nbr=c.pur_nbr -- and a.kind=c.pur_kind
                                left join ordc_bah1 d on c.site=d.site and c.ord_nbr=d.ord_nbr
                                left join ordc_bah2 e on d.site=e.site and d.ord_nbr=e.ord_nbr
                                left join bas_employee f on a.site=f.site and b.receiver=f.employee_no
                                left join bas_vendor_mgt g on b.vendor_id=g.vendor_id and b.site=g.site
                                left join purc_purchase_detail h on a.site=h.site and a.pur_nbr=h.pur_nbr and a.pur_seq=h.pur_seq
                                left join bas_item_master i on h.item_no =i.item_no and h.site=i.site
                            ";

            sqlstr +=  strwhere + " ORDER BY [acp_nbr] ";
            return sqlstr;
        }

        protected void ExportBT_Click(object sender, EventArgs e)
        {
            GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(Ds.Tables["ACP"], @"xlsx");
        }
    }
}