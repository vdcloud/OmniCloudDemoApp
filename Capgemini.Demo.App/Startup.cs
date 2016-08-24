using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capgemini.Demo.App.Startup))]
namespace Capgemini.Demo.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
