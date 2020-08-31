using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Models.ContentModels
{
    public class HomeContentModel : PublishedContentWrapped
    {
        public HomeContentModel(IPublishedContent content) : base(content)
        {
        }


    }
}