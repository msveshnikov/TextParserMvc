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
            if (model.text != null)
            {
                Parser parser = new Parser();
                Text text = parser.Parse(model.text);
                IConvert converter = new CsvConverter();
                string csv = converter.Convert(text);

                byte[] fileBytes = Encoding.UTF8.GetBytes(csv);
                string fileName = "Converted.csv";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                ModelState.AddModelError("_FORM", "Please enter text");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Xml(TextModel model)
        {
            if (model.text != null)
            {
                Parser parser = new Parser();
                Text text = parser.Parse(model.text);
                IConvert converter = new XmlConverter();
                string csv = converter.Convert(text);

                byte[] fileBytes = Encoding.UTF8.GetBytes(csv);
                string fileName = "Converted.xml";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                ModelState.AddModelError("_FORM", "Please enter text");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}