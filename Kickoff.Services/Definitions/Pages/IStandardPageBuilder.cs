using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Pages
{
    public interface IStandardPageBuilder
    {
        StandardPageModel GetModel(IPublishedContent content);
    }
}