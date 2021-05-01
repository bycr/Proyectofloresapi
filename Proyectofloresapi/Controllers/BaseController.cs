using System.Linq;
using System.Web.Http;
using Proyectofloresapi.Models;

namespace Proyectofloresapi.Controllers
{
    public class BaseController : ApiController
    {
        public bool verify (string token)
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                if (db.usuario.Where(d => d.token == token). Count() >0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
