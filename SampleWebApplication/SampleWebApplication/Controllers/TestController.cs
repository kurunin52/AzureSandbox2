using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public string Get(string myParam)
        {
            var rnd = new Random();
            byte[] buffer = new byte[16];
            rnd.NextBytes(buffer);
            return BitConverter.ToString(buffer);
        }
    }
}
