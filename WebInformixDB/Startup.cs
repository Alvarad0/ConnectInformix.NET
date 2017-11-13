using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebInformixDB.Startup))]
namespace WebInformixDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
