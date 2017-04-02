using System.Web.Mvc;

namespace RefregeratorRepairSystem.App.Areas.Airconditioners
{
    public class AirconditionersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Airconditioners";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}