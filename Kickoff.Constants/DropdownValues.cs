
using System.Collections.Generic;

namespace Kickoff.Constants
{
    public class DropdownValues
    {
        public static Dictionary<string, ImagePositionDropdown> ImagePositionMaps = new Dictionary<string, ImagePositionDropdown>
        {
            { "right", ImagePositionDropdown.Right },
            {"left", ImagePositionDropdown.Left }
        };
    }

    public enum ImagePositionDropdown 
    {
        Right,
        Left
    };
}
