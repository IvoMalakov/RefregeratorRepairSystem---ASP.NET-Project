using System.Web.Mvc;

namespace RefregeratorRepairSystem.App.Areas.Refregerators
{
    public class RefregeratorsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Refregerators";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Refregerators_default",
                "Refregerators/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}