using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using SingletonDP.Models;
using SingletonDP.Services;
using System.Text.Json;


namespace SingletonDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IDistributedCache _cache;
        private readonly ILoggerServices _logger;
        private readonly ISingletonTracker singletonTracker;
        private readonly IScopedTracker scopedTracker;
        private readonly IScopedTracker scopedTracker2;
        private readonly ITransientTracker transientTracker;
        private readonly ITransientTracker transientTracker2;

        public TestController(AppDbContext db, IDistributedCache cache  
            , ILoggerServices logger
            , ISingletonTracker singletonTracker
            ,IScopedTracker scopedTracker
            ,IScopedTracker scopedTracker2
            ,ITransientTracker transientTracker
            ,ITransientTracker transientTracker2
            )
        {
            _db = db;
            _cache = cache;
            _logger = logger;
            this.singletonTracker = singletonTracker;
            this.scopedTracker = scopedTracker;
            this.scopedTracker2 = scopedTracker2;
            this.transientTracker = transientTracker;
            this.transientTracker2 = transientTracker2;
        }

        [HttpGet("data")]
        public IActionResult Get()
        {
            _logger.LogInfo($"Singleton ID: {singletonTracker.Id}");
            _logger.LogInfo($"Scoped ID: {scopedTracker.Id}");
            _logger.LogInfo($"Scoped2 ID: {scopedTracker2.Id}");
            _logger.LogInfo($"Transient ID: {transientTracker.Id}");
            _logger.LogInfo($"Transient2 ID: {transientTracker2.Id}");
            var cacheKey = "generalPolicies";
            var cachedData = _cache.GetString(cacheKey);
            var data = new List<GeneralPolicy>();
            if (!string.IsNullOrEmpty(cachedData))
            {
                data = JsonSerializer.Deserialize<List<GeneralPolicy>>(cachedData);
                _logger.LogInfo("Data retrieved from cache.");
                return Ok(data);
            }
            try { 
             data = _db.GeneralPolicies.ToList();
            var serializedData = JsonSerializer.Serialize(data);
            var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(5) };
            _cache.SetString(cacheKey, serializedData, cacheOptions); }catch(Exception ex)
            {
                _logger.LogError($"Error retrieving data: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

            _logger.LogInfo("Data retrieved from database and stored in cache.");
            return Ok(data);

        }
    }
}
