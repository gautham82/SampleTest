using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceIntegration
{
    public class CachedRepositoryDecorator
    {
        private readonly IMemoryCache _cache;
        private MemoryCacheEntryOptions cacheOptions;
        
        public CachedRepositoryDecorator(IReadOnlyRepository<Entity> repository)
        {
            cacheOptions = new MemoryCacheEntryOptions();
            cacheOptions.SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(120));

            _cache = new MemoryCache(new MemoryCacheOptions());

            // 5 second cache
           // cacheOptions = 
        }

        public Entity Find(string id)
        {
            string key = id;
            Entity entry;
            if(_cache.TryGetValue(key, out entry))
            {
                return entry;
            }
            return null;
        }


    }
}
