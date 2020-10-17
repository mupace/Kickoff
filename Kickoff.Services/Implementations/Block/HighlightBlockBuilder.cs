using Kickoff.Constants;
using Kickoff.Constants.Blocks;
using Kickoff.Constants.Media;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;
using Kickoff.Services.Definitions.Media;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Block
{
    public class HighlightBlockBuilder : BaseDocumentBuilder, IHighlightBlockBuilder
    {
        private readonly IImageBuilder _imageBuilder;

        public HighlightBlockBuilder(IImageBuilder imageBuilder)
        {
            _imageBuilder = imageBuilder;
        }

        public HighlightBlockModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<HighlightBlockModel>(content);

            model.Title = content.Value<string>(HighlightBlock.Title);

            model.Content = content.Value<string>(HighlightBlock.Content);

            if(content.HasValue(HighlightBlock.Image))
            {
                model.Image = _imageBuilder.GetModel(content.Value<IPublishedContent>(HighlightBlock.Image), ImageCropSizes.HighlightBlockCrop);
            }

            model.ImagePosition = content.Value<string>(HighlightBlock.ImagePosition);

            model.ImageBorderOption = content.Value<string>(HighlightBlock.BorderStyle);

            return model;
        }
    }
}