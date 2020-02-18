namespace FirstApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/download")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        public DownloadController()
        {
        }

        [HttpGet]
        public string Get()
        {
            WebClient client = new WebClient();
            var value = client.DownloadString("https://www.google.com/");
            return value;
        }

        [HttpGet("async")]
        public async Task<string> GetAsync()
        {
            WebClient client = new WebClient();
            var value = await client.DownloadStringTaskAsync("https://www.google.com/");
            return value;
        }
    }
}