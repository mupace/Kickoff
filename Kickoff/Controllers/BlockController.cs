using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;

namespace Kickoff.Controllers
{
    public class BlockController : SurfaceController
    {
        #region Builder Injection
        private ISiteHeaderBuilder _headerBuilder;

        private ISiteHeaderBuilder HeaderBuilder
        {
            get
            {
                if (_headerBuilder == null)
                    _headerBuilder = DependencyResolver.Current.GetService<ISiteHeaderBuilder>();

                return _headerBuilder;
            }
        }

        private ISiteFooterBuilder _footerBuilder;

        private ISiteFooterBuilder FooterBuilder
        {
            get
            {
                if (_footerBuilder == null)
                    _footerBuilder = DependencyResolver.Current.GetService<ISiteFooterBuilder>();

                return _footerBuilder;
            }
        }

        #endregion


        public BlockController()
        {

        }

        // GET: Block
        public ActionResult Header()
        {
            var model = HeaderBuilder.GetModel();

            return PartialView("_Header", model);
        }

        public ActionResult Footer()
        {
            var model = FooterBuilder.GetModel();

            return PartialView("_Footer", model);
        }
    }
}