using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GGFPortal.Secretary
{
    public partial class Secretary001 : System.Web.UI.Page
    {
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
            else
            {
                Sercetary001ObjectDataSource.SelectParameters["StartDay"].DefaultValue = DateTime.Now.AddMonths(-1).ToString("yyyyMM") + "01";
                Sercetary001ObjectDataSource.SelectParameters["EndDay"].DefaultValue = DateTime.Now.AddMonths(6).AddDays(-DateTime.Now.AddMonths(6).Day).ToString("yyyyMMdd");
            }

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (StartDay.Text.Length > 0 && EndDay.Text.Length > 0)
            {
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇起訖日期');</script>");
                //ReportViewer1.Visible = false;
            }

        }

        protected void Sercetary001ObjectDataSource_DataBinding(object sender, EventArgs e)
        {

        }
    }
}