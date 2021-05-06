using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class HomeController : Controller
    {
        public static string vistaindex()
        {
            return "view";
        }
        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
