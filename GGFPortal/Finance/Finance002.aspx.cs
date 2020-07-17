using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance002 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
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
                if (StartDayTB.Text.Length > 0)
                {
                    //EndDayTB_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB.Text.Substring(0, 4) + "/" + StartDayTB.Text.Substring(4, 2) + "/" + StartDayTB.Text.Substring(6, 2));
                    EndDayTB_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB.Text);
                }
                if (EndDayTB.Text.Length > 0)
                {
                    StartDayTB_CalendarExtender.EndDate = Convert.ToDateTime(EndDayTB.Text);
                    //StartDayTB_CalendarExtender.EndDate = Convert.ToDateTime(EndDayTB.Text.Substring(0, 4) + "/" + EndDayTB.Text.Substring(4, 2) + "/" + EndDayTB.Text.Substring(6, 2));
                }
                //DbInit();
                if (SearchVendorID2TB.Text.Length>0)
                {
                    
                }
                //ModalPopupExtender1.Show();
            }
            else
            {
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    FactoryDDL.Items.Clear();
                    NationDDL.Items.Clear();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(" select distinct a.vendor_id,b.vendor_name from ordc_bah1 a left join bas_vendor_master b on a.vendor_id=b.vendor_id order by vendor_name", Conn);
                    myAdapter.Fill(Ds, "Factory");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                    myAdapter.SelectCommand.CommandText = "select distinct a.nation_no,b.nation_name from ordc_bah2 a left join bas_nation b on a.nation_no=b.nation_no where b.nation_name is not null";
                    myAdapter.Fill(Ds, "Nation");
                    for (int i = 1; i < Ds.Tables["Factory"].Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            FactoryDDL.Items.Add("");
                        }
                        ListItem Item = new ListItem();
                        Item.Text = Ds.Tables["Factory"].Rows[i]["vendor_name"].ToString();
                        Item.Value = Ds.Tables["Factory"].Rows[i]["vendor_id"].ToString();
                        FactoryDDL.Items.Add(Item);
                    }
                    for (int i = 1; i < Ds.Tables["Nation"].Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            NationDDL.Items.Add("");
                        }
                        ListItem Item = new ListItem();
                        Item.Text = Ds.Tables["Nation"].Rows[i]["nation_name"].ToString();
                        Item.Value = Ds.Tables["Nation"].Rows[i]["nation_no"].ToString();
                        NationDDL.Items.Add(Item);
                    }
                }
                //SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString1"].ConnectionString.ToString());
            }
            
            
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            //ACPGV.PageIndex = 0;
            //DbInit();
            int icheck = 0;
            icheck += (StartDayTB.Text.Length > 0) ? 1 : 0;
            icheck += (EndDayTB.Text.Length > 0) ? 1 : 0;
            icheck += (PurTB.Text.Length > 0) ? 4 : 0;
            icheck += (StyleNoTB.Text.Length > 0) ? 4 : 0;
            icheck += (OrdNbrTB.Text.Length > 0) ? 4 : 0;
            icheck += (StartDayTB.Text.Length > 0) ? 4 : 0;


            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("ACP"))
                    Ds.Tables.Remove("ACP");
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(Ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if(Ds.Tables["ACP"].Rows.Count>0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("ReportFinance002", Ds.Tables["ACP"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
                //ACPGV.DataSource = Ds.Tables["ACP"];
                //ACPGV.DataBind();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }
        private void DbInit()
        {
            string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            //ACPGV.DataBind();
        }
        private string selectsql()
        {
            string strStartDay, strEndDay;
            string strwhere = "";
            StringBuilder s = new StringBuilder();
            strwhere = (SiteDDL.SelectedValue == "全部") ? strwhere : strwhere + " and a.site ='" + SiteDDL.SelectedValue + "'";
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "2014-01-01";
            strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : "2999-01-01";
            strwhere += " and b.rec_date between '" + strStartDay + "' and '" + strEndDay + "' ";
            strwhere += (NationDDL.SelectedValue.ToString() == "") ? "" : " and e.nation_no ='"+ NationDDL.SelectedValue+"' ";
            strwhere += (FactoryDDL.SelectedValue.ToString() == "") ? "" : " and d.vendor_id ='" + FactoryDDL.SelectedValue + "' ";
            strwhere += (PurTB.Text.Trim().Length > 0) ? " and a.pur_nbr ='" + PurTB.Text.Trim() + "'" : "" ;
            strwhere += (StyleNoTB.Text.Trim().Length > 0) ? " and d.cus_item_no ='"+ StyleNoTB.Text.Trim() + "'" : "";
            strwhere += (OrdNbrTB.Text.Trim().Length > 0) ? " and d.ord_nbr ='" + OrdNbrTB.Text.Trim() + "'" : "";
            strwhere += (VendorTB.Text.Trim().Length > 0) ? " and c.vendor_id ='" + VendorTB.Text.Trim() + "'" : "";
            strwhere += (RecTB.Text.Trim().Length > 0) ? " and a.rec_nbr ='" + RecTB.Text.Trim() + "'" : "";
            
            switch (ETARBL.SelectedValue)
            {
                case "ETA":
                    strwhere += " and a.eta_date is null ";
                    break;
                case "ETD":
                    strwhere += " and a.etd_date is null ";
                    break;
                default:
                    break;
            }
            switch (ItemRBL.SelectedValue)
            {
                case "主料":
                    strwhere += " and c.pur_kind = 'M' ";
                    break;
                case "副料":
                    strwhere += " and c.pur_kind = 'S' ";
                    break;
                default:
                    break;
            }
            switch (ACPRBL.SelectedValue)
            {
                case "已付":
                    strwhere += " and a.posted_acp='P' ";
                    break;
                case "未付":
                    strwhere += " and a.posted_acp ='' ";
                    break;
                default:
                    break;
            }
            string sqlstr = @"
                                select
								a.site,
                                dbo.F_NationName(e.site,e.nation_no) as '產區'
                                ,dbo.F_VendorName(d.site,d.vendor_id) as '代工廠'
                                ,a.rec_nbr as '入庫單號'
                                ,c.pur_nbr as '採購單號'
                                ,g.transatn_term as '交易條件'
								,d.cus_item_no as '款號'
								,h.pur_qty as '採購量'
                                ,c.vendor_id as '廠商代號'
								,a.uncount_qty as '不計價數量'
                                ,m.UnCountQty as '不計價總量'
                                ,CONVERT(varchar(10) ,b.rec_date,111) as '入庫日'
                                ,a.rec_qty as '入庫數量'
								,m.RecQty + m.UnCountQty  as '已入庫量'
								,a.rec_unit as '單位'
                                ,a.pur_price   as '單價'
                                ,a.rec_qty*a.pur_price  as '金額'
                                ,f.employee_name as '業務'
                                ,case when a.posted_acp='P' then 'Y' else 'N' end  as '是否轉應付'
                                ,h.overage_allow as '允收上限'
                                ,h.item_no as '料號'
								,a.org_item_no as '原始料號'
                                ,CONVERT(varchar(10) ,a.eta_date,111) as 'eta_date',CONVERT(varchar(10) ,a.etd_date,111) as 'etd_date'
								,a.qty as '庫存'
                                ,i.item_name as '料號名稱'
                                ,case when c.pur_kind = 'M' then '主料' when c.pur_kind = 'S' then '副料' else c.pur_kind end as '料號別'
                                ,j.color_cname,j.color_ename ,i.item_spk as '英文料號'
                                ,e.transatn_term 訂單交易條件
                                ,k.ddp_qty_per DDP拆分
                                from purc_receive_detail a 
                                left join purc_receive_master b on a.site=b.site and a.rec_nbr=b.rec_nbr and a.kind=b.kind 
                                left join purc_purchase_master c on a.site=c.site and a.pur_nbr=c.pur_nbr 
                                left join ordc_bah1 d on c.site=d.site and c.ord_nbr=d.ord_nbr
                                left join ordc_bah2 e on d.site=e.site and d.ord_nbr=e.ord_nbr
                                left join bas_employee f on a.site=f.site and c.buyer=f.employee_no
                                left join bas_vendor_mgt g on b.vendor_id=g.vendor_id and b.site=g.site
                                left join purc_purchase_detail h on a.site=h.site and a.pur_nbr=h.pur_nbr and a.pur_seq=h.pur_seq
                                left join bas_item_master i on h.item_no =i.item_no and h.site=i.site
                                left join v_color j on h.item_no =j.item_no and h.site=j.site
                                left join ordc_pur_record k on c.site= k.site and c.pur_nbr =k.pur_nbr
                                left join View入庫數量 m on a.site=m.site and a.pur_nbr=m.pur_nbr and a.pur_seq =m.pur_seq
                                where a.rec_detail_status <> 'CA' and b.rec_head_status<>'CA' AND c.pur_head_status<>'CA' and d.bah_status<>'CA'
								and h.pur_detail_status <> 'CA' and i.item_status <>'CA' 
                            ";

            sqlstr +=  strwhere + " ";
            return sqlstr;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //AutoComplete
        public static List<string> SearchVendorID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  vendor_id,vendor_name from bas_vendor_master where (vendor_id like '%'+  @SearchText + '%' or vendor_name like '%'+@SearchText+'%') and  vendor_status<>'CA'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> VendorID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["vendor_id"].ToString(), sdr["vendor_name"].ToString());
                            VendorID.Add(item);
                        }
                    }
                    conn.Close();
                    return VendorID;
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static List<string> SearchPurID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  TOP 10 pur_nbr from purc_receive_detail where rec_detail_status <>'CA' and pur_nbr like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> PurID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            //string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["pur_nbr"].ToString());
                            PurID.Add(sdr["pur_nbr"].ToString());
                        }
                    }
                    conn.Close();
                    return PurID;
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static List<string> SearchStyleNo(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  TOP 10 cus_item_no from ordc_bah1 where bah_status <>'CA'  and cus_item_no like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["cus_item_no"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrdNbr(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  TOP 10 ord_nbr from ordc_bah1 where bah_status <>'CA'  and ord_nbr like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> OrdNbr = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            OrdNbr.Add(sdr["ord_nbr"].ToString());
                        }
                    }
                    conn.Close();
                    return OrdNbr;
                }
            }
        }

        protected void SearchVendorID2_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {

                if(SearchVendorID2.Text.Length>0)
                {
                    string strsql = "select DISTINCT  vendor_id,vendor_name from bas_vendor_master ";
                    string strwhere = " where vendor_id like '%"+ SearchVendorID2TB.Text + "%' or vendor_name like '%" + SearchVendorID2TB.Text + "%'";
                    DataTable DT = new DataTable();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(strsql+ strwhere, Conn);
                    myAdapter.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        VendorGV.DataSource = DT;
                        VendorGV.DataBind();
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入資料');</script>");
                }
            }
            ModalPopupExtender1.Show();
        }

        protected void VendorGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ModalPopupExtender1.Hide();
            //將Ajax的資料丟到其他欄位
            GridViewRow row = VendorGV.Rows[e.NewSelectedIndex];
            VendorTB.Text = row.Cells[1].Text;
            UpdatePanel2.Update();

        }

        protected void SearchVendorIDBT_Click(object sender, ImageClickEventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            FactoryDDL.SelectedIndex = -1;
            NationDDL.SelectedIndex = -1;
            SiteDDL.SelectedIndex = -1;
            ACPRBL.SelectedIndex = -1;
            ETARBL.SelectedIndex = -1;
            ItemRBL.SelectedIndex = -1;
            PurTB.Text = "";
            EndDayTB.Text = "";
            OrdNbrTB.Text = "";
            StartDayTB.Text = "";
            StyleNoTB.Text = "";
            VendorTB.Text = "";
        }
    }
}