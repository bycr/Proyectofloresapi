using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Proyectofloresapi.Models;

namespace Proyectofloresapi.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            IEnumerable<FloresViewModel> flor = null;
            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri("https://floresapi20210512074433.azurewebsites.net/api/");
                var responseTask = client.GetAsync("Flores");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<FloresViewModel>>();
                    readjob.Wait();
                    flor = readjob.Result;
                }
                else
                {
                    flor = Enumerable.Empty<FloresViewModel>();
                    ModelState.AddModelError(string.Empty, "error");
                }
            }
            return View(flor);
        }
    }
}