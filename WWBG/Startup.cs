using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WWBG.Startup))]
namespace WWBG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
