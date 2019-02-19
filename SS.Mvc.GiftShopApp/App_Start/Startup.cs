using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SS.Mvc.GiftShopApp.Startup))]

namespace SS.Mvc.GiftShopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ContainerConfig.ConfigureDependencyResolver(app);

            ConfigureAuth(app);
        }
    }
}
