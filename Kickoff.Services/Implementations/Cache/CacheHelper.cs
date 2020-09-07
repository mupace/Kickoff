using System;
using System.Linq;
using System.Runtime.Caching;

namespace Kickoff.Services.Implementations.Cache
{
    /// <summary>
    /// Thread Safe Singleton Cache Class
    /// </summary>
    public sealed class CacheHelper
    {
        private const string CacheName = "KickoffCache";
        private const double settingCacheExpirationTimeInMinutes = 5d; // 5 minutes

        private static volatile CacheHelper instance; //  Locks var until assignment is complete for double safety
        private static MemoryCache memoryCache;
        private static object syncRoot = new object();

        private CacheHelper()
        {
        }

        /// <summary>
        /// Singleton Cache Instance
        /// </summary>
        public static CacheHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            InitializeInstance();
                        }
                    }
                }
                return instance;
            }
        }

        private static void InitializeInstance()
        {
            instance = new CacheHelper();
            memoryCache = new MemoryCache(CacheName);
        }

        /// <summary>
        /// Writes Key Value Pair to Cache
        /// </summary>
        /// <param name="Key">Key to associate Value with in Cache</param>
        /// <param name="Value">Value to be stored in Cache associated with Key</param>
        public void Write(string Key, object Value)
        {
            memoryCache.Add(Key, Value, DateTimeOffset.Now.AddMinutes(settingCacheExpirationTimeInMinutes));
        }

        /// <summary>
        /// Writes Key Value Pair to Cache
        /// </summary>
        /// <param name="Key">Key to associate Value with in Cache</param>
        /// <param name="Value">Value to be stored in Cache associated with Key</param>
        public void Write(string Key, object Value, DateTimeOffset offset)
        {
            memoryCache.Add(Key, Value, offset);
        }

        /// <summary>
        /// Returns Value stored in Cache
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>Value stored in cache</returns>
        public object Read(string Key)
        {
            return memoryCache.Get(Key);
        }

        /// <summary>
        /// Returns Value stored in Cache, null if non existent
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>Value stored in cache</returns>
        public object TryRead(string Key)
        {
            try
            {
                return memoryCache.Get(Key);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Contains(string Key)
        {
            return memoryCache.Contains(Key);
        }

        public string[] GetAllKeys()
        {
            return memoryCache.Select(x => x.Key).ToArray();
        }

        public void Invalidate(string Key)
        {
            if (Contains(Key))
                memoryCache.Remove(Key);
        }
    }
}