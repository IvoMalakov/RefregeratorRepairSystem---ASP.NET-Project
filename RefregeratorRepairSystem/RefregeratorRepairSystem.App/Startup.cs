using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RefregeratorRepairSystem.App.Startup))]
namespace RefregeratorRepairSystem.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
