using Kickoff.Models.Common;

namespace Kickoff.Models.Pages
{
    public class HomeModel : PageBaseModel
    {
        public LinkModel BannerCTA { get; set; }

        public bool UnderMaintenance { get; set; }
    }
}
