using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.VN
{
    public partial class VNTest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Date1"] = (TextBox1.Text == "") ? "19000101" : TextBox1.Text;
            Session["Date2"] = (TextBox2.Text == "") ? "29000101" : TextBox2.Text;
        }
    }
}