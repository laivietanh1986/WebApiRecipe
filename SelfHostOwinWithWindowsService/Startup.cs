using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace SelfHostOwinWithWindowsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(name:"DefaultApiRoute",routeTemplate:"api/{controller}/{id}",defaults:new {id=RouteParameter.Optional});
            appBuilder.UseWebApi(configuration);
        }
    }
}
