using Kickoff.Models.Common;
using Kickoff.Models.Media;
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

        public string HeaderText { get; set; }

        public string SubText { get; set; }

        public ImageModel BannerImage { get; set; }

        public LinkModel BannerCTA { get; set; }

        public SiteNavigationModel Navigation { get; set; }
    }
}