using System;
using System.Threading.Tasks;
using Hotels.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Api.Controllers
{
    [Route("api/rooms-old")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RoomsOldController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Post(Room room)
        {
            throw new NotImplementedException();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Room room)
        {
            throw new NotImplementedException();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}