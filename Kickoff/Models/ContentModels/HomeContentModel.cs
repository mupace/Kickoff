using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Models.ContentModels
{
    public class HomeContentModel : PublishedContentWrapped
    {
        public HomeContentModel(IPublishedContent content) : base(content)
        {
        }

        public HomeModel PageModel { get; set; } 
    }
}