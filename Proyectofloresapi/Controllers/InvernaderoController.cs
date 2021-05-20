using Proyectofloresapi.Models.ViewModelInvernadero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyectofloresapi.Models;
using Proyectofloresapi.Filters;

namespace Proyectofloresapi.Controllers
{
    public class InvernaderoController : Controller
    {
        public static string vistalistaInvernadero()
        {
            return "lst";
        }
        public static string vistaNuevoInvernadero()
        {
            return "model";
        }
        public static string vistaEditarInvernadero()
        {
            return "mod";
        }
        public static string vistaEliminarInvernadero()
        {
            return "view";
        }

        // GET: Invernadero
        //[AuthorizeUser(idOperacion:7)]
        public ActionResult ListaInvernadero()
        {
            List<ListInvernaderoViewModel> lst;

            using(proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from inv in db.invernadero
                       join fi in db.finca
                       on inv.idfinca equals fi.idfinca
                       select new ListInvernaderoViewModel
                       {
                           Idinvernadero = inv.idinvernadero,
                           Numeroinvernadero = inv.numeroinvernadero,
                           Namefinca = fi.nombrefinca,
                           Idfinca = inv.idfinca

                       }).ToList();
            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

        //[AuthorizeUser(idOperacion: 8)]
        public ActionResult NuevoInvernadero()
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca","nombrefinca");
            return View();
        }

        [HttpPost]
        public ActionResult NuevoInvernadero(InvernaderoViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oInvernadero = new invernadero();

                        oInvernadero.numeroinvernadero = model.Numeroinvernadero;
                        oInvernadero.idfinca = model.Idfinca;

                        db.invernadero.Add(oInvernadero);
                        db.SaveChanges();

                    }

                    return Redirect("~/Invernadero/ListaInvernadero");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //editar invernaderos
        //[AuthorizeUser(idOperacion: 9)]
        public ActionResult EditarInvernadero(int Id)
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

            InvernaderoViewModel mod = new InvernaderoViewModel();
            using (proyectofloresEntities db = new proyectofloresEntities())
            {   
                var oInvernadero = db.invernadero.Find(Id);
                mod.Idinvernadero = oInvernadero.idinvernadero;
                mod.Numeroinvernadero = oInvernadero.numeroinvernadero;
                mod.Idfinca = oInvernadero.idfinca;

            }
            return View(mod);
        }

        [HttpPost]
        public ActionResult EditarInvernadero(InvernaderoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oInvernadero = db.invernadero.Find(model.Idinvernadero);
                        oInvernadero.idinvernadero = model.Idinvernadero;
                        oInvernadero.numeroinvernadero = model.Numeroinvernadero;
                        oInvernadero.idfinca = model.Idfinca;

                        db.Entry(oInvernadero).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }

                    return Redirect("~/Invernadero/ListaInvernadero");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eliminar 
        [AuthorizeUser(idOperacion: 11)]
        [HttpGet]
        public ActionResult EliminarInvernadero(int Id)
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oInvernadero = db.invernadero.Find(Id);
                db.invernadero.Remove(oInvernadero);
                db.SaveChanges();
            }
            return Redirect("~/Invernadero/ListaInvernadero");
        }
    }
}