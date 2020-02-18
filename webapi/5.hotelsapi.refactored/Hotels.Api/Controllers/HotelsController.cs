using Hotels.Api.Extensions.Map;
using Hotels.Data;
using Hotels.Data.Entities;
using Hotels.Models.Hotels;

namespace Hotels.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services;

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly INotificationService notificationService;

        public HotelsController(ApiDbContext context, INotificationService notificationService)
        {
            this.context = context;
            this.notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelModel>> Get(int id)
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

            return entity.MapAsModel();
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(CreateHotelRequestModel model)
        {
            var entity = model.MapAsNewEntity();
            this.context.Hotels.Add(entity);

            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = entity.Id }, entity.MapAsModel());
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(long id, Hotel todoItem)
        //{
        //    if (id != todoItem.Id)
        //    {
        //        return this.BadRequest();
        //    }

        //    this.context.Entry(todoItem).State = EntityState.Modified;

        //    await this.context.SaveChangesAsync();

        //    return this.NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Hotel>> Delete(int id)
        //{
        //    var hotel = await this.context.Hotels.FindAsync(id);

        //    if (hotel == null)
        //    {
        //        return this.NotFound();
        //    }

        //    this.context.Hotels.Remove(hotel);
        //    await this.context.SaveChangesAsync();

        //    this.notificationService.Notify($"Hotel deleted: {id}");

        //    return hotel;
        //}
    }
}
