using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceIntegration
{
    public class CachedRepositoryDecorator
    {
        private readonly IReadOnlyRepository<Entity> _repository;
        private readonly IMemoryCache _cache;
        private MemoryCacheOptions cacheOptions;
        private const string MyModelCacheKey = "Regions";
        
        public CachedRepositoryDecorator(IReadOnlyRepository<Entity> repository)
        {
            _repository = repository;
            cacheOptions = new MemoryCacheOptions();
            cacheOptions.SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(120));
            _cache = new MemoryCache(cacheOptions);

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

        public IEnumerable<Entity> ListAll()
        {
            //is this correct?

            return _repository.ListAll();
        }
    }
}
