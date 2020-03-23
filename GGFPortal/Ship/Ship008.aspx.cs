using AjaxControlToolkit;
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

namespace GGFPortal.Ship
{
    public partial class Ship008 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "訂單多單價查詢", StrProgram = "TempCode.aspx";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
            //    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
            #region query 使用 In
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("createExcelImport");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    #region 查詢
                    string Str搜尋參數 = "cus_item_no";
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@"
SELECT  cus_item_no,0 as 'ord_seq','' as  'Cus_PO',
'' as 'color_cname'
,'' as 'color_ename'
,0 as 'size1_qty',
[size1], 0 as 'size2_qty'
,[size2], 0 as 'size3_qty'
,[size3], 0 as 'size4_qty'
,[size4], 0 as 'size5_qty'
,[size5], 0 as 'size6_qty'
,[size6], 0 as 'size7_qty'
,[size7], 0 as 'size8_qty'
,[size8], 0 as 'size9_qty'
,[size9], 0 as 'size10_qty'
,[size10], 0 as 'size11_qty'
,[size11], 0 as 'size12_qty'
,[size12], 0 as 'size13_qty'
,[size13], 0 as 'size14_qty'
,[size14], 0 as 'size15_qty'
,[size15]
FROM [dbo].[ordc_orders_size_side] a left join ordc_bah1 b on a.site=b.site and a.ord_nbr =b.ord_nbr
where {1} in ( {0} ) and size_flag=2 and input_way=1
union all 
SELECT cus_item_no
,a.[ord_seq],
c.cust_po_nbr,
[color_cname]
,[color_ename]
,[color_qty1],convert(varchar(20),[color_price1])
,[color_qty2],convert(varchar(20),[color_price2])
,[color_qty3],convert(varchar(20),[color_price3])
,[color_qty4],convert(varchar(20),[color_price4])
,[color_qty5],convert(varchar(20),[color_price5])
,[color_qty6],convert(varchar(20),[color_price6])
,[color_qty7],convert(varchar(20),[color_price7])
,[color_qty8],convert(varchar(20),[color_price8])
,[color_qty9],convert(varchar(20),[color_price9])
,[color_qty10],convert(varchar(20),[color_price10])
,[color_qty11],convert(varchar(20),[color_price11])
,[color_qty12],convert(varchar(20),[color_price12])
,[color_qty13],convert(varchar(20),[color_price13])
,[color_qty14],convert(varchar(20),[color_price14])
,[color_qty15],convert(varchar(20),[color_price15])
FROM [dbo].[ordc_ration] a left join ordc_bah1 b on a.site=b.site and a.ord_nbr =b.ord_nbr left join ordc_bat c on a.ord_nbr=c.ord_nbr and a.site=c.site and a.ord_seq=c.ord_seq
where {1} in ( {0} )
                                 ", string.Join(",", parameters), Str搜尋參數);
                    //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    for (int i = 0; i < StrArrary.Length; i++)
                        command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                    transaction1.Rollback();
                    throw;
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                }
            }
            #endregion

            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("訂單多單價", dt);
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

            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            //if (主料CB.Checked)
            //    strsql.Append(" and upper([主副料])  = 'M' ");
            //if (入庫CB.Checked)
            //    strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            return strsql;
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

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}