using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyectofloresapi.Filters;
using Proyectofloresapi.Models;
using Proyectofloresapi.Models.ViewModelUsuario;

namespace Proyectofloresapi.Controllers
{
    public class UsuarioController : Controller
    {

        public static string vistalistaUsuario()
        {
            return "lst";
        }
        public static string vistaNuevoUsuario()
        {
            return "model";
        }
        public static string vistaEditarUsuario()
        {
            return "mod";
        }
        public static string vistaEliminarUsuario()
        {
            return "view";
        }

        // GET: Usuario
        //[AuthorizeUser(idOperacion: 14)]
        public ActionResult ListaUsuario()
        {
            List<ListUsuarioViewModel> lst;
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from usu in db.usuario
                       join fi in db.finca
                       on usu.idfinca equals fi.idfinca
                       join ro in db.rol
                       on usu.idrol equals ro.idrol
                       select new ListUsuarioViewModel
                       {
                           Cedula = usu.cedula,
                           Nombres = usu.nombres,
                           Apellidos = usu.apellidos,
                           Idrol = usu.idrol,
                           Rolname = ro.nombre,
                           Idfinca = usu.idfinca,
                           Namefinca = fi.nombrefinca,
                           Email = usu.email
                       }).ToList();
            }

            return View(lst);
        }

        proyectofloresEntities db = new proyectofloresEntities();

        //[AuthorizeUser(idOperacion: 15)]
        public ActionResult NuevoUsuario()
        {
            List<rol> rolList = db.rol.ToList();
            ViewBag.rolList = new SelectList(rolList, "idrol", "nombre");

            List<finca> fincaList = db.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oUsuario = new usuario();

                        oUsuario.cedula = model.Cedula;
                        oUsuario.password = model.Password;
                        oUsuario.nombres = model.Nombres;
                        oUsuario.apellidos = model.Apellidos;
                        oUsuario.idrol = model.Idrol;
                        oUsuario.idfinca = model.Idfinca;
                        oUsuario.email = model.Email;

                        db.usuario.Add(oUsuario);
                        db.SaveChanges();

                    }

                    return Redirect("~/Usuario/ListaUsuario");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[AuthorizeUser(idOperacion: 16)]
        public ActionResult EditarUsuario(int Id)
        {
            List<rol> rolList = db.rol.ToList();
            ViewBag.rolList = new SelectList(rolList, "idrol", "nombre");

            List<finca> fincaList = db.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

            UsuarioViewModel mod = new UsuarioViewModel();
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oUsuario = db.usuario.Find(Id);
                mod.Cedula = oUsuario.cedula;
                mod.Password = oUsuario.password;
                mod.Nombres = oUsuario.nombres;
                mod.Apellidos = oUsuario.apellidos;
                mod.Idrol = oUsuario.idrol;
                mod.Idfinca = oUsuario.idfinca;
                mod.Email = oUsuario.email;
            }

            return View(mod);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oUsuario = db.usuario.Find(model.Cedula);

                        oUsuario.cedula = model.Cedula;
                        oUsuario.password = model.Password;
                        oUsuario.nombres = model.Nombres;
                        oUsuario.apellidos = model.Apellidos;
                        oUsuario.idrol = model.Idrol;
                        oUsuario.idfinca = model.Idfinca;
                        oUsuario.email = model.Email;

                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }

                    return Redirect("~/Usuario/ListaUsuario");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eliminar 
        //[AuthorizeUser(idOperacion: 17)]
        [HttpGet]
        public ActionResult EliminarUsuario(int Id)
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oUsuario = db.usuario.Find(Id);
                db.usuario.Remove(oUsuario);
                db.SaveChanges();
            }
            return Redirect("~/Usuario/ListaUsuario");
        }

    }
}