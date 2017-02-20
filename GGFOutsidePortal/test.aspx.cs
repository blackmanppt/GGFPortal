using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFOutsidePortal.Models;


namespace GGFOutsidePortal
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var mag= Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //Label1.Text = HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)().FindById(HttpContext.Current.User.Identity.GetUserId);

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            GGFUser user = manager.FindById(User.Identity.GetUserId());
            Label1.Text = user.dept;
            

        }
    }
}