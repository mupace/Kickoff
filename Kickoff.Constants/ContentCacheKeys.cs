using Kickoff.Constants.Pages;
using Kickoff.Constants.Settings;
using System.Collections.Generic;

namespace Kickoff.Constants
{
    public class ContentCacheKeys
    {
        public static readonly List<string> CacheableAliases = new List<string>()
        {
            Setting.DocumentTypeAlias
        };

        public const string NavigationCacheKey = "Navigation_Cache_Key";

        public static readonly List<CacheKeyInformation> AffectList = new List<CacheKeyInformation>()
        {
            new CacheKeyInformation(NavigationCacheKey, new List<string>(){Home.DocumentTypeAlias })
        };
    }

    public class CacheKeyInformation
    {
        public string CacheKey { get; set; }

        public List<string> InvalidatedBy { get; set; }

        public CacheKeyInformation(string _cacheKey, List<string> _invalidatedBy)
        {
            CacheKey = _cacheKey;
            InvalidatedBy = _invalidatedBy;
        }
    }
}