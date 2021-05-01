using Proyectoflores.Models.ViewModelInvernadero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyectoflores.Models;
using Proyectofloresapi.Models;

namespace Proyectoflores.Controllers
{
    public class InvernaderoController : Controller
    {
        // GET: Invernadero
        public ActionResult ListaInvernadero()
        {
            List<ListInvernaderoViewModel> lst;

            using(proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from d in db.invernadero
                       select new ListInvernaderoViewModel
                       {
                           Idinvernadero = d.idinvernadero,
                           Numeroinvernadero = d.numeroinvernadero,
                           Idfinca = d.idfinca

                       }).ToList();
            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

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