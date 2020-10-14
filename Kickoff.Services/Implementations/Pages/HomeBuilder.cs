using Kickoff.Constants.Pages;
using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Pages
{
    public class HomeBuilder : PageBaseBuilder, IHomeBuilder
    {
        public HomeBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder) : base(navigationBuilder, seoBaseBuilder)
        {
        }

        public HomeModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<HomeModel>(content);

            model.UnderMaintenance = content.Value<bool>(Home.UnderMaintenance);

            return model;
        }
    }
}