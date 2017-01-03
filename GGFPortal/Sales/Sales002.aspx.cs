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


namespace GGFPortal.Sales
{
    public partial class Sales002 : System.Web.UI.Page
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
                ReportDataSource source = new ReportDataSource("DataSetSales002", Ds.Tables["Shpc"]);
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
            //strwhere += (StyleNoTB.Text.Trim().Length > 0) ? " and c.cus_item_no ='" + StyleNoTB.Text.Trim() + "'" : "";
            strwhere += (Cus_idDDL.SelectedValue.Length > 0) ? string.Format(" and c.agents = '{0}' ", Cus_idDDL.SelectedValue.Replace("'", "'+''''+'")) : "";
            strwhere += (BrandDDL.SelectedValue.Length > 0) ? string.Format(" and c.brand = '{0}' ", BrandDDL.SelectedValue.Replace("'", "'+''''+'")) : "";
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
                                SELECT    c.brand AS 品牌,  c.cus_item_no  as StyleNo,e.employee_name as 業務員, 
                                a.site as 公司別, a.shp_nbr, CASE WHEN open_date IS NULL THEN '' ELSE CONVERT(varchar(8), open_date, 112) 
                                END AS 出貨日, c.agents AS 客戶代號, CASE WHEN so_nbr IS NULL THEN '' ELSE so_nbr END AS S_O, 
                                c.cus_item_no AS style_no, b.cust_po_nbr AS PO_NUMBER, d.vendor_name_brief as 產區,SUM( b.shp_qty) AS 出口數量, 
                                b.sale_price AS FOB, SUM(b.shp_amt) AS 出口金額, a.currency_id AS 幣別, a.exchange_rate AS 匯率, 
                                b.add_reduce_item AS 加減項,f.pre_qty as 訂單數量
                                FROM              dbo.shpc_bah AS a LEFT OUTER JOIN
                                dbo.shpc_bat AS b ON a.site = b.site AND a.kind = b.kind AND a.shp_nbr = b.shp_nbr LEFT OUTER JOIN
                                dbo.ordc_bah1 AS c ON a.ord_nbr = c.ord_nbr AND a.site = c.site LEFT OUTER JOIN
                                dbo.bas_vendor_master AS d ON c.vendor_id = d.vendor_id AND a.site = d.site
                                left join dbo.bas_employee e on c.site=e.site and c.creator=e.employee_no
                                left join dbo.ordc_bat f on b.ord_nbr=f.ord_nbr and b.ord_seq =f.ord_seq
                                WHERE          (a.head_status = 'CL') AND (b.detail_status = 'CL')
                            ";

            sqlstr += strwhere + " group by　c.brand, c.cus_item_no , e.employee_name,  a.site, a.shp_nbr,open_date,c.agents,so_nbr,c.cus_item_no,b.cust_po_nbr,d.vendor_name_brief,b.sale_price,a.currency_id,a.exchange_rate,b.add_reduce_item,f.pre_qty,c.ord_nbr";
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

        protected void Cus_idDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandDDL.Items.Clear();
            BrandDDL.Items.Add("");
        }
    }

    
        
        
        
    }
