using PerInformixDB.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInformixDB.Controllers
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

        public ActionResult ObtenerTodos()
        {
            var Condiciones = (List<string>)new PerCatalogo().ObtenerTodos();
            return Json(new { data = Condiciones }, JsonRequestBehavior.AllowGet);            
        }
    }
}