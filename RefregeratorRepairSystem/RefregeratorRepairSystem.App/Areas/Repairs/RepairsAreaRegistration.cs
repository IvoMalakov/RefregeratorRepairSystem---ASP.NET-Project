using System.Web.Mvc;

namespace RefregeratorRepairSystem.App.Areas.Repairs
{
    public class RepairsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Repairs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}