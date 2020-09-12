using Kickoff.Filters;
using Kickoff.Models.ContentModels;
using Kickoff.Services.Definitions.Pages;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Kickoff.Controllers
{
    public class HomeController : RenderMvcController
    {
        private readonly IHomeBuilder _homeBuilder;

        public HomeController(IHomeBuilder homeBuilder)
        {
            _homeBuilder = homeBuilder;
        }

        // GET: Home
        [IsUnderMaintenanceActionFilter]
        public ActionResult Index(ContentModel model)
        {
            var homeContentModel = new HomeContentModel(model.Content);

            var pageModel = _homeBuilder.GetModel(model.Content);

            homeContentModel.PageModel = pageModel;
            
            return CurrentTemplate(homeContentModel);
        }
    }
}