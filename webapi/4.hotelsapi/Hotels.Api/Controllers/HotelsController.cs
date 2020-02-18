using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hotels.Api.Data.Entities;
using Hotels.Api.Extensions;
using Hotels.Api.Resources.Hotel;
using Hotels.Api.Services;
using Microsoft.Extensions.Configuration;

namespace Hotels.Api.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

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
        [Produces(typeof(HotelResource))]
        public IActionResult Get(int id, CancellationToken token)
        {
            HotelResource resource;
            return Ok(resource);
        }

        [HttpGet("{id}")]
        public ActionResult<HotelResource> Get2(int id, CancellationToken token)
        {
            HotelResource resource;
            return Ok(resource);
        }


        [HttpPost]
        public async Task<ActionResult<HotelResource>> Post([FromBody] CreateHotelResource model, CancellationToken token)
        {
            var entity = model.MapAsEntity();

            this.context.Hotels.Add(entity);

            await this.context.SaveChangesAsync(token);

            this.notificationService.Notify($"hotel with id {entity.Id} created!");

            return this.CreatedAtAction("Get", new { id = entity.Id }, entity.MapAsResource());
        }
    }
}
