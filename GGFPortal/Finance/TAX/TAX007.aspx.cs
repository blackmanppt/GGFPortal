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


namespace GGFPortal.Finance.TAX
{
    public partial class TAX007 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (MonthDDL.Items.Count == 0)
            {
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (dtNow.Year - 2015) * 12 + (dtNow.Month - 12);
                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        MonthDDL.Items.Add("");
                    }
                    MonthDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
            }
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("Shpc"))
                    Ds.Tables.Remove("Shpc");
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(Ds, "Shpc");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (Ds.Tables["Shpc"].Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("DataSetTAX", Ds.Tables["Shpc"]);
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
            string strwhere = "";
            string strStartDay, strEndDay;
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "2014-01-01";
            strEndDay = (EndDay.Text.Length > 0) ? EndDay.Text : "2999-01-01";
            strwhere += " and a.open_date between '" + strStartDay + "' and '" + strEndDay + "' ";
            strwhere += (StyleNoTB.Text.Trim().Length > 0) ? " and c.cus_item_no ='" + StyleNoTB.Text.Trim() + "'" : "";
            switch (MonthDDL.SelectedIndex)
            {
                case 1:
                    strwhere += " and a.site = 'GGF' ";
                    break;
                case 2:
                    strwhere += " and a.site = 'TCL' ";
                    break;
                default:
                    break;
            }

            string sqlstr = @"select * from (
                                select a.StyleNo as STYLENO,convert(varchar(10), b.acr_date,111) as ACRDATE,b.cust_po_nbr as PONO
                                ,case when  b.ticket is null then '' else b.ticket end  as TICKET1,'' AS  TICKET2 ,foreign_amt,exchange_rate AS EXCHANGE,base_amt ,0 AS customs_decleartion_amt
                                 ,a.AcrMonthDate
                                 from AcrTax a left join acr_trn_check b on a.uid=b.AcrTaxID  --left join shpc_bat c on b.acr_nbr=c.shp_nbr and b.acr_seq=c.shp_seq
                                where a.Flag=1 and b.acr_status<>'CA'

                                 union all

                                select a.StyleNo as STYLENO,'' as ACRDATE,convert(varchar(10), b.create_date,111) as PONO  
                                ,case when c.decl_no is null then '' else c.decl_no end  as TICKET1,case when c.bol_no is null then '' else c.bol_no end  as   TICKET2 ,0 as foreign_amt,0 AS EXCHANGE, 0 as base_amt , customs_decleartion_amt
                                ,a.AcrMonthDate
                                from AcrTax a left join purc_pkd_for_acr b on a.uid=b.AcrTaxID LEFT JOIN purc_pkm c on b.pak_nbr=c.pak_nbr
                                where a.Flag=1 and b.pkd_status<>'CA' and c.pkm_status<>'CA'
                                ) X
                            ";

            //sqlstr += strwhere + " group by a.site, a.shp_nbr,open_date,c.agents,so_nbr,c.cus_item_no,b.cust_po_nbr,d.vendor_name_brief,b.sale_price,a.currency_id,a.exchange_rate,b.add_reduce_item,c.ord_qty,c.ord_nbr";
            return sqlstr;
        }


        [System.Web.Script.Services.ScriptMethod()]
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
    }

    
        
        
        
    }
