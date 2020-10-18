using System.Collections.Generic;

namespace Kickoff.Constants.Blocks
{
    public static class BlockDocTypes
    {
        private static List<string> TypeList = new List<string>
        {
            HighlightBlock.DocumentTypeAlias, CTABlock.DocumentTypeAlias
        };

        public static bool IncludesType(string typeAlias)
        {
            return TypeList.Contains(typeAlias);
        }
    }
}