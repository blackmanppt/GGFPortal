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


namespace GGFPortal.Finance
{
    public partial class Finance002V2 : System.Web.UI.Page
    {
        //字串處理 切字串 = new 字串處理();
        //static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        //SysLog Log = new SysLog();
        //string StrError名稱, StrProgram;
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題
            string StrPageName = "暫估應付";
            TitleLB.Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion
            if(!Page.IsPostBack)
            {
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    FactoryDDL.Items.Clear();
                    NationDDL.Items.Clear();

                    SqlDataAdapter myAdapter = new SqlDataAdapter(" select distinct a.vendor_id,b.vendor_name from ordc_bah1 a left join bas_vendor_master b on a.vendor_id=b.vendor_id ", Conn);
                    myAdapter.Fill(Ds, "Factory");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                    myAdapter.SelectCommand.CommandText = "select distinct a.nation_no,b.nation_name from ordc_bah2 a left join bas_nation b on a.nation_no=b.nation_no where b.nation_name is not null";
                    myAdapter.Fill(Ds, "Nation");
                    if(FactoryDDL.Items.Count==0)
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
                    if (FactoryDDL.Items.Count == 0)
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
            }

        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            #region query 使用 In
            //        using (SqlConnection conn1 = new SqlConnection(strConnectString))
            //        {
            //            SqlCommand command1 = conn1.CreateCommand();
            //            SqlTransaction transaction1;
            //            conn1.Open();
            //            transaction1 = conn1.BeginTransaction("createExcelImport");
            //            try
            //            {
            //                command1.Connection = conn1;
            //                command1.Transaction = transaction1;

