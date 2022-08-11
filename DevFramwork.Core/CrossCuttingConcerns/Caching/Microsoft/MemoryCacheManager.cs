using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace DevFramwork.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private static ObjectCache Default;
        
        protected ObjectCache Cache
        {
            get { return MemoryCacheManager.Default; }
        }

        public void Add(string key, object data, int cachTime)
        {
            if (data==null)
            {
                return;
            }
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cachTime) };
            Cache.Add(new CacheItem(key,data), policy);
        }
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }
        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }
        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Cache.Remove(key);
            }
        }
    }
}
