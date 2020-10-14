using Kickoff.Models.Media;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Media
{
    public interface IImageBuilder
    {
        ImageModel GetModel(IPublishedContent content, string cropSize);
    }
}