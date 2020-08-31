using Kickoff.Models.Media;
using Kickoff.Services.Definitions.Media;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Implementations.Media
{
    public class ImageBuilder : BaseDocumentBuilder, IImageBuilder
    {
        public ImageModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<ImageModel>(content);

            //TODO: Implement model

            return model;
        }
    }
}