using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Pages
{
    public interface IHomeBuilder
    {
        HomeModel GetModel(IPublishedContent content);
    }
}