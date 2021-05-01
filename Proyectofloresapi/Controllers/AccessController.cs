using System;
using System.Web.Http;
using Proyectofloresapi.Models.Ws;
using Proyectofloresapi.Models;
using System.Linq;

namespace Proyectofloresapi.Controllers
{
    public class AccessController : ApiController
    {
        [HttpPost]
        public Reply Login( [FromBody] AccessViewModel model)
        {
            Reply oR = new Reply();
            try
            {
                using (proyectofloresEntities db = new proyectofloresEntities())
                {
                    var lst = db.usuario.Where(d => d.cedula == model.cedula && d.password == model.password);

                    if (lst.Count() > 0)
                    {
                        //resultado es igual a 1
                        oR.result = 1;
                        //creamos el token con data
                        oR.data = Guid.NewGuid().ToString();

                        usuario oUsuario = lst.First();
                        oUsuario.token = (string)oR.data;
                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        oR.message = "Datos incorrectos";
                    }
                }

            }catch(Exception ex)
            {
                oR.result = 0;
                oR.message = "Ocurrio un error";
            }
            return oR;
        }

    }
}
