namespace Hotels.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Extensions.Map;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Primitives;
    using Models.Rooms;
    using Services;

    [Route("api/hotels/{hotelId}/cached-rooms")]
    [ApiController]
    public class RoomsMemCachedController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly ISimpleLogger logger;
        private readonly IMemoryCache memoryCache;

        public RoomsMemCachedController(ApiDbContext context, ISimpleLogger logger, IMemoryCache memoryCache)
        {
            this.context = context;
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        [HttpGet("")]
        public async Task<IEnumerable<RoomResource>> Get(int hotelId, CancellationToken token)
        {
            var key = $"_rooms_for_hotel_{hotelId}";

            var list = await this.memoryCache.GetOrCreateAsync(key, entry =>
            {
                var cacheTokenSource = this.memoryCache.GetOrCreate($"_CTS{hotelId}", cacheEntry => new CancellationTokenSource());

                entry.AddExpirationToken(new CancellationChangeToken(cacheTokenSource.Token));
                entry.RegisterPostEvictionCallback(this.Callback, this);

                this.logger.LogInfo("RoomsController-Get(hotelId) db hit");

                return this.context.Rooms
                    .Include(h => h.Hotel)
                    .Where(h => h.Hotel.Id == hotelId)
                    .ToListAsync(token);
            });

            return list.Select(e => e.MapAsResource());
        }

        private void Callback(object key, object value, EvictionReason reason, object state)
        {
            this.logger.LogInfo($"RoomsController-Get(hotelId) cache reset: {reason} on key: {key}");
        }
    }
}
