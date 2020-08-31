using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Implementations.Pages
{
    public class HomeBuilder : PageBaseBuilder, IHomeBuilder
    {
        public HomeBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder) : base(navigationBuilder, seoBaseBuilder)
        {
        }

        public HomeModel GetModel(IPublishedContent content)
        {
            var model = (HomeModel)base.GetModel(content);

            return model;
        }
    }
}