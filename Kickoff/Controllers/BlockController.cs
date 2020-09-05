using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Kickoff.Models.Block;

namespace Kickoff.Controllers
{
    public class BlockController : SurfaceController
    {
        //private readonly 



        public BlockController()
        {

        }
        // GET: Block
        public ActionResult Header()
        {
            return PartialView("_Header", new HeaderBlockModel());
        }

        public ActionResult Footer()
        {
            return PartialView("_Footer", new FooterBlockModel());
        }
    }
}