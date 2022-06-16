using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Xml;

namespace SampleWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
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
                writer.WriteRaw("<employee><name>" + SecurityElement.Escape(input) + "</name></employee>");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            //return results[0].InnerText;
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "exportLegacy.exe";
            p.StartInfo.Arguments = " -user " + input + " -role user";
            p.Start();

            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(input, settings);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(input);
            Console.WriteLine(xmlDoc.InnerText);

            return "value: " + input;
        }
    }
}
