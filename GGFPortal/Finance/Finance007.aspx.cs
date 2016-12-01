using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance007 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {

            }
            else
            {
                Session["F001StartDay"] = DateTime.Now.ToString("yyyyMMdd");
                Session["F001EndDay"] = "29990101";
                Session["F001Site"] = "%";
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Session["F001StartDay"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "20000101";
            Session["F001EndDay"] = (EndDay.Text.Length > 0) ? EndDay.Text : "29990101";
            switch (SiteDDL.SelectedIndex)
            {
                case 1:
                    Session["F001Site"] = "GGF";
                    break;
                case 2:
                    Session["F001Site"] = "TCL";
                    break;
                default:
                    Session["F001Site"] = "%";
                    break;
            }
            ReportViewer1.LocalReport.Refresh();
        }
    }
}