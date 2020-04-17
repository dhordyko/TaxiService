using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaxiNavigator.Startup))]
namespace TaxiNavigator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
