using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace GGFPortal.Secretary
{
    public partial class Secretary001V5 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {
                if (StartDay.Text.Length > 0)
                {
                    EndDay_CalendarExtender.StartDate = Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2));
                }
                if (EndDay.Text.Length > 0)
                {
                    StartDay_CalendarExtender.EndDate = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "/" + EndDay.Text.Substring(4, 2) + "/" + EndDay.Text.Substring(6, 2));
                }
            }
            //else
            //{
            //    Sercetary001ObjectDataSource.SelectParameters["StartDay"].DefaultValue = DateTime.Now.AddMonths(-1).ToString("yyyyMM") + "01";
            //    Sercetary001ObjectDataSource.SelectParameters["EndDay"].DefaultValue = DateTime.Now.AddMonths(6).AddDays(-DateTime.Now.AddMonths(6).Day).ToString("yyyyMMdd");

            //}


        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //if (StartDay.Text.Length > 0 && EndDay.Text.Length > 0)
            //{
            //    ReportViewer1.LocalReport.Refresh();
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇起訖日期');</script>");
            //    //ReportViewer1.Visible = false;
            //}
            DBinit();

        }

        protected void Sercetary001ObjectDataSource_DataBinding(object sender, EventArgs e)
        {

        }
        public void DBinit()
        {
            StringBuilder sbstring = new StringBuilder(@"select left(訂單月份,4) 訂單年度,RIGHT(訂單月份,2)訂單月, * from (
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF', salesman, employee_name,OrderBy FROM ViewOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                                    UNION ALL 
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF', salesman, employee_name,OrderBy FROM ViewPreOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                                                        ) a ");
            //StringBuilder sbstring2 = new StringBuilder();
            StringBuilder sbstr1 = new StringBuilder(sbstring.ToString()), sbstr2= new StringBuilder(sbstring.ToString()), sbstr3 = new StringBuilder(sbstring.ToString()), sbstr4 = new StringBuilder();
            //sbstr1.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : DateTime.Now.ToString("yyyyMM") + "00", (!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : DateTime.Now.AddMonths(6).ToString("yyyyMM") + "00");
            sbstr1.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ?
                StartDay.Text : DateTime.Now.ToString("yyyyMM") + "00",
                (!string.IsNullOrEmpty(EndDay.Text)) ?
                    EndDay.Text :
                    (!string.IsNullOrEmpty(StartDay.Text)) ?
                        Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(7).ToString("yyyyMM") + "00" : 
                        DateTime.Now.AddMonths(7).ToString("yyyyMM") + "00"
                );
            //sbstr2.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime( StartDay.Text.Substring(0,4)+"/"+ StartDay.Text.Substring(4, 2)+ "/" + StartDay.Text.Substring(6, 2)).AddMonths(-7).ToString("yyyyMMdd") : DateTime.Now.AddMonths(-7).ToString("yyyyMM") + "00", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(-1).ToString("yyyyMMdd") : DateTime.Now.AddMonths(-1).ToString("yyyyMM") + "00");
            sbstr2.AppendFormat(" where left(訂單日期,4) between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(-1).ToString("yyyy") : DateTime.Now.AddYears(-1).ToString("yyyy"), (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(1).ToString("yyyy") : DateTime.Now.AddYears(1).ToString("yyyy"));
            sbstr3.AppendFormat(" where 訂單日期 like '{0}' ", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(-1).ToString("yyyy")+"%" : DateTime.Now.AddYears(-1).ToString("yyyy") + "%");
            //跨年度不抓兩年資料
            string str結束日期 = "";
            if (!跨年度資料CB.Checked)
            {
                if (!string.IsNullOrEmpty(StartDay.Text))
                {
                    if (!string.IsNullOrEmpty(EndDay.Text))
                    {
                        if (StartDay.Text.Substring(0, 4) != EndDay.Text.Substring(0, 4))
                        {
                            str結束日期 = StartDay.Text.Substring(0, 4) + "12";
                        }
                        else
                            str結束日期 = EndDay.Text.Substring(0, 6);
                    }
                    else
                    {
                        str結束日期 =(Convert.ToInt16( StartDay.Text.Substring(4, 2))>7)? StartDay.Text.Substring(0, 4) + "12" : 
                            Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(7).ToString("yyyyMM");
                    }
                }
                else
                { 
                    if (!string.IsNullOrEmpty(EndDay.Text))
                        str結束日期 =  EndDay.Text.Substring(0, 6);
                    else
                        str結束日期 = (DateTime.Now.Month > 7) ? 
                            DateTime.Now.Year.ToString("yyyy") + "12" 
                            :
                            DateTime.Now.AddMonths(7).ToString("yyyyMM") ;
                }
            }
            else
            {
                str結束日期 = (string.IsNullOrEmpty(EndDay.Text) ) ? 
                    (string.IsNullOrEmpty(StartDay.Text))?
                        DateTime.Now.AddMonths(7).ToString("yyyyMM"): 
                            Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(7).ToString("yyyyMM") : 
                        EndDay.Text.Substring(0,6);
            }
            //檢查起迄時間有沒有報表生成日有差距
            bool bchk = true;
            DateTime startdt = DateTime.Now, enddt= DateTime.Now;

            if (!string.IsNullOrEmpty(StartDay.Text))
            {
                startdt = Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2));
            }
            if (!string.IsNullOrEmpty(EndDay.Text))
            {
                enddt = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "/" + EndDay.Text.Substring(4, 2) + "/" + EndDay.Text.Substring(6, 2)); 
            }
            else
            {
                //預設抓半年的資料
                if (!string.IsNullOrEmpty(StartDay.Text))
                    enddt = Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(7);
            }
            //撈出貨單
            //if (Convert.ToInt32(DateTime.Now.ToString("yyyyMM")) > Convert.ToInt32(startdt.ToString("yyyyMM")) && Convert.ToInt32(DateTime.Now.ToString("yyyyMM")) > Convert.ToInt32(enddt.ToString("yyyyMM")))
            //{
            //    sbstr4.AppendFormat(@"
            //                        select  訂單日期,  訂單月份, x.shp_qty 訂單數量,c.cus_name_brief 'ForMGF' from (
            //                        select  a.site, a.shp_nbr,a.shp_date 訂單日期, '20'+SUBSTRING(a.shp_nbr,3,4) 訂單月份, a.ord_nbr,case when a.ord_cus_id is null then a.cus_id else a.ord_cus_id end as 'ord_cus_id',b.shp_qty 
            //                        from shpc_bah a left join shpc_bat b on a.site=b.site and a.shp_nbr=b.shp_nbr 
            //                        where a.head_status='CL' and b.detail_status='CL' 
            //                        ) x
            //                        left join bas_cus_master c on x.ord_cus_id =c.cus_id and x.site=c.site
            //                        where  訂單月份 between '{0}' and '{1}'
            //                        "
            //        , startdt.ToString("yyyy")+"01"
            //        , str結束日期
            //        );

            //}
            ////撈出訂單
            //else if (Convert.ToInt32(DateTime.Now.ToString("yyyyMM")) <= Convert.ToInt32(startdt.ToString("yyyyMM")) && Convert.ToInt32(DateTime.Now.ToString("yyyyMM")) < Convert.ToInt32(enddt.ToString("yyyyMM")))
            //{
            //    sbstr4.AppendFormat(@"

            //                        SELECT  訂單日期, 訂單月份, 訂單數量, 
            //                        case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF' FROM ViewOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
            //                        where 訂單月份 between '{0}' and '{1}'
            //                        "
            //        , startdt.ToString("yyyyMM")
            //        , str結束日期
            //        //(!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text.Substring(0, 6) : DateTime.Now.AddMonths(6).ToString("yyyyMM")
            //        );
            //}
            //else
            //{
               
            //}
            sbstr4.AppendFormat(@"
                                    select  訂單日期,  訂單月份, x.shp_qty 訂單數量,c.cus_name_brief 'ForMGF' from (
                                    select  a.site, a.shp_nbr,a.shp_date 訂單日期, '20'+SUBSTRING(a.shp_nbr,3,4) 訂單月份, a.ord_nbr,case when a.ord_cus_id is null then a.cus_id else a.ord_cus_id end as 'ord_cus_id',b.shp_qty 
                                    from shpc_bah a left join shpc_bat b on a.site=b.site and a.shp_nbr=b.shp_nbr 
                                    where a.head_status='CL' and b.detail_status='CL' 
                                    ) x
                                    left join bas_cus_master c on x.ord_cus_id =c.cus_id and x.site=c.site
                                    where  訂單月份 between '{0}' and '{1}'
                                    union all
                                    SELECT  訂單日期, 訂單月份, 訂單數量, 
                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF' FROM ViewOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                    where 訂單月份 between '{2}' and '{3}'
                                    union all
                                    SELECT  訂單日期, 訂單月份, 訂單數量, 
                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF' FROM ViewPreOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                    where 訂單月份 between '{2}' and '{3}'
                                    "
                                   , (!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text.Substring(0, 4) + "01" : DateTime.Now.ToString("yyyy") + "01"
                                   //(!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text.Substring(0, 6) : DateTime.Now.AddYears(-1).ToString("yyyy") + "%"
                                   , DateTime.Now.AddMonths(-1).ToString("yyyyMM")
                                   , DateTime.Now.ToString("yyyyMM")
                                   , str結束日期
                                   //(!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text.Substring(0, 6) : DateTime.Now.AddMonths(6).ToString("yyyyMM")
                                   );
            //sbstr4.AppendFormat(" where 訂單日期 between '{0}' and '{1}'",
            //    (!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text.Substring(0, 4) + "0000" : DateTime.Now.ToString("yyyy") + "0000",
            //    str結束日期);

            //sbstr4.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", 
            //    (!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text.Substring(0,4)+"0000" : DateTime.Now.ToString("yyyy") + "0000", 
            //    (跨年度資料CB.Checked)?
            //    (!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : DateTime.Now.AddMonths(6).ToString("yyyyMM") + "00"
            //    :
            //    (!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : DateTime.Now.AddMonths(6).ToString("yyyyMM") + "00" ) ;
            DataTable dt = new DataTable(), dt2 = new DataTable(), dt3 = new DataTable(), dt4 = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                TimeSpan ts月份;
                DateTime dt開始月份=DateTime.Now, dt結束月份;
                int i月數 = 6;

                dt開始月份 =(!string.IsNullOrEmpty(StartDay.Text))? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)):DateTime.Now;
                if (!string.IsNullOrEmpty(EndDay.Text))
                {
                    dt結束月份 = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "/" + EndDay.Text.Substring(4, 2) + "/" + EndDay.Text.Substring(6, 2));
                    ts月份 = dt結束月份 - dt開始月份;
                    i月數 = 12 * (dt結束月份.Year - dt開始月份.Year) + (dt結束月份.Month - dt開始月份.Month);
                }
                else
                    i月數 = 6;
                //新增月份自動填入
                sbstr1.AppendFormat(@" union all
                                    select '' 訂單年度,'' 訂單月,'' 訂單號碼,'' 代理商代號,'' 代理商名稱,'' 客戶名稱,'' 訂單日期,
                                    LEFT( CONVERT(varchar(8), dateadd(M,rows-1,'{0}'),112),6) AS 訂單月份
                                    ,'預設月份' 工廠代號,'預設月份' 工廠名稱,'' 地區,0 訂單數量
                                    ,'預設月份' ForMGF,'' salesman,'' employee_name,'' OrderBy
                                    from 
                                        ( 
                                        select id,row_number()over(order by id) rows  from sysobjects
                                        )
                                    Tmp where Tmp.rows <= {1}
                                    ",  dt開始月份.ToString("yyyy/MM/dd")
                                    , i月數
                                    );
                SqlDataAdapter myAdapter = new SqlDataAdapter(sbstr1.ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                
                SqlDataAdapter myAdapter2 = new SqlDataAdapter(sbstr2.ToString(), Conn);
                myAdapter2.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                SqlDataAdapter myAdapter3 = new SqlDataAdapter(sbstr3.ToString(), Conn);
                myAdapter3.Fill(dt3);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                SqlDataAdapter myAdapter4 = new SqlDataAdapter(sbstr4.ToString(), Conn);
                myAdapter4.Fill(dt4);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("Sercretary001", dt);
                ReportDataSource source2 = new ReportDataSource("SercretaryOldOrder", dt2);
                ReportDataSource source3 = new ReportDataSource("SercretaryLastYearOrder", dt3);
                ReportDataSource source4 = new ReportDataSource("Sercretary001V2", dt4);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.LocalReport.DataSources.Add(source3);
                ReportViewer1.LocalReport.DataSources.Add(source4);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            StartDay.Text = "";
            EndDay.Text = "";
        }
    }
}