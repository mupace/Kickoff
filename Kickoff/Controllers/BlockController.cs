using Kickoff.Services.Definitions.Blocks;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace Kickoff.Controllers
{
    public class BlockController : SurfaceController
    {
        #region Fields

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

        private IHighlightBlockBuilder _highlightBlockBuilder;

        private IHighlightBlockBuilder HighlightBlockBuilder
        {
            get
            {
                if (_highlightBlockBuilder == null)
                    _highlightBlockBuilder = DependencyResolver.Current.GetService<IHighlightBlockBuilder>();

                return _highlightBlockBuilder;
            }
        }

        #endregion Builder Injection

        public BlockController()
        {
        }

        // GET: Block
        public ActionResult Header(IPublishedContent currentPage)
        {
            var model = HeaderBuilder.GetModel(currentPage);

            return PartialView("_Header", model);
        }

        public ActionResult Footer(IPublishedContent currentPage)
        {
            var model = FooterBuilder.GetModel(currentPage);

            return PartialView("_Footer", model);
        }

        public ActionResult HighlightBlock(IPublishedContent blockContent)
        {
            var model = HighlightBlockBuilder.GetModel(blockContent);

            if (model == null)
                return null;

            return PartialView("_HighlightBlock", model);
        }
    }
}