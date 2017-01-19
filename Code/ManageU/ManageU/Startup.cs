using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageU.Startup))]
namespace ManageU
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
