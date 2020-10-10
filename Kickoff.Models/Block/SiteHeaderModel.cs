using Kickoff.Models.Shared;

namespace Kickoff.Models.Block
{
    public class SiteHeaderModel : BaseDocumentModel
    {
        public SiteHeaderModel()
        {
            Navigation = new SiteNavigationModel();
        }

        public string MenuTitle { get; set; }

        public bool UseHomepageHeader { get; set; }

        public SiteNavigationModel Navigation { get; set; }
    }
}