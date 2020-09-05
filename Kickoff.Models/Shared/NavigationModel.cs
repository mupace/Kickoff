using Kickoff.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kickoff.Models.Shared
{
    public class NavigationModel
    {
        public NavigationModel()
        {

        }

        public List<List<PageBaseModel>> NavigationItems { get; set; }
    }
}
