using Kickoff.Constants;
using Kickoff.Models.Media;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kickoff.Models.Block
{
    public class HighlightBlockModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ImageModel Image { get; set; }

        public bool HasImage => Image != null;

        public string ImagePosition { get; set; }

        public ImagePositionDropdown ImagePositionEnum
        {
            get
            {
                if (!string.IsNullOrEmpty(ImagePosition) && DropdownValues.ImagePositionMaps.Keys.Any(x => x == ImagePosition))
                {
                    return DropdownValues.ImagePositionMaps[ImagePosition];
                }
                return ImagePositionDropdown.Right;
            }
        }

        public string ImageBorderOption { get; set; }

        public ImageBorderOptions ImageBorderOptionEnum { get
            {
                if (!string.IsNullOrEmpty(ImageBorderOption) && DropdownValues.ImageBorderMaps.Keys.Any(x => x == ImageBorderOption))
                {
                    return DropdownValues.ImageBorderMaps[ImageBorderOption];
                }
                return ImageBorderOptions.Circle;
            }
        }
    }
}