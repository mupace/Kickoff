using Kickoff.Constants.Pages;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.ActionFilters
{
    public class IsUnderMaintenanceActionFilter : ActionFilterAttribute
    {
        public IsUnderMaintenanceActionFilter()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var contentModelParameter = filterContext.ActionParameters.FirstOrDefault(x => x.Value.GetType() == typeof(ContentModel));

            if (contentModelParameter.Key != null)
            {
                var model = ((ContentModel)contentModelParameter.Value).Content;

                var root = model.AncestorOrSelf(1);

                //Check if it is home node
                if (root.ContentType.Alias == Home.DocumentTypeAlias)
                {
                    var isUnderMaintanence = root.Value<bool>(Home.UnderMaintenance);

                    if (isUnderMaintanence)
                    {
                        var maintenancePage = root.Children.FirstOrDefault(x => x.ContentType.Alias == UnderMaintenance.DocumentTypeAlias);

                        if(maintenancePage == null)
                        {
                            //Maintenance page is expected to be under home, if not it is considered a design error - hence 500
                            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            filterContext.HttpContext.Response.Redirect("~/500.html");
                        }

                        filterContext.HttpContext.Response.Redirect(maintenancePage.Url);
                    }
                        
                }
            }
        }
    }
}