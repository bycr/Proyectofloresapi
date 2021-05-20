using Proyectofloresapi.Filters;
using Proyectofloresapi.Models.ViewModelsFinca;
using Proyectofloresapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class FincaController : Controller
    {
        // GET: Finca
        public static string vistalista() {
            return "lst";
        }
        public static string vistaNuevafinca()
        {
            return "model";
        }
        public static string vistaEditarfinca()
        {
            return "model";
        }
        public static string vistaEliminarFinca()
        {
            return "model";
        }
        proyectofloresEntities db = new proyectofloresEntities();

        //[AuthorizeUser(idOperacion:1)]
        public ActionResult ListaFinca()
        {
            List<ListFincaViewModel>  lst;

            lst = (from fi in db.finca
                             join de in db.departamentos
                             on fi.iddepartamento_ equals de.iddepartamento
                             join mu in db.municipios
                             on fi.idmunicipio equals mu.idmunicipio
                             select new ListFincaViewModel
                             {
                                 Idfinca = fi.idfinca,
                                 Nombrefinca = fi.nombrefinca,
                                 Iddepartamento_ = fi.iddepartamento_,
                                 Namedepartamento = de.nombre,
                                 Idmunicipio = fi.idmunicipio,
                                 Namemunicipio = mu.nombre

                             }).ToList();

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();
        
        //[AuthorizeUser(idOperacion:2)]
        public ActionResult NuevaFinca()
        {
            List<departamentos> departamentosList = sd.departamentos.ToList();
            ViewBag.departamentosList = new SelectList(departamentosList, "iddepartamento", "nombre");
            return View();
        }

        public JsonResult GetMunicipioList(int iddepartamento)
        {
            sd.Configuration.ProxyCreationEnabled = false;
            List<municipios> selectList = sd.municipios.Where(x => x.iddepartamento == iddepartamento).ToList();
            return Json(selectList, JsonRequestBehavior.AllowGet);          
        }

        [HttpPost]       
        public ActionResult NuevaFinca(FincaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oFinca = new finca();

                        oFinca.nombrefinca = model.Nombrefinca;
                        oFinca.iddepartamento_ = model.Iddepartamento;
                        oFinca.idmunicipio = model.Idmunicipio;

                        db.finca.Add(oFinca);
                        db.SaveChanges();

                    }
                                
                    return Redirect("~/finca/ListaFinca");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      

        //editar finca
        //[AuthorizeUser(idOperacion:5)]
        public ActionResult EditarFinca(int Id)
        {
            List<departamentos> departamentosList = sd.departamentos.ToList();
            ViewBag.departamentosList = new SelectList(departamentosList, "iddepartamento", "nombre");

            FincaViewModel model = new FincaViewModel();
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oFinca = db.finca.Find(Id);
                model.Idfinca = oFinca.idfinca;
                model.Nombrefinca = oFinca.nombrefinca;
                model.Iddepartamento = oFinca.iddepartamento_;
                model.Idmunicipio = oFinca.idmunicipio;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarFinca(FincaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oFinca = db.finca.Find(model.Idfinca);
                        oFinca.idfinca = model.Idfinca;
                        oFinca.nombrefinca = model.Nombrefinca;
                        oFinca.iddepartamento_ = model.Iddepartamento;
                        oFinca.idmunicipio = model.Idmunicipio;

                        db.Entry(oFinca).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/finca/ListaFinca");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AuthorizeUser(idOperacion:6)]
        [HttpGet]
        public ActionResult EliminarFinca(int Id)
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oFinca = db.finca.Find(Id);
                db.finca.Remove(oFinca);
                db.SaveChanges();
            }
            return Redirect("~/finca/ListaFinca");
        }
    }
}