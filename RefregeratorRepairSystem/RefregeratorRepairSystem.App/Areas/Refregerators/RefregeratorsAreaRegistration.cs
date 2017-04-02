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
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}