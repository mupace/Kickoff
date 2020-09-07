using Kickoff.Models.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Models.ContentModels
{
    public class StandardPageContentModel : PublishedContentWrapped
    {
        public StandardPageContentModel(IPublishedContent content) : base(content)
        {
        }

        public StandardPageModel PageModel { get; set; }
    }
}