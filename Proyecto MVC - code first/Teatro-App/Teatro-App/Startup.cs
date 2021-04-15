using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teatro_App.Startup))]
namespace Teatro_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);            
        }
    }
}
