using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraphTestApplication2.Startup))]
namespace GraphTestApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
