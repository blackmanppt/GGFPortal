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

namespace GGFPortal.Sales
{
    public partial class Sales025 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "Search For Grid";
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
            DateTB.Attributes["readonly"] = "readonly";
        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }

            DateTime time;
            if (!DateTime.TryParse(DateTB.Text.Substring(0, 4) + "-" + DateTB.Text.Substring(4, 2) + "-01", out time))
                F_ErrorShow("日期轉換失敗");
            else if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("AMZCap", dt);




                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("月", time.AddMonths(1).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("月1", time.AddMonths(2).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("月2", time.AddMonths(3).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("月3", time.AddMonths(4).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("月4", time.AddMonths(5).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("月5", time.AddMonths(6).ToString("yyyyMM")));
                parameters.Add(new ReportParameter("匯入月份1", time.ToString("MM")));
                parameters.Add(new ReportParameter("匯入月份2", time.AddMonths(-1).ToString("MM")));
                parameters.Add(new ReportParameter("匯入月份3", time.AddMonths(-2).ToString("MM")));
                parameters.Add(new ReportParameter("匯入月份4", time.AddMonths(-3).ToString("MM")));
                ReportViewer1.LocalReport.SetParameters(parameters);

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
            DateTime time;
            StringBuilder strsql = new StringBuilder();
            if (!DateTime.TryParse(DateTB.Text.Substring(0, 4) + "-" + DateTB.Text.Substring(4, 2) + "-01", out time))
                F_ErrorShow("日期轉換失敗");
            else
                strsql.Append($@"select s.model_number as 款號
                    ,v.sumCAP4 前3月CAP1,u.sumCAP3 前2月CAP1,t.sumCAP2 前1月CAP1,s.sumCAP1 本月CAP1
                    ,v.sumCAP5 前3月CAP2,u.sumCAP4 前2月CAP2,t.sumCAP3 前1月CAP2,s.sumCAP2 本月CAP2
                    ,v.sumCAP6 前3月CAP3,u.sumCAP5 前2月CAP3,t.sumCAP4 前1月CAP3,s.sumCAP3 本月CAP3
                    ,u.sumCAP6 前2月CAP4,t.sumCAP5 前1月CAP4,s.sumCAP4 本月CAP4
                    ,t.sumCAP6 前1月CAP5,s.sumCAP5 本月CAP5
                    ,s.sumCAP6 本月CAP6,w.sum1 as 本月sum1,w.sum2 as 本月sum2,w.sum3 as 本月sum3,x.sum2 as 上月sum2,x.sum3 as 上月sum3,y.sum3 as 上2月sum3
                    from (
                    select b.model_number
                    ,sum(capacity_1_units) as sumCAP1
                    ,sum(capacity_2_units) as sumCAP2
                    ,sum(capacity_3_units) as sumCAP3
                    ,sum(capacity_4_units) as sumCAP4
                    ,sum(capacity_5_units) as sumCAP5
                    ,sum(capacity_6_units) as sumCAP6
                    from 

                    AMZCapacityHead a
                    left join AMZCapacityLine b
                    on a.id=b.id and a.IsDeleted=0 and a.IsUpDate=1  and 匯入年月='{time:yyyyMM}'
                    group by

                    b.model_number
                    having model_number is not null
                    ) s left join 

                    (
                    select b.model_number
                    ,sum(capacity_1_units) as sumCAP1
                    ,sum(capacity_2_units) as sumCAP2
                    ,sum(capacity_3_units) as sumCAP3
                    ,sum(capacity_4_units) as sumCAP4
                    ,sum(capacity_5_units) as sumCAP5
                    ,sum(capacity_6_units) as sumCAP6
                    from 

                    AMZCapacityHead a
                    left join AMZCapacityLine b
                    on a.id=b.id and a.IsDeleted=0 and a.IsUpDate=1 and 匯入年月='{time.AddMonths(-1):yyyyMM}'
                    group by

                    b.model_number
                    ) t on s.model_number=t.model_number
                    left join (
                    select b.model_number
                    ,sum(capacity_1_units) as sumCAP1
                    ,sum(capacity_2_units) as sumCAP2
                    ,sum(capacity_3_units) as sumCAP3
                    ,sum(capacity_4_units) as sumCAP4
                    ,sum(capacity_5_units) as sumCAP5
                    ,sum(capacity_6_units) as sumCAP6
                    from 

                    AMZCapacityHead a
                    left join AMZCapacityLine b
                    on a.id=b.id and a.IsDeleted=0 and a.IsUpDate=1 and 匯入年月='{time.AddMonths(-2):yyyyMM}'
                    group by

                    b.model_number
                    ) u on s.model_number=u.model_number
                    left join (
                    select b.model_number
                    ,sum(capacity_1_units) as sumCAP1
                    ,sum(capacity_2_units) as sumCAP2
                    ,sum(capacity_3_units) as sumCAP3
                    ,sum(capacity_4_units) as sumCAP4
                    ,sum(capacity_5_units) as sumCAP5
                    ,sum(capacity_6_units) as sumCAP6
                    from 

                    AMZCapacityHead a
                    left join AMZCapacityLine b
                    on a.id=b.id and a.IsDeleted=0 and a.IsUpDate=1  and 匯入年月='{time.AddMonths(-3):yyyyMM}'
                    group by

                    b.model_number
                    ) v on s.model_number=v.model_number
					left join ViewAMZGuidance w on s.model_number=w.model_number and w.匯入年月='{time:yyyyMM}'
					left join ViewAMZGuidance x on t.model_number=x.model_number and x.匯入年月='{time.AddMonths(-1):yyyyMM}'
					left join ViewAMZGuidance y on u.model_number=y.model_number and y.匯入年月='{time.AddMonths(-2):yyyyMM}'
                ");
            return strsql;
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