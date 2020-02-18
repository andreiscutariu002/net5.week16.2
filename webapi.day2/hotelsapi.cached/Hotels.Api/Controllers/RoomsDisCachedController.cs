namespace Hotels.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Extensions.Map;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Distributed;
    using Models.Rooms;
    using Newtonsoft.Json;
    using Services;

    [Route("api/hotels/{hotelId}/dis-cached-rooms")]
    [ApiController]
    public class RoomsDisCachedController
    {
        private readonly ApiDbContext context;
        private readonly IDistributedCache cache;
        private readonly ISimpleLogger logger;

        public RoomsDisCachedController(ApiDbContext context, IDistributedCache cache, ISimpleLogger logger)
        {
            this.context = context;
            this.cache = cache;
            this.logger = logger;
        }

        [HttpGet("")]
        public async Task<IEnumerable<RoomResource>> Get(int hotelId, CancellationToken token)
        {
            var key = $"_rooms_for_hotel_{hotelId}";

            var rooms = this.cache.GetString(key);

            if (!string.IsNullOrEmpty(rooms))
            {
                this.logger.LogInfo("DistributedCachedRoomsController-Get(hotelId) cache hit");

                var roomsList = Deserialize<List<RoomResource>>(rooms);

                return roomsList;
            }
            else
            {
                this.logger.LogInfo("DistributedCachedRoomsController-Get(hotelId) db hit");

                var roomsEntities = await this.context.Rooms
                    .Include(h => h.Hotel)
                    .Where(h => h.Hotel.Id == hotelId)
                    .ToListAsync(token);

                var options = new DistributedCacheEntryOptions();
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(3));
                
                var resources = roomsEntities.Select(e => e.MapAsResource());
                this.cache.SetString(key, Serialize(resources), options);

                return resources;
            }
        }

        private static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private static T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
