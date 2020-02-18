using System;
using System.Threading.Tasks;
using Hotels.Api.Extensions.Map;
using Hotels.Data;
using Hotels.Data.Entities;
using Hotels.Models.Hotels;
using Hotels.Models.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApiDbContext context;

        public RoomsController(ApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> Get(int id)
        {
            if (id < 0)
            {
                throw new AccessViolationException("Negative id exception");
            }

            var entity = await this.context.Rooms.FindAsync(id);

            if (entity == null)
            {
                return this.NotFound();
            }

            return entity.MapAsModel();
        }

        [HttpPost]
        public async Task<ActionResult<RoomModel>> Post(CreateRoomRequestModel model)
        {
            var hotel = await this.context.Hotels.FindAsync(model.HotelId);

            if (hotel == null)
            {
                return this.NotFound();
            }

            var entity = model.MapAsNewEntity(hotel);

            this.context.Rooms.Add(entity);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = entity.Id }, entity.MapAsModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRoomRequestModel model)
        {
            var room = await this.context.Rooms.FindAsync(id);

            if (room == null)
            {
                return this.NotFound();
            }

            room.UpdateWith(model);

            this.context.Rooms.Update(room);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomModel>> Delete(int id)
        {
            var room = await this.context.Rooms.FindAsync(id);

            if (room == null)
            {
                return this.NotFound();
            }

            this.context.Rooms.Remove(room);
            await this.context.SaveChangesAsync();

            return room.MapAsModel();
        }
    }
}