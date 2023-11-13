using System.Web.Mvc;

namespace TestTemplate.Areas.Admin
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
                "Admin",
                new { controller = "ThongKe", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_with_params",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}