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
            var t = new Random().Next();
            var results = doc.SelectNodes("/Config/Devices/Device[id='" + input + t + "']");

            using (XmlWriter writer = XmlWriter.Create("employees.xml"))
            {
                writer.WriteStartDocument();

                // BAD: Insert user input directly into XML
                writer.WriteRaw("<employee><name>" + input + "</name></employee>");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            return results[0].InnerText;
        }
    }
}
