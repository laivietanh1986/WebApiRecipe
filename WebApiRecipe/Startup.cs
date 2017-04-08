using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiRecipe.Startup))]
namespace WebApiRecipe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
