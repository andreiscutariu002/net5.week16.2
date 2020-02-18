using Hotels.Data;
using Hotels.Data.Entities;

namespace Hotels.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services;

    [Route("api/hotels-old")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HotelsOldController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly INotificationService notificationService;

        public HotelsOldController(ApiDbContext context, INotificationService notificationService)
        {
            this.context = context;
            this.notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)  
        {
            if (id < 0)
            {
                throw new AccessViolationException("Negative id exception");
            }

            var entity = await this.context.Hotels.FindAsync(id);

            if (entity == null)
            {
                return this.NotFound();
            }

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(Hotel hotel)
        {
            this.context.Hotels.Add(hotel);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hotel todoItem)
        {
            if (id != todoItem.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(todoItem).State = EntityState.Modified;

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            var hotel = await this.context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return this.NotFound();
            }

            this.context.Hotels.Remove(hotel);
            await this.context.SaveChangesAsync();

            this.notificationService.Notify($"Hotel deleted: {id}");

            return hotel;
        }
    }
}
