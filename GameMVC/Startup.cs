using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameMVC.Startup))]
namespace GameMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
