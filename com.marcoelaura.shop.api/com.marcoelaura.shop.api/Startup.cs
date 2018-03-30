using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(com.marcoelaura.shop.api.Startup))]

namespace com.marcoelaura.shop.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}