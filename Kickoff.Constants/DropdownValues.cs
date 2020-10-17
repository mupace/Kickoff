
using System.Collections.Generic;

namespace Kickoff.Constants
{
    public class DropdownValues
    {
        public static Dictionary<string, ImagePositionDropdown> ImagePositionMaps = new Dictionary<string, ImagePositionDropdown>
        {
            { "Right", ImagePositionDropdown.Right },
            { "Left", ImagePositionDropdown.Left }
        };

        public static Dictionary<string, ImageBorderOptions> ImageBorderMaps = new Dictionary<string, ImageBorderOptions>
        {
            { "Box", ImageBorderOptions.Box },
            { "Circle", ImageBorderOptions.Circle }
        };
    }

    public enum ImagePositionDropdown 
    {
        Right,
        Left
    };

    public enum ImageBorderOptions
    {
        Box,
        Circle
    }
}
