using System.Web;
using System.Web.Routing;

namespace WaterpoloScoring
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RavenDbConfig.Initialize();
            SagaConfig.Initialize();
        }
    }
}
