using Kickoff.Models.Media;
using Newtonsoft.Json.Linq;

namespace Kickoff.Models.Pages
{
    public class PageBaseModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public JObject Editorial { get; set; }

        public NavigationModel Navigation { get; set; }

        public SeoBaseModel SeoBase { get; set; }
    }
}
