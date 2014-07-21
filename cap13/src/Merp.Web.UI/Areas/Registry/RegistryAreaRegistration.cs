using System.Web.Mvc;

namespace Merp.Web.UI.Areas.Registry
{
    public class RegistryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Registry";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Registry_default",
                "Registry/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Merp.Web.UI.Areas.Registry" }
            );
        }
    }
}