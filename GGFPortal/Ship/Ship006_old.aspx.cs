using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GGFPortal.Ship
{
    public partial class Ship006_old : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

            decimal d1 = 0, d2 = 0;
            if (!string.IsNullOrEmpty(StyleTB.Text.Trim()))
            {
                入庫應付LB.BackColor = System.Drawing.Color.White;
                入庫應付LB.ForeColor = System.Drawing.Color.Black;
                入庫暫估LB.BackColor = System.Drawing.Color.White;
                入庫暫估LB.ForeColor = System.Drawing.Color.Black;

                DataTable dt = new DataTable();
                
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(DB1(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                if(dt.Rows.Count>0)
                {
                    
                    d1 = Convert.ToDecimal(dt.Compute("Sum(數量)", "true"));
                    GV1.DataSource = dt;
                    GV1.DataBind();
                }

                DataTable dt2 = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(DB2(), Conn);
                    myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                if (dt2.Rows.Count > 0)
                {
                    d2 = Convert.ToDecimal(dt2.Compute("Sum(數量)", "true"));
                    GV2.DataSource = dt2;
                    GV2.DataBind();
                }
                入庫應付LB.Text = d1.ToString();
                入庫暫估LB.Text = d2.ToString();
                if (d1 > d2)
                {
                    入庫應付LB.BackColor = System.Drawing.Color.Red;
                    入庫應付LB.ForeColor = System.Drawing.Color.Yellow;
                }
                else if (d1 < d2)
                {
                    入庫暫估LB.BackColor = System.Drawing.Color.Red;
                    入庫暫估LB.ForeColor = System.Drawing.Color.Yellow;
                }
            }
            
            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string DB1()
        {
            StringBuilder sb = new StringBuilder(@"
                            select style_no, acp_qty AS 數量, unit_price AS 單價, detail_amt AS 明細金額, CASE WHEN pur_nbr IS NULL 
                            THEN '' ELSE pur_nbr END AS 採購單號, acp_nbr 應付號碼, acp_seq 應付流水號, item_no AS 料品代號, offset_currency AS 立帳幣別  from 
                            (
                                SELECT          acp_nbr+acp_seq as reference_no2,* FROM dbo.acp_trnd WHERE      ( ( (kind = 'AP18') AND (transaction_class = 15)) OR
                                ((kind = 'AP01') AND (transaction_class = 01)))
                            ) a
                            where ( reference_no2 not in (select reference_no from dbo.acp_trnd WHERE (kind = 'AP18') AND (transaction_class = 9) ) )  
                            ");
            sb.AppendFormat(" and style_no ='{0}'", StyleTB.Text);
            if (搜尋主料CB.Checked == true)
            {
                sb.Append(" and item_no like 'F%'");
            }
            return sb.ToString();
        }
        string DB2()
        {
            StringBuilder sb = new StringBuilder(@"
                            select style_no, acp_qty AS 數量, unit_price AS 單價, detail_amt AS 明細金額, CASE WHEN pur_nbr IS NULL 
                            THEN '' ELSE pur_nbr END AS 採購單號, acp_nbr 應付號碼, acp_seq 應付流水號, item_no AS 料品代號, offset_currency AS 立帳幣別 ,unit 單位,remark40
                            FROM dbo.acp_trn WHERE      ( ( (kind = 'AP18') AND (transaction_class = 15)) OR ((kind = 'AP01') AND (transaction_class = 01)))
                            ");
            sb.AppendFormat(" and style_no ='{0}'", StyleTB.Text);
            if (搜尋主料CB.Checked == true)
            {
                sb.Append(" and item_no like 'F%' and len(pur_nbr)>0");
            }
            return sb.ToString();
        }
    }
}