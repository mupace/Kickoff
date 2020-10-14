using Kickoff.Models.Block;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Definitions.Blocks
{
    public interface ISiteHeaderBuilder
    {
        SiteHeaderModel GetModel(IPublishedContent currentPage);
    }
}