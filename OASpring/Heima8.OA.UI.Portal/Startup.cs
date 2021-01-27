using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Heima8.OA.UI.Portal.Startup))]
namespace Heima8.OA.UI.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
