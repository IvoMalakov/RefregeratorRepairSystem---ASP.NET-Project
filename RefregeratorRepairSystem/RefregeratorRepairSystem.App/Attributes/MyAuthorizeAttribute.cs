namespace RefregeratorRepairSystem.App.Attributes
{
    using System.Linq;
    using System.Web.Mvc;

    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');

            if (filterContext.HttpContext.Request.IsAuthenticated && !roles.Any(r => filterContext.HttpContext.User.IsInRole(r)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/UnAuthorizeResult.cshtml"
                };
            }

            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}