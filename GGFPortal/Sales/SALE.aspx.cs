using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class SALE : System.Web.UI.Page
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
                Session["StartDay"] = DateTime.Now;
                Session["EndDay"] = DateTime.Now.AddYears(3);
                ////Session["F001Site"] = "%";
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Session["StartDay"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "1900-01-01";
            //Session["EndDay"] = (EndDay.Text.Length > 0) ? EndDay.Text : "2999-12-31";
            //switch (SiteDDL.SelectedIndex)
            //{
            //    case 1:
            //        Session["F001Site"] = "GGF";
            //        break;
            //    case 2:
            //        Session["F001Site"] = "TCL";
            //        break;
            //    default:
            //        Session["F001Site"] = "%";
            //        break;
            //}
            Session["StartDay"] = DateTime.Now;
            Session["EndDay"] = DateTime.Now.AddYears(3);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}