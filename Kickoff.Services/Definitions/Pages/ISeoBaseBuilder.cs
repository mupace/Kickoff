using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Pages
{
    public interface ISeoBaseBuilder
    {
        SeoBaseModel GetModel(IPublishedContent content);
    }
}
