using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShop.WebUI3.Startup))]
namespace MyShop.WebUI3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
