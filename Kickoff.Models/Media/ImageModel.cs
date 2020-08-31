
namespace Kickoff.Models.Media
{
    public class ImageModel : BaseDocumentModel
    {
        //public ImageCropDataSet Image { get; set; }

        public string Url { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Size { get; set; }

        public string Type { get; set; }

        public string Alt { get; set; }

        public string Title { get; set; }
    }
}
