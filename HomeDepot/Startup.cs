using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeDepot.Startup))]
namespace HomeDepot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
