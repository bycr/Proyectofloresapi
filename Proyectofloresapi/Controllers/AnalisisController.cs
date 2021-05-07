using Proyectofloresapi.Models;
using System;
using System.Collections.Generic;
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

                int aux1 = 0;
                int contador_valores = 0;
                int valor_secundario = 0;
                var container = 0;
                int aux2 = 0;
                int aux3 = 0;
                int maxRep = 0;
                int moda = 0;
                double[] marcaclase = new double[redondeo];
                double[] frecuencia_absoluta = new double[redondeo];
                double[] frecuencia_relativa = new double[redondeo];

                do
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (aux1 == 0)
                        {
                            if (vector[j] >= min && vector[j] <= min + amp_Rango)
                            {
                                contador_valores = contador_valores + 1;
                            }
                        }
                        else
                        {
                            if (vector[j] >= min && vector[j] <= valor_secundario)
                            {
                                contador_valores = contador_valores + 1;
                            }
                        }
                        //vector[j] = datos1[j];
                        //calculo media
                        container = (int)(container + vector[j]);


                        //marca de clase 
                        double marca_clase = (double)((valor_secundario + min) / 2);

                        for (int i = 0; i < redondeo; i++)
                        {
                            marcaclase[i] = marca_clase;
                        }
                        ViewBag.marca_clase = marcaclase;
                        //Console.WriteLine(marca_clase);

                        //frecuencia absoluta
                        for (int k = 0; k < redondeo; k++)
                        {
                            frecuencia_absoluta[k] = contador_valores;
                        }
                        ViewBag.fabsoluta = frecuencia_absoluta;
                        //Console.WriteLine("frecuencia absoluta : " + contador_valores);

                        //calculo de frecunecia relativa
                        float f_relativa = (float)contador_valores / bloquecount;
                        for (int k = 0; k < redondeo; k++)
                        {
                            frecuencia_relativa[k] = f_relativa;
                        }
                        ViewBag.frelativa = frecuencia_relativa;
                        Console.WriteLine("frecuencia relativa : " + f_relativa);

                    }

                    aux1 += 1;
                    aux2 += 2;

                    contador_valores = 0;
                    min = valor_secundario + 1;

                } while (aux1 != redondeo);

                //Media
                float container2 = (float)container / columnas;
                Console.WriteLine("Media = " + container2);

                //Mediana
                if (columnas % 2 == 0)
                {
                    float mediana = (float)(((columnas) / 2) + ((columnas + 1) / 2)) / 2;
                    mediana = (float)Math.Truncate(mediana);


                    for (int i = 0; i < columnas; i++)
                    {
                        if (i == mediana)
                        {
                            Console.WriteLine("mediana = " + vector[i]);
                            ViewBag.mediana = vector;
                        }
                    }
                }
                else
                {
                    float mediana = (float)(columnas + 1) / 2;
                    mediana = (float)Math.Truncate(mediana);

                    for (int i = 0; i < columnas; i++)
                    {
                        if (i == mediana)
                        {
                            Console.WriteLine("mediana = " + vector[i]);
                        }
                    }
                }

                //Moda

                for (int i = 0; i < columnas; i++)
                {
                    int f = 0;
                    for (int j = 0; j < columnas; j++)
                    {
                        if (vector[i] == vector[j])
                        {
                            aux3 = aux3 + 1;
                        }

                        if (f > maxRep)
                        {
                            moda = (int)vector[i];
                            maxRep = aux3;
                        }
                    }
                }
                Console.WriteLine("moda : " + moda);
                ViewBag.moda = moda;

                List<double> lst = vector.ToList();
                ViewBag.vector = lst;

                //pasar datos del array o la lista al dato1 en el modelo prueba                

                return View();
            }
        }
    }
}