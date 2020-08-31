using Kickoff.Models.Media;

namespace Kickoff.Models.Pages
{
    public class SeoBaseModel
    {
        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string[] SeoKeywords { get; set; }

        public ImageModel SeoImage { get; set; }

        public bool HasImage => SeoImage != null;
    }
}
