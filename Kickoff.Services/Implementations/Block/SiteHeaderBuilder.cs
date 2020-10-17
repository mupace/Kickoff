using Kickoff.Constants.Blocks;
using Kickoff.Constants.Media;
using Kickoff.Constants.Pages;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;
using Kickoff.Services.Definitions.Media;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.Services.Implementations.Block
{
    public class SiteHeaderBuilder : BaseDocumentBuilder, ISiteHeaderBuilder
    {
        private readonly IImageBuilder _imageBuilder;

        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SiteHeaderBuilder(IImageBuilder imageBuilder, IUmbracoContextFactory umbracoContextFactory)
        {
            _imageBuilder = imageBuilder;

            _umbracoContextFactory = umbracoContextFactory;
        }

        public SiteHeaderModel GetModel(IPublishedContent currentPage)
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

                    var homePage = currentPage.AncestorOrSelf(1);// cref.UmbracoContext.Content.GetByXPath($"//{Home.DocumentTypeAlias}").FirstOrDefault();

                    //Simple nav - do not go to 2nd level

                    model.Navigation.NavigationItems.Add(homePage.UmbracoNodeToNavigationItem(PageBase.Title));

                    var availableChildren = homePage.Children.Where(x => x.HasProperty(Navigation.HideInHeader) && !x.Value<bool>(Navigation.HideInHeader)).ToList();

                    model.Navigation.NavigationItems.AddRange(availableChildren.Select(x => x.UmbracoNodeToNavigationItem(PageBase.Title)));

                    #endregion NavigationItems

                    #region HeaderInfo

                    model.UseHomepageHeader = homePage.Id == currentPage.Id;

                    model.HeaderText = currentPage.Value<string>(PageBase.Title);

                    model.SubText = currentPage.Value<string>(PageBase.SubTitle);

                    if (currentPage.HasValue(PageBase.BannerImage))
                    {
                        var cropSize = model.UseHomepageHeader ? ImageCropSizes.HomepageBannerCrop : ImageCropSizes.PageBannerCrop;

                        model.BannerImage = _imageBuilder.GetModel(currentPage.Value<IPublishedContent>(PageBase.BannerImage), cropSize);
                    }

                    if (currentPage.HasProperty(Home.BannerCTA))
                    {
                        model.BannerCTA = currentPage.Value<Link>(Home.BannerCTA)?.UmbracoLinkToLinkModel();
                    }

                    #endregion HeaderInfo
                }
            }

            return model;
        }
    }
}