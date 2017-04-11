using System.Web.Mvc;

namespace RefregeratorRepairSystem.App.Areas.Items
{
    public class ItemsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Items";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
           context.Routes.MapMvcAttributeRoutes();
        }
    }
}