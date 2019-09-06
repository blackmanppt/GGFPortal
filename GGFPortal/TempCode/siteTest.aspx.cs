using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.TempCode
{
    public partial class siteTest : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Title = "test1234";
            Button xx = (Button)Master.FindControl("Button5");
            xx.Text = "test5";
        }

        protected void Page_Load(object sender, EventArgs e)
        {




        }
    }
}