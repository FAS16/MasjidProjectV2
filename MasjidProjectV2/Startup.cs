using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasjidProjectV2.Startup))]
namespace MasjidProjectV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
