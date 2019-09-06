using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.ReferenceCode;
namespace GGFPortal.Sales
{

    public partial class Sales013 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VNNGGFConnectionString"].ToString();
        字串處理 convert = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            下線日StartTB.Attributes["readonly"] = "readonly";
            下線日EndTB.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            下線日StartTB.Text = "";
            下線日EndTB.Text = "";
            TextBox1.Text = "";
            車縫DDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (SearchCheck())
            {
                DbInit();
            }
            else
            {
                F_ErrorShow("請輸入搜尋資料");
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
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("ViewCRP排程表", dt);
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
            
            StringBuilder strsql = new StringBuilder(" select * from [ViewCRP排程表] where 1=1 ");
            //20190903 修改為上線日查詢
            strsql.AppendFormat(" and 上線日 between '{0}' and '{1}' ",
                (!string.IsNullOrEmpty(下線日StartTB.Text))? 下線日StartTB.Text:DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"),
                (!string.IsNullOrEmpty(下線日EndTB.Text))? 下線日EndTB.Text :(!string.IsNullOrEmpty(下線日StartTB.Text))?(Convert.ToDateTime(下線日StartTB.Text)).AddDays(45).ToString("yyyy-MM-dd"):DateTime.Now.AddDays(45).ToString("yyyy-MM-dd"));
            if(車縫DDL.SelectedValue!="")
                if(車縫DDL.SelectedValue== "外廠")
                {
                    strsql.Append(" and 組別代號 like 'B%' ");
                }
                else
                {
                    strsql.AppendFormat(" and 車縫組 like '{0}%' ", 車縫DDL.SelectedValue.Substring(0,1));
                }
            //if(客戶DDL.SelectedValue!="")
            //    strsql.AppendFormat(" and 客戶代號 = '{0}' ", 客戶DDL.SelectedValue);
            if(!string.IsNullOrEmpty(TextBox1.Text))
                strsql.AppendFormat(" and 客戶代號 in  {0} ", convert.逗點字串多筆資料搜尋(TextBox1.Text));
            strsql.AppendFormat(" order by 上線日");
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
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    name += CheckBoxList1.Items[i].Text + ",";
                }
            }
            TextBox1.Text = name;
        }
    }
}