using System.Web.Mvc;

namespace RestaurantPro.Areas.RestaurantAdmin
{
    public class RestaurantAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RestaurantAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RestaurantAdmin_default",
                "RestaurantAdmin/{controller}/{action}/{id}",
                new {Controller="SysAdmin", action = "Index", id = UrlParameter.Optional },
                namespaces:new string[] { "RestaurantPro.Areas.RestaurantAdmin.Controllers" }
            );
        }
    }
}