using Proyectofloresapi.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class AnalisisController : Controller
    {
        // GET: Analisis
        public ActionResult ListaAnalisis()
        {
            using (proyectofloresEntities db = new proyectofloresEntities())
            {

                var oBloque = new bloque();

                var query = (from c in db.bloque
                             select c.diferenciaaño).ToArray();

                //hallar el minimo valor
                var min = query.Min();
                //hallar el maximo valor
                var max = query.Max();

                int bloquecount = db.bloque.Count();
                Console.WriteLine(bloquecount);

                //cargar los datos de la base al array 
                double[] vector = query;

                //numero de datos que vienen de la base de datos
                int columnas = bloquecount;

                //calculamos el numero de intervalos
                double intervalos = Math.Log(columnas + 1, 2);

                //redondeamos el numero de intervalos
                int redondeo = (int)Math.Round(intervalos);

                //hallar el rango 
                int rango = (int)(max - min);
                Console.WriteLine(rango);

                //amplitud de intervalos
                double amp_Rango = rango / redondeo;
                Console.WriteLine(amp_Rango);

                double[] linf = new double [redondeo];
                double[] lsup = new double [redondeo];
                double[] mclase = new double[redondeo];
                double[] fabsoluta = new double[redondeo];
                double[] frelativa = new double[redondeo];
                double[] xf = new double[redondeo];

                for (int i = 0; i<redondeo; i++)
                {
                    if (i ==0) {
                        linf[i] = min;
                        ViewBag.linf = linf;
                    }   

                    for(int j = 0; j < redondeo; j++)
                    {
                        if (i == 0)
                        {
                            lsup[j] = linf[i] + amp_Rango;
                        }

                        if(i > 0 && j > 0)
                        {
                            linf[i] = lsup[j - 1] + 0.1;
                            
                        }

                        if (j > 0)
                        {
                            lsup[j] = linf[i] + amp_Rango;
                        }

                        ViewBag.lsup = lsup;
                        
                    }
                }

                //marca de clase
                int l = 0, m = 0;
                for (int k = 0; k < redondeo; k++)
                {                 
                    mclase[k] = ((linf[l] + lsup[m]) / 2);
                    l++;
                    m++;
                }
                ViewBag.marca_clase = mclase;

                //frecuencia absoluta
                l = 0; m = 0;
                double acumulado = 0;
                int o;
                for (int n = 0; n < redondeo; n++)
                {
                    for (o = 0; o < columnas; o++)
                    {
                        if (vector[o] >= linf[l] && vector[o] <= lsup[m])
                        {
                            fabsoluta[n] += 1;
                        }
                    }
                    l++;
                    m++;

                    acumulado += fabsoluta[n];
                }
                ViewBag.fabsoluta = fabsoluta;

                //frecuencia relativa 
                o = 0;
                for (int p = 0; p<redondeo; p++)
                {
                    frelativa[p] = fabsoluta[o] / acumulado;
                    o++;
                }
                ViewBag.frelativa = frelativa;

                //xf
                int mc = 0, fa = 0;
                double acumxf = 0;
                for (int q = 0; q<redondeo; q++)
                {
                    xf[q] = mclase[mc] * fabsoluta[fa];
                    acumxf += xf[q];
                    mc++;
                    fa++;
                }
                ViewBag.xf = xf;

                //media
                double media = acumxf / acumulado;
                ViewBag.media = media;

                //moda


                return View();
            }
        }
    }
}