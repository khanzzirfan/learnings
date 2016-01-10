using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HOLApp1.Startup))]
namespace HOLApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
