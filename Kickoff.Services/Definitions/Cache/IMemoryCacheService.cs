using System;

namespace Kickoff.Services.Definitions.Cache
{
    public interface IMemoryCacheService
    {
        bool IsCacheable(string documentTypeAlias);

        T AddOrGet<T>(string cacheKey, Func<T> getItemCallback, int expireInMin = 0) where T : class;

        T AddOrGetByNodeAlias<T>(string documentTypeAlias, int nodeId, Func<T> getItemCallback) where T : class;

        void InvalidateByNodeAlias(string documentTypeAlias, int nodeId);
    }
}