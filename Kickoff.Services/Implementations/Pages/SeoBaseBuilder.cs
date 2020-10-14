using Kickoff.Constants.Media;
using Kickoff.Constants.Pages;
using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Pages
{
    public class SeoBaseBuilder : ISeoBaseBuilder
    {
        private readonly IImageBuilder _imageBuilder;

        public SeoBaseBuilder(IImageBuilder imageBuilder)
        {
            _imageBuilder = imageBuilder;
        }

        public SeoBaseModel GetModel(IPublishedContent content)
        {
            var model = new SeoBaseModel();

            model.SeoTitle = content.Value<string>(SeoBase.SeoTitle);

            model.SeoDescription = content.Value<string>(SeoBase.SeoDescription);

            model.SeoKeywords = content.Value<string[]>(SeoBase.SeoKeywords);

            if (content.HasValue(SeoBase.SeoImage))
            {
                model.SeoImage = _imageBuilder.GetModel(content.Value<IPublishedContent>(SeoBase.SeoImage), ImageCropSizes.SeoCrop);
            }

            return model;
        }
    }
}