using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Infrastructure.Caching;
using Equinor.Lighthouse.Api.MainApi.Person;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.WebApi.Caches
{
    public class PersonCache : IPersonCache
    {
        private readonly ICacheManager _cacheManager;
        private readonly IPersonApiService _personApiService;
        private readonly IOptionsMonitor<CacheOptions> _options;

        public PersonCache(
            ICacheManager cacheManager, 
            ICurrentUserProvider currentUserProvider, 
            IPersonApiService personApiService, 
            IOptionsMonitor<CacheOptions> options)
        {
            _cacheManager = cacheManager;
            _personApiService = personApiService;
            _options = options;
        }

        public async Task<PCSPerson> GetAsync(Guid userOid)
            => await _cacheManager.GetOrCreate(
                PersonsCacheKey(userOid),
                async () =>
                {
                    var person = await _personApiService.TryGetPersonByOidAsync(userOid);
                    return person;
                },
                CacheDuration.Minutes,
                _options.CurrentValue.PersonCacheMinutes);

        public async Task<bool> ExistsAsync(Guid userOid)
        {
            var pcsPerson = await GetAsync(userOid);
            return pcsPerson != null;
        }

        private string PersonsCacheKey(Guid userOid)
            => $"PERSONS_{userOid.ToString().ToUpper()}";
    }
}
