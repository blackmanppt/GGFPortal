using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance010 : System.Web.UI.Page
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
                Session["Date1"] = DateTime.Now.ToString("yyyyMMdd");
                Session["Date2"] = "29990101";
                Session["site"] = "%";
                Session["vendor_id"] = VendorDDL.SelectedValue;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            int x = 1;
            Session["Date1"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "20000101";
            Session["Date2"] = (EndDay.Text.Length > 0) ? EndDay.Text : "29990101";
            Session["site"] = SiteDDL.SelectedValue;
            Session["vendor_id"] = VendorDDL.SelectedValue;
            ReportViewer1.LocalReport.Refresh();
        }
        
    }
}