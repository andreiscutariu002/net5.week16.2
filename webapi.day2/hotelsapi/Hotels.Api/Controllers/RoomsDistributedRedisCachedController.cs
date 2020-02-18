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
    using Models.Rooms;
    using Services;

    [Route("api/hotels/{hotelId}/dis-red-cached-rooms")]
    [ApiController]
    public class RoomsDistributedRedisCachedController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly ISimpleLogger logger;

        public RoomsDistributedRedisCachedController(ApiDbContext context, ISimpleLogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("")]
        public async Task<IEnumerable<RoomResource>> Get(int hotelId, CancellationToken token)
        {
            var list = await this.context.Rooms
                .Include(h => h.Hotel)
                .Where(h => h.Hotel.Id == hotelId)
                .ToListAsync(token);

            return list.Select(r => r.MapAsResource());
        }
    }
}
