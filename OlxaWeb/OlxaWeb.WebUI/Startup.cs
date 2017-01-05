using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OlxaWeb.WebUI.Startup))]
namespace OlxaWeb.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
