using Kickoff.Constants.Pages;
using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Pages
{
    public class PageBaseBuilder : BaseDocumentBuilder
    {
        #region Fields

        protected readonly INavigationBuilder _navigationBuilder;

        protected readonly ISeoBaseBuilder _seoBaseBuilder;

        #endregion

        public PageBaseBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder)
        {
            _navigationBuilder = navigationBuilder;
            _seoBaseBuilder = seoBaseBuilder;
        }

        public T GetModel<T>(IPublishedContent content) where T : PageBaseModel, new()
        {
            var model = base.GetModel<T>(content);

            model.Navigation = _navigationBuilder.GetModel(content);

            model.SeoBase = _seoBaseBuilder.GetModel(content);

            return model;
        } 

    }
}
