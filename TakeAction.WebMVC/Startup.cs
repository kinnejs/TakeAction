using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TakeAction.WebMVC.Startup))]
namespace TakeAction.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
