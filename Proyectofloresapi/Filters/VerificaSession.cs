using Proyectofloresapi.Controllers;
using Proyectofloresapi.Models;
using Proyectofloresapi.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Proyectofloresapi.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                //verificamos la sesion del controlador
                oUsuario = (usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }

    }
}