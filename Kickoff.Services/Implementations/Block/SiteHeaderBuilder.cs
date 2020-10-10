using Kickoff.Constants.Blocks;
using Kickoff.Constants.Pages;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Block
{
    public class SiteHeaderBuilder : BaseDocumentBuilder, ISiteHeaderBuilder
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SiteHeaderBuilder(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public SiteHeaderModel GetModel(int pageId)
        {
            SiteHeaderModel model = null;

            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var blockRoot = cref.UmbracoContext.Content.GetByXPath($"//{BlockRoot.DocumentTypeAlias}").FirstOrDefault();

                if (blockRoot != null)
                {
                    var headerNode = blockRoot.Value<IPublishedContent>(BlockRoot.DefaultHeader);

                    model = base.GetModel<SiteHeaderModel>(headerNode);

                    model.MenuTitle = headerNode.Value<string>(SiteHeader.MenuTitle);


                    #region NavigationItems

                    var homePage = cref.UmbracoContext.Content.GetByXPath($"//{Home.DocumentTypeAlias}").FirstOrDefault();
                    
                    //Simple nav - do not go to 2nd level

                    model.Navigation.NavigationItems.Add(homePage.UmbracoNodeToNavigationItem(PageBase.Title));

                    var availableChildren = homePage.Children.Where(x => x.HasProperty(Navigation.HideInHeader) && !x.Value<bool>(Navigation.HideInHeader)).ToList();

                    model.Navigation.NavigationItems.AddRange(availableChildren.Select(x => x.UmbracoNodeToNavigationItem(PageBase.Title)));

                    #endregion

                    model.UseHomepageHeader = homePage.Id == pageId;
                }
            }

            return model;
        }
    }
}