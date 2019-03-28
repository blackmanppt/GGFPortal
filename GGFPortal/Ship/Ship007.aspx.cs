using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Ship
{

    public partial class Ship007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //品牌TB.Text = "";
            款號TB.Text = "";
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
                ReportDataSource source = new ReportDataSource("採購入庫狀況", dt);
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
            string strPur, strStyleno;
            
            strPur = (採購單TB.Text.Trim().Length > 0) ? 採購單TB.Text.Trim() : "";
            strStyleno = (款號TB.Text.Trim().Length > 0) ? 款號TB.Text.Trim() : "";
            StringBuilder sqlstr = new StringBuilder( @"
                                select TOP 1000 x.site,x.cus_item_no,x.pur_nbr,x.exchange_rate,x.org_item_no,y.item_name,x.pur_unit,x.pur_price,sum(x.pur_qty) as 採購數量,sum(x.rqty) as 入庫數量,case when x.chn_yn='Y' then '是' else '否' end as 是否轉三角 from (
                                select a.site, a.cus_item_no,b.pur_nbr,c.pur_seq,b.exchange_rate,c.org_item_no, c.pur_qty ,c.pur_unit,c.pur_price
                                , sum(d.rec_qty) as rqty,b.chn_yn
                                from ordc_bah1 a left join purc_purchase_master b on a.site=b.site and a.ord_nbr=b.ord_nbr
                                left join purc_purchase_detail c on b.site=c.site and b.pur_nbr=c.pur_nbr
                                left join purc_receive_detail d on c.site=d.site and c.pur_nbr=d.pur_nbr and c.pur_seq=d.pur_seq
                                where a.bah_status<>'CA' and b.pur_head_status<>'CA' and c.org_item_no is not null  and c.pur_detail_status<>'CA' and d.rec_detail_status<>'CA'
                            ");

            if (strPur.Length > 0 || strStyleno.Length > 0)
            {
                if (strPur.Length > 0)
                    sqlstr.Append(SplitArray(strPur, "c.pur_nbr"));
                if (strStyleno.Length > 0)
                    sqlstr.Append(SplitArray(strStyleno, "a.cus_item_no"));
            }
            
            sqlstr.Append( @" 
                                group by  a.cus_item_no,b.pur_nbr,c.pur_seq,b.exchange_rate,c.org_item_no ,c.site,c.pur_unit,c.pur_price,a.site,c.pur_qty,b.chn_yn
                                ) as x left join bas_item_master y on x.site=y.site and x.org_item_no=y.item_no
                            group by x.site,cus_item_no,pur_nbr,exchange_rate,org_item_no,pur_unit,pur_price,y.item_name,x.chn_yn");
            return sqlstr;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            if (!string.IsNullOrEmpty(款號TB.Text.Trim()))
                bCheck = true;
            if (!string.IsNullOrEmpty(採購單TB.Text.Trim()))
                bCheck = true;
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
        private string SplitArray(string strtext, string strType)
        {
            string[] strtextarry = SplitEnter(strtext);
            string strwhere="";
            if (strtextarry.Length > 1)
            {
                string strIn = " and " + strType + " in ( ";
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (i == 0)
                            strIn += " '" + strtextarry[i].Trim() + "' ";
                        else
                            strIn += " ,'" + strtextarry[i].Trim() + "' ";
                }
                strIn += " ) ";
                strwhere += strIn;
            }
            else
                strwhere += " and " + strType + " = '" + strtext + "' ";
            return strwhere;
        }

        private string GetDateString(string strtext)
        {
            string[] words = strtext.Split('/');
            string rstr = "";
            foreach (string s in words)
            {
                rstr = (s.Length < 2) ? rstr + "0" + s : rstr + s;
            }
            return rstr;
        }
        private string[] SplitEnter(string strPur)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = strPur.Split(stringSeparators, StringSplitOptions.None);
            return lines;
        }

    }
}