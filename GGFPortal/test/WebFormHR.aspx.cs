using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.ReferenceCode;
namespace GGFPortal.test
{
    public partial class WebFormHR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SystemFunction systemFunction = new SystemFunction();
            systemFunction.SendMail("stone.lee@greatg.com.tw", "send mail", "mail");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SystemFunction systemFunction = new SystemFunction();
            systemFunction.SendMail("stone.lee@greatg.com.tw", "send mail", "mail");
        }
    }
}