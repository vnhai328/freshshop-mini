using System.Web.Mvc;

namespace PrjFresh.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "List", Controller = "RoleController", id = UrlParameter.Optional },
                new[] { "PrjFresh.Areas.Admin.Controllers" }
            );
        }
    }
}