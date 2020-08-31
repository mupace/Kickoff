using Kickoff.Constants.Pages;
using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;


namespace Kickoff.Services.Implementations.Pages
{
    public class NavigationBuilder : INavigationBuilder
    {
        public NavigationModel GetModel(IPublishedContent content)
        {
            var model = new NavigationModel();

            model.HideInHeader = content.Value<bool>(Navigation.HideInHeader);

            model.HideInFooter = content.Value<bool>(Navigation.HideInFooter);

            model.HideInBreadcrumb = content.Value<bool>(Navigation.HideInBreadcrumb);

            model.HideInSitemap = content.Value<bool>(Navigation.HideInBreadcrumb);

            model.HideFromCrawlers = content.Value<bool>(Navigation.HideFromCrawlers);

            return model;
        }
    }
}
