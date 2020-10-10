using Kickoff.Constants;
using Kickoff.Models.Media;

namespace Kickoff.Models.Block
{
    public class HighlightBlockModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ImageModel Image { get; set; }

        public bool HasImage => Image != null;

        public string ImagePosition { get; set; }

        public ImagePositionDropdown ImagePositionEnum { get; set; }

        public HighlightBlockModel()
        {
            ImagePositionEnum = ImagePositionDropdown.Right;
        }
    }
}