using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.FactoryMG
{
    public partial class GAMAIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StitchBT_Click(object sender, EventArgs e)
        {
            Session["Team"] = "Stitch";
            Session["Area"] = "GAMA";
            Response.Redirect("F002.aspx");
        }
    }
}