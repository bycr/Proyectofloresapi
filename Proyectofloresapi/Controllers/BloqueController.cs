using Proyectoflores.Models;
using Proyectoflores.Models.ViewModelBloque;
using Proyectofloresapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Proyectoflores.Controllers
{
    public class BloqueController : Controller
    {
        // GET: Bloque
        public ActionResult ListaBloque()
        {
            List<ListBloqueViewModel> lst;

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from d in db.bloque
                       select new ListBloqueViewModel
                       {
                           Idbloque = d.idbloque,
                           Numerobloque = d.numerobloque,
                           Presupuestadoaño = d.presupuestadoaño,
                           Llevamosaño = d.llevamosaño,
                           Diferenciaaño = d.diferenciaaño,
                           Presupuestadomes = d.presupuestadomes,
                           Llevamosmes = d.llevamosmes,
                           Diferenciames = d.diferenciames,
                           Cedula = d.cedula,
                           Idinvernadero = d.idinvernadero,
                           Idfinca = d.idfinca

                       }).ToList();

            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

        //registro nuevos bloques
        public ActionResult NuevoBloque()
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

            return View();
        }

        public JsonResult GetInvernaderoList(int idfinca)
        {
            sd.Configuration.ProxyCreationEnabled = false;
            List<invernadero> selectList = sd.invernadero.Where(x => x.idfinca == idfinca).ToList();
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevoBloque(BloqueViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oBloque = new bloque
                        {
                            numerobloque = model.Numerobloque,
                            presupuestadoaño = model.Presupuestadoaño,
                            llevamosaño = model.Llevamosaño,
                            diferenciaaño = model.Presupuestadoaño - model.Llevamosaño,
                            presupuestadomes = model.Presupuestadomes,
                            llevamosmes = model.Llevamosmes,
                            diferenciames = model.Presupuestadomes - model.Llevamosmes,
                            cedula = model.Cedula,
                            idfinca = model.Idfinca,
                            idinvernadero = model.Idinvernadero,

                        };

                        db.bloque.Add(oBloque);
                        db.SaveChanges();
                    }
                    return Redirect("~/Bloque/ListaBloque");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //editar bloque

        public ActionResult EditarBloque(int Id)
        {
            BloqueViewModel model = new BloqueViewModel();
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oBloque = db.bloque.Find(Id);
                model.Idbloque = oBloque.idbloque;
                model.Numerobloque = oBloque.numerobloque;
                model.Presupuestadoaño = oBloque.presupuestadoaño;
                model.Llevamosaño = oBloque.llevamosaño;
                model.Diferenciaaño = oBloque.presupuestadoaño - oBloque.llevamosaño;
                model.Presupuestadomes = oBloque.presupuestadomes;
                model.Llevamosmes = oBloque.llevamosmes;
                model.Diferenciames = oBloque.presupuestadomes - oBloque.llevamosmes;
                model.Cedula = oBloque.cedula;
                model.Idinvernadero = oBloque.idinvernadero;
                model.Idfinca = oBloque.idfinca;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarBloque(BloqueViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oBloque = db.bloque.Find(model.Idbloque);
                        oBloque.idbloque = model.Idbloque;
                        oBloque.numerobloque = model.Numerobloque;
                        oBloque.presupuestadoaño = model.Presupuestadoaño;
                        oBloque.llevamosaño = model.Llevamosaño;
                        oBloque.diferenciaaño = model.Presupuestadoaño - model.Llevamosaño;
                        oBloque.presupuestadomes = model.Presupuestadomes;
                        oBloque.llevamosmes = model.Llevamosmes;
                        oBloque.diferenciames = model.Presupuestadomes - model.Llevamosmes;
                        oBloque.cedula = model.Cedula;
                        oBloque.idinvernadero = model.Idinvernadero;
                        oBloque.idfinca = model.Idfinca;

                        db.Entry(oBloque).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Bloque/ListaBloque");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //eliminar bloque

        public ActionResult EliminarBloque(int Id)
        {

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oBloque = db.bloque.Find(Id);
                db.bloque.Remove(oBloque);
                db.SaveChanges();

            }
            return Redirect("~/Bloque/ListaBloque");
        }

    }
}