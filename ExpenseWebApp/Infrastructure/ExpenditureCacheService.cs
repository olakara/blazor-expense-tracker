using ExpenseWebApp.DTO;
using ExpenseWebApp.Interfaces;
using Microsoft.Extensions.Caching.Hybrid;


namespace ExpenseWebApp.Infrastructure;

public class ExpenditureCacheService : IExpenditureCache
{
    private readonly IExpenditureAPI _api;
    private readonly HybridCache _cache;

    public ExpenditureCacheService(IExpenditureAPI api, HybridCache cache)
    {
        _api = api;
        _cache = cache;
    }
    
    public async Task<ExpenditureDto> GetExpenditureById(Guid id)
    {
        var cacheKey = $"expense_{id}";
        var expense = await _cache.GetOrCreateAsync(cacheKey, 
            async cancel => await _api.GetExpenditureByIdAsync(id));
        return expense;
    }
}

/*var cacheKey = $"expense_{id}";
var bytes = await _cache.GetAsync(cacheKey);
if (bytes == null)
{
    var expense = await _api.GetExpenditureByIdAsync(id);
    var options = new DistributedCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    };
    bytes = ExpenditureSerializer.Serialize(expense);
    await _cache.SetAsync(cacheKey, bytes, options);
    return expense;
}
else
{
    var expense = ExpenditureSerializer.Deserialize(bytes);
    return expense;
}*/