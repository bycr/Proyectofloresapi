using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyectofloresapi.Models;

namespace Proyectofloresapi.Controllers
{
    public class ProduccionController : Controller
    {
        // GET: Produccion
        public ActionResult ListaProduccion()
        {
            return View();
        }    

    }
}