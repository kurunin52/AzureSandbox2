using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace SampleWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public string Get(string input)
        {
            var doc = new XmlDocument { XmlResolver = null };
            doc.LoadXml(@"<Config></Config>");
            var results = doc.SelectNodes("/Config/Devices/Device[id='" + input + "']");
            return results[0].InnerText;
        }
    }
}
