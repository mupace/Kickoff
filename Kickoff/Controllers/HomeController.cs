using Kickoff.Services.Definitions.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}