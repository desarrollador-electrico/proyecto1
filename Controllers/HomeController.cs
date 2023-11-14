using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AriasRomanJonathan_Proyecto1.Controllers
{
   public class HomeController : Controller
   {

    


   public ActionResult Index()
      {
         ViewBag.ActiveLink = "Portada";
         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your application description page.";
         ViewBag.ActiveLink = "About";
         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Por este medio me puedes contactar.";
         ViewBag.ActiveLink = "Contact";
         return View();
      }

      public ActionResult Mision()
      {
         ViewBag.ActiveLink = "Mision";
         return View();
      }

   } // Final de HomeController
} // Final de namespace