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
    public partial class Finance004 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {
            }
            else
            {
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
                ReportDataSource source = new ReportDataSource("Finance004", Ds.Tables["Shpc"]);
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
            switch (SiteDDL.SelectedIndex)
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

            string sqlstr = @"
                                SELECT          
                                a.site as 公司別, a.shp_nbr, CASE WHEN open_date IS NULL THEN '' ELSE CONVERT(varchar(8), open_date, 112) 
                                END AS 開航日, c.agents AS 客戶, CASE WHEN so_nbr IS NULL THEN '' ELSE so_nbr END AS S_O, 
                                c.cus_item_no AS style_no, b.cust_po_nbr AS PO_NUMBER, d.vendor_name_brief as 工廠,SUM( b.shp_qty) AS 出貨數量, 
                                b.sale_price AS 出貨單價, SUM(b.shp_amt) AS 出貨金額, a.currency_id AS 幣別, a.exchange_rate AS 匯率, 
                                b.add_reduce_item AS 加減項,c.ord_qty as 訂單總數,
                                (SELECT distinct cast(y.vendor_name_brief AS NVARCHAR ) + ',' from purc_purchase_master x LEFT JOIN bas_vendor_master y on x.site=y.site and x.vendor_id=y.vendor_id
                                where ord_nbr = c.ord_nbr and pur_head_status<>'CA'  and pur_kind='M'
                                FOR XML PATH('')) as 廠商名稱
                                FROM              dbo.shpc_bah AS a LEFT OUTER JOIN
                                dbo.shpc_bat AS b ON a.site = b.site AND a.kind = b.kind AND a.shp_nbr = b.shp_nbr LEFT OUTER JOIN
                                dbo.ordc_bah1 AS c ON a.ord_nbr = c.ord_nbr AND a.site = c.site LEFT OUTER JOIN
                                dbo.bas_vendor_master AS d ON c.vendor_id = d.vendor_id AND a.site = d.site
                                WHERE          (a.head_status = 'CL') AND (b.detail_status = 'CL')
                            ";

            sqlstr += strwhere + " group by a.site, a.shp_nbr,open_date,c.agents,so_nbr,c.cus_item_no,b.cust_po_nbr,d.vendor_name_brief,b.sale_price,a.currency_id,a.exchange_rate,b.add_reduce_item,c.ord_qty,c.ord_nbr";
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
