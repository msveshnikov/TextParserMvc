using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TextParserMvc.Models;

namespace TextParserMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Csv(TextModel model)
        {
            return processRequest(model.text, "Converted.csv", new CsvConverter());
        }


        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Xml(TextModel model)
        {
            return processRequest(model.text, "Converted.xml", new XmlConverter());
        }

        private ActionResult processRequest(string textToParse, string fileName, IConvert converter)
        {
            if (textToParse != null)
            {
                Parser parser = new Parser();
                Text text = parser.Parse(textToParse);
                string result = converter.Convert(text);

                byte[] fileBytes = Encoding.UTF8.GetBytes(result);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                ModelState.AddModelError("text", "Please enter text");
                return View();
            }
        }
    }
}