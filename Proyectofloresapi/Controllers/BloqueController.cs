using Proyectofloresapi.Filters;
using Proyectofloresapi.Models;
using Proyectofloresapi.Models.ViewModelBloque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class BloqueController : Controller
    {
        public static string listaBloque()
        {
            return "lst";
        }
        public static string nuevoBloque()
        {
            return "lst";
        }
        public static string editarBloque()
        {
            return "model";
        }
        public static string eliminarBloque()
        {
            return "bloque";
        }

        // GET: Bloque
        //[AuthorizeUser(idOperacion: 18)]
        public ActionResult ListaBloque()
        {
            List<ListBloqueViewModel> lst;

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from blo in db.bloque
                       join fi in db.finca
                       on blo.idfinca equals fi.idfinca
                       select new ListBloqueViewModel
                       {
                           Idbloque = blo.idbloque,
                           Numerobloque = blo.numerobloque,
                           Presupuestadoaño = blo.presupuestadoaño,
                           Llevamosaño = blo.llevamosaño,
                           Diferenciaaño = blo.diferenciaaño,
                           Presupuestadomes = blo.presupuestadomes,
                           Llevamosmes = blo.llevamosmes,
                           Diferenciames = blo.diferenciames,
                           Cedula = blo.cedula,
                           Idinvernadero = blo.idinvernadero,
                           Idfinca = blo.idfinca,
                           NameFinca = fi.nombrefinca

                       }).ToList();

            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

        //registro nuevos bloques
        //[AuthorizeUser(idOperacion: 19)]
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
                        var oBloque = new bloque();

                        oBloque.numerobloque = model.Numerobloque;
                        oBloque.presupuestadoaño = model.Presupuestadoaño;
                        oBloque.llevamosaño = model.Llevamosaño;
                        oBloque.diferenciaaño = model.Presupuestadoaño - model.Llevamosaño;
                        oBloque.presupuestadomes = model.Presupuestadomes;
                        oBloque.llevamosmes = model.Llevamosmes;
                        oBloque.diferenciames = model.Presupuestadomes - model.Llevamosmes;
                        oBloque.cedula = model.Cedula;
                        oBloque.idfinca = model.Idfinca;
                        oBloque.idinvernadero = model.Idinvernadero;

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
        //[AuthorizeUser(idOperacion: 20)]
        public ActionResult EditarBloque(int Id)
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

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
        [AuthorizeUser(idOperacion: 21)]
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