            //                #region 匯入
            //                string[] parameters = SamArray.Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
            //                command1.CommandText = string.Format(@"SELECT          a.receipt_date AS 發版日期, 
            //                    b.cus_name AS 客戶名稱, a.cus_style_no AS 款號, 
            //                    a.sam_nbr AS 打樣單號, dbo.F_DateToNull(a.samc_fin_date) AS 打版完成日期, 
            //                    a.samc_remark60 AS 備註, a.plan_fin_date AS 預計完成日, 
            //                    a.online_date AS 上線日期, a.samc_plan_fin_date AS 打版預計完成日, 
            //                    a.plan_fin_date AS 預計完日, dbo.F_DateToNull(a.last_date) AS 需求日
            //                    ,dbo.F_DateToNull(a.samc_fin_date) 打版完成日
            //from samc_reqm a left join bas_cus_master b on a.site=b.site and a.cus_id=b.cus_id
            //                     where sam_nbr in ( {0} ) and a.site='GGF'
            //                     ", string.Join(",", parameters));
            //                command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
            //                for (int i = 0; i < SamArray.Length; i++)
            //                    command1.Parameters.AddWithValue(parameters[i], SamArray[i]);
            //                //command1.Parameters.Add("@sam_nbr", SqlDbType.DateTime).Value = DateRangeTB.Text;
            //                command1.ExecuteNonQuery();
            //                SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
            //                dt.Load(dr);
            //                #endregion
            //                //transaction1.Commit();
            //            }
            //            catch (Exception ex)
            //            {
            //                Log.ErrorLog(ex, "上傳失敗", StrProgram);
            //                transaction1.Rollback();
            //                throw;
            //            }
            //            finally
            //            {
            //                conn1.Close();
            //                transaction1.Dispose();
            //            }
            //        }
            #endregion
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("ReportFinance002", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {
            //string strStartDay, strEndDay;
            string strwhere = "";
            StringBuilder sqlstr = new StringBuilder();
            strwhere = (SiteDDL.SelectedValue == "全部") ? strwhere : strwhere + " and a.site ='" + SiteDDL.SelectedValue + "'";
            if(DateRangeTB.Text.Substring(0, 10) != DateRangeTB.Text.Substring(13, 10))
                strwhere += " and b.rec_date between '" + DateRangeTB.Text.Substring(0,10) + "' and '" + DateRangeTB.Text.Substring(13,10) + "' ";
            strwhere += (NationDDL.SelectedValue.ToString() == "") ? "" : " and e.nation_no ='" + NationDDL.SelectedValue + "' ";
            strwhere += (FactoryDDL.SelectedValue.ToString() == "") ? "" : " and d.vendor_id ='" + FactoryDDL.SelectedValue + "' ";
            strwhere += (PurTB.Text.Trim().Length > 0) ? " and a.pur_nbr ='" + PurTB.Text.Trim() + "'" : "";
            strwhere += (StyleNoTB.Text.Trim().Length > 0) ? " and d.cus_item_no ='" + StyleNoTB.Text.Trim() + "'" : "";
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
             sqlstr.AppendFormat(@"
                                select 
								a.site
                                ,m.nation_name as '產區'
                                ,n.vendor_name_brief as '代工廠'
                                ,a.rec_nbr as '入庫單號'
                                ,c.pur_nbr as '採購單號'
                                ,g.transatn_term as '交易條件'
								,d.cus_item_no as '款號'
								,h.pur_qty as '採購量'
                                ,c.vendor_id as '廠商代號'
								,a.uncount_qty as '不計價數量'
                                ,CONVERT(varchar(10) ,b.rec_date,111) as '入庫日'
                                ,a.rec_qty as '入庫數量'
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
																,l.UnCountQty  as '不計價總量'
								,l.acpt_qty as '已入庫量'
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
								left join View入庫數量 l on a.site=l.site and a.pur_nbr=l.pur_nbr and a.pur_seq=l.pur_seq
								left join bas_nation m on e.site=m.site and e.nation_no=m.nation_no
								left join bas_vendor_master n on d.site=n.site and n.vendor_id=d.vendor_id
                                where a.rec_detail_status <> 'CA' and b.rec_head_status<>'CA' AND c.pur_head_status<>'CA' and d.bah_status<>'CA'
								and h.pur_detail_status <> 'CA' and i.item_status <>'CA' 
                                 {0}
                            ", strwhere);
            
            return sqlstr;
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
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            
            DbInit();
            

            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    if (Ds.Tables.Contains("ACP"))
            //        Ds.Tables.Remove("ACP");
            //    StringBuilder sqlstr = selectsql();
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr.ToString(), Conn);
            //    myAdapter.Fill(Ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
            //if (Ds.Tables["ACP"].Rows.Count > 0)
            //{
            //    ReportViewer1.Visible = true;
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //    ReportDataSource source = new ReportDataSource("ReportFinance002", Ds.Tables["ACP"]);
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportViewer1.LocalReport.DataSources.Add(source);
            //    ReportViewer1.DataBind();
            //    ReportViewer1.LocalReport.Refresh();
            //    //ACPGV.DataSource = Ds.Tables["ACP"];
            //    //ACPGV.DataBind();
            //}
            //else
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
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

                if (SearchVendorID2.Text.Length > 0)
                {
                    string strsql = "select DISTINCT  vendor_id,vendor_name from bas_vendor_master ";
                    string strwhere = " where vendor_id like '%" + SearchVendorID2TB.Text + "%' or vendor_name like '%" + SearchVendorID2TB.Text + "%'";
                    DataTable DT = new DataTable();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(strsql + strwhere, Conn);
                    myAdapter.Fill(DT);
                    if (DT.Rows.Count > 0)
                    {
                        VendorGV.DataSource = DT;
                        VendorGV.DataBind();
                    }
                    else
                        F_ErrorShow("搜尋不到資料");
                }
                else
                {
                    F_ErrorShow("請輸入資料");
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
            //EndDayTB.Text = "";
            OrdNbrTB.Text = "";
            //StartDayTB.Text = "";
            StyleNoTB.Text = "";
            VendorTB.Text = "";
        }
    }
}