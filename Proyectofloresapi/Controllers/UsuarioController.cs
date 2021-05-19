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
                       join ro in db.rol
                       on usu.idrol equals ro.idrol
                       select new ListUsuarioViewModel
                       {
                           Idusuario = usu.idusuario,
                           Cedula = usu.cedula,
                           Nombres = usu.nombres,
                           Apellidos = usu.apellidos,
                           Idrol = usu.idrol,
                           Rolname = ro.nombre,
                           Email = usu.email
                       }).ToList();
            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

        //[AuthorizeUser(idOperacion: 15)]
        public ActionResult NuevoUsuario()
        {
            List<rol> RolList = sd.rol.ToList();
            ViewBag.rolList = new SelectList(RolList, "idrol", "nombre");

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
                        string contra = Guid.NewGuid().ToString();
                        var oUsuario = new usuario();

                        oUsuario.cedula = model.Cedula;
                        oUsuario.password = contra;
                        oUsuario.nombres = model.Nombres;
                        oUsuario.apellidos = model.Apellidos;
                        oUsuario.idrol = model.Idrol;
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
            List<rol> rolList = sd.rol.ToList();
            ViewBag.rolList = new SelectList(rolList, "idrol", "nombre");

            UsuarioViewModel mod = new UsuarioViewModel();

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oUsuario = db.usuario.Find(Id);

                mod.Idusuario = oUsuario.idusuario;
                mod.Cedula = oUsuario.cedula;
                mod.Password = oUsuario.password;
                mod.Nombres = oUsuario.nombres;
                mod.Apellidos = oUsuario.apellidos;
                mod.Idrol = oUsuario.idrol;
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
                        var oUsuario = db.usuario.Find(model.Idusuario);

                        oUsuario.idusuario = model.Idusuario;
                        oUsuario.cedula = model.Cedula;
                        oUsuario.password = model.Password;
                        oUsuario.nombres = model.Nombres;
                        oUsuario.apellidos = model.Apellidos;
                        oUsuario.idrol = model.Idrol;

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

    }
}