using System.Web.Mvc;

namespace RefregeratorRepairSystem.App.Areas.Parts
{
    public class PartsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Parts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}