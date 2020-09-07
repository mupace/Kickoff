using System.Collections.Generic;

namespace Kickoff.Models.Shared
{
    public class SiteNavigationModel
    {
        public SiteNavigationModel()
        {
            NavigationItems = new List<NavigationItemModel>();
        }

        public List<NavigationItemModel> NavigationItems { get; set; }
    }
}