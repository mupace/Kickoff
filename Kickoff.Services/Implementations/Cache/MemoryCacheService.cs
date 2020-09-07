using Kickoff.Constants;
using Kickoff.Services.Definitions.Cache;
using System;
using System.Linq;

namespace Kickoff.Services.Implementations.Cache
{
    public class MemoryCacheService : IMemoryCacheService
    {
        public bool IsCacheable(string documentTypeAlias)
        {
            return ContentCacheKeys.CacheableAliases.Any(x => x == documentTypeAlias);
        }

        public T AddOrGet<T>(string cacheKey, Func<T> getItemCallback, int expireInMin = 0) where T : class
        {
            if (string.IsNullOrEmpty(cacheKey))
                return null;

            if (CacheHelper.Instance.Contains(cacheKey))
                return CacheHelper.Instance.Read(cacheKey) as T;
            else
            {
                var obj = getItemCallback.Invoke();

                DateTimeOffset offset;

                if (expireInMin > 0)
                {
                    offset = new DateTimeOffset(DateTime.Now.AddMinutes(expireInMin));
                }
                else
                {
                    offset = DateTimeOffset.MaxValue;
                }

                CacheHelper.Instance.Write(cacheKey, obj, offset);

                return obj;
            }
        }

        public T AddOrGetByNodeAlias<T>(string documentTypeAlias, int nodeId, Func<T> getItemCallback) where T : class
        {
            if (IsCacheable(documentTypeAlias))
                return AddOrGet<T>(GetCacheKeyForNode(documentTypeAlias, nodeId), getItemCallback);

            return null;
        }

        private void Invalidate(string cacheKey)
        {
            CacheHelper.Instance.Invalidate(cacheKey);
        }

        /// <summary>
        /// Removes all cache items which has key starting with cacheKeyword
        /// Intended to be used with Node cache and media search
        /// </summary>
        /// <param name="cacheKeyword">Starting substring of cache key</param>
        private void InvalidateByPartialKey(string cacheKeyword)
        {
            var cacheKeys = CacheHelper.Instance.GetAllKeys().Where(x => x.StartsWith(cacheKeyword)).ToList();

            foreach (var cacheKey in cacheKeys)
            {
                Invalidate(cacheKey);
            }
        }

        public void InvalidateByNodeAlias(string documentTypeAlias, int nodeId)
        {
            if (IsCacheable(documentTypeAlias))
            {
                Invalidate(GetCacheKeyForNode(documentTypeAlias, nodeId));
            }

            var affectedCaches = ContentCacheKeys.AffectList.Where(x => x.InvalidatedBy.Any(y => y == documentTypeAlias)).ToList();

            if (affectedCaches != null && affectedCaches.Any())
            {
                foreach (var affectedCache in affectedCaches)
                {
                    InvalidateByPartialKey(affectedCache.CacheKey);
                }
            }
        }

        private string GetCacheKeyForNode(string documentTypeAlias, int id)
        {
            return $"{documentTypeAlias}_{id}";
        }
    }
}