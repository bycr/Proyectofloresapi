﻿using Proyectofloresapi.Models;
using Proyectofloresapi.Models.ViewModelProduccion;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace Proyectofloresapi.Controllers
{
    public class ProduccionController : Controller
    {
        // GET: Produccion
        public ActionResult ListaProduccion()
        {
            List<ListProduccionViewModel> lst;

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                lst = (from d in db.produccion
                       select new ListProduccionViewModel
                       {
                           Idproduccion = d.idproduccion,
                           Idfinca = d.idfinca,
                           Numerobloque = d.numerobloque,
                           Variedadflor = d.variedadflor,
                           Plantas = d.plantas,
                           Areas = d.areas,
                           Camas = d.camas,
                           Nsemana = d.nsemana

                       }).ToList();
            }

            return View(lst);
        }

        proyectofloresEntities sd = new proyectofloresEntities();

        public ActionResult NuevaProduccion()
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");
            return View();
        }

        [HttpPost]
        public ActionResult NuevaProduccion(ProduccionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oProduccion = new produccion();

                        oProduccion.idfinca = model.Idfinca;
                        oProduccion.numerobloque = model.Numerobloque;
                        oProduccion.variedadflor = model.Variedadflor;
                        oProduccion.plantas = model.Plantas;
                        oProduccion.areas = model.Areas;
                        oProduccion.camas = model.Camas;
                        oProduccion.nsemana = model.Nsemana;

                        db.produccion.Add(oProduccion);
                        db.SaveChanges();

                    }
                    return Redirect("~/Produccion/ListaProduccion");
                }
                return View(model);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //Editar produccion
        public ActionResult EditarProduccion(int Id)
        {
            List<finca> fincaList = sd.finca.ToList();
            ViewBag.fincaList = new SelectList(fincaList, "idfinca", "nombrefinca");

            ProduccionViewModel mod = new ProduccionViewModel();

            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oProduccion = db.produccion.Find(Id);
                mod.Idproduccion = oProduccion.idproduccion;
                mod.Idfinca = oProduccion.idfinca;
                mod.Numerobloque = oProduccion.numerobloque;
                mod.Variedadflor = oProduccion.variedadflor;
                mod.Plantas = oProduccion.plantas;
                mod.Areas = oProduccion.areas;
                mod.Camas = oProduccion.camas;
                mod.Nsemana = oProduccion.nsemana;
            }

            return View(mod);
        }

        [HttpPost]
        public ActionResult EditarProduccion(ProduccionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (proyectofloresEntities db = new proyectofloresEntities())
                    {
                        var oProduccion = db.produccion.Find(model.Idproduccion);
                        oProduccion.idproduccion = model.Idproduccion;
                        oProduccion.idfinca = model.Idfinca;
                        oProduccion.numerobloque = model.Numerobloque;
                        oProduccion.variedadflor = model.Variedadflor;
                        oProduccion.plantas = model.Plantas;
                        oProduccion.areas = model.Areas;
                        oProduccion.camas = model.Camas;
                        oProduccion.nsemana = model.Nsemana;

                        db.Entry(oProduccion).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Produccion/ListaProduccion");
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
        public ActionResult EliminarProduccion(int Id)
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                var oProduccion = db.produccion.Find(Id);
                db.produccion.Remove(oProduccion);
                db.SaveChanges();
            }
            return Redirect("~/Invernadero/ListaInvernadero");
        }

    }
}