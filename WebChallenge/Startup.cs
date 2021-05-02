using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebChallenge.Startup))]
namespace WebChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
