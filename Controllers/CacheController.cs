using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisCachingDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController : ControllerBase
{

    private readonly ILogger<CacheController> _logger;
    private readonly IDistributedCache _cache;

    public CacheController(ILogger<CacheController> logger, IDistributedCache cache)
    {
        _logger = logger;
        _cache = cache;
    }

    [HttpGet(Name = "GetFromCache")]
    public string? GetFromCache(string key)
    {
        return _cache.GetString(key);
    }

    [HttpPost(Name = "AddToCache")]
    public void AddToCache(string key, string val)
    {
        _cache.SetString(key, val);
    }
}
