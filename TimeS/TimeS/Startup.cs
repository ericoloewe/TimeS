using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeS.Startup))]
namespace TimeS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
