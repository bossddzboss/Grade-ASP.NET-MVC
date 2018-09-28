using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Grade.Web.Startup))]
namespace Grade.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
