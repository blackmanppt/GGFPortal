using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GGFOutsidePortal.Startup))]
namespace GGFOutsidePortal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
