using Kickoff.Models.Media;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Media
{
    public interface IFileBuilder
    {
        FileModel GetModel(IPublishedContent content);
    }
}