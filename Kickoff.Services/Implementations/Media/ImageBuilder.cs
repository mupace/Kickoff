using Kickoff.Constants.Media;
using Kickoff.Models.Media;
using Kickoff.Services.Definitions.Media;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Media
{
    public class ImageBuilder : BaseDocumentBuilder, IImageBuilder
    {
        public ImageModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<ImageModel>(content);

            model.Alt = content.Value<string>(Image.Alt);

            model.Title = content.Value<string>(Image.Title);

            model.Height = content.Value<int>(Image.UmbracoHeight);

            model.Width = content.Value<int>(Image.UmbracoWidth);

            model.Size = content.Value<int>(Image.UmbracoBytes);

            model.Url = content.Url;

            return model;
        }
    }
}