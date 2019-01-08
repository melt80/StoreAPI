using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Store.WebMVC.Startup))]
namespace Store.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
