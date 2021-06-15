using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3Wafii.Startup))]
namespace _3Wafii
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
