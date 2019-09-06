using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;

namespace GGFPortal
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
                                            name: "DefaultApi",
                                            routeTemplate: "api/{controller}/{id}",
                                            defaults: new { id = System.Web.Http.RouteParameter.Optional }
                                        );
            //Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);
            //ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
        }
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
    }
}