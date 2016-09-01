using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance001 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {

            }
            else
            {
                Session["F001StartDay"] = DateTime.Now.ToString("yyyyMMdd");
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (StartDayTB.Text.Length > 0 )
            {
                Session["F001StartDay"] = StartDayTB.Text;
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('日期切換失敗\\請重新選擇');</script>");
                //ReportViewer1.Visible = false;
            }
        }
    }
}