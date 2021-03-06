using GeneratePDFImplement.Models;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneratePDFImplement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("Home/Generate")]
        public ActionResult PDFGenerate()
        {
            List<User> users = new List<User>();
            users.Add(new User
            {
                Id = 1,
                Name = "Darshit"
                
            });
            users.Add(new User
            {
                Id = 2,
                Name = "Rawal"

            });
            users.Add(new User
            {
                Id = 3,
                Name = "Darshit_R"

            });
            users.Add(new User
            {
                Id = 4,
                Name = "Rawal_D"

            });
            users.Add(new User
            {
                Id = 5,
                Name = "Darshit_Rawal"

            });

            //return new PartialViewAsPdf("_jobPrint", users)
            //{
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    PageSize = Size.A3,
            //    CustomSwitches = "--footer-center \" [page] Page of [toPage] Pages\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"",
            //    FileName = "TestPartialViewAsPdf.pdf"
            //};
            return View(users);
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("PDFGenerate");
        }
    }
}