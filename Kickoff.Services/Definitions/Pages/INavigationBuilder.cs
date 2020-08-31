using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Pages
{
    public interface INavigationBuilder
    {
        NavigationModel GetModel(IPublishedContent content);
    }
}
