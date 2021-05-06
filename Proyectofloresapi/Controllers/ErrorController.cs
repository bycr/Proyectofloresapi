using System;
using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class ErrorController : Controller
    {
        public static string errorview()
        {
            return "view";
        }
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operacion, String modulo, String msjeErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}