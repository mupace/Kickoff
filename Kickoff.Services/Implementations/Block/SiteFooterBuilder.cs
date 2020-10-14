using Kickoff.Constants.Blocks;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.Services.Implementations.Block
{
    public class SiteFooterBuilder : BaseDocumentBuilder, ISiteFooterBuilder
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SiteFooterBuilder(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public SiteFooterModel GetModel(IPublishedContent currentPage)
        {
            SiteFooterModel model = null;

            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var blockRoot = cref.UmbracoContext.Content.GetByXPath($"//{BlockRoot.DocumentTypeAlias}").FirstOrDefault();

                if (blockRoot != null)
                {
                    var footerNode = blockRoot.Value<IPublishedContent>(BlockRoot.DefaultFooter);

                    model = base.GetModel<SiteFooterModel>(footerNode);

                    model.Title = footerNode.Value<string>(SiteFooter.Title);

                    model.Links = footerNode.Value<IEnumerable<Link>>(SiteFooter.Link).UmbracoLinksToLinkModel();

                    model.FacebookUrl = footerNode.Value<string>(SiteFooter.FacebookUrl);

                    model.TwitterUrl = footerNode.Value<string>(SiteFooter.TwitterUrl);

                    model.GithubUrl = footerNode.Value<string>(SiteFooter.GithubUrl);

                    model.CopyrightText = footerNode.Value<string>(SiteFooter.CopyrightText);

                    model.UseHomepageStyle = currentPage.AncestorOrSelf(1).Id == currentPage.Id;

                    return model;
                }
            }

            return model;
        }
    }
}