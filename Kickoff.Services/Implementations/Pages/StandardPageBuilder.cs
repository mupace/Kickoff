using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using System;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Implementations.Pages
{
    public class StandardPageBuilder : PageBaseBuilder, IStandardPageBuilder
    {
        public StandardPageBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder) : base(navigationBuilder, seoBaseBuilder)
        {
        }

        public StandardPageModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<StandardPageModel>(content);

            

            return model;
        }
    }
}