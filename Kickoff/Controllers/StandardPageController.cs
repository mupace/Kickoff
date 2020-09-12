using Kickoff.Filters;
using Kickoff.Models.ContentModels;
using Kickoff.Services.Definitions.Pages;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Kickoff.Controllers
{
    public class StandardPageController : RenderMvcController
    {
        private readonly IStandardPageBuilder _standardPageBuilder;

        public StandardPageController(IStandardPageBuilder standardPageBuilder)
        {
            _standardPageBuilder = standardPageBuilder;
        }

        // GET: StandardPage
        [IsUnderMaintenanceActionFilter]
        public ActionResult Index(ContentModel model)
        {
            var pageModel = new StandardPageContentModel(model.Content);

            pageModel.PageModel = _standardPageBuilder.GetModel(model.Content);

            return CurrentTemplate(pageModel);
        }
    }
}