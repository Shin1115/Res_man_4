using System.Web.Mvc;

namespace Res_man_4.Areas.Admin
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
                "Admin_Login",
                "Admin/Login",
                new {Controller="Auth", action = "Login", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_Logout",
                "Admin/Logout",
                new { Controller = "Auth", action = "logout", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{Controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}