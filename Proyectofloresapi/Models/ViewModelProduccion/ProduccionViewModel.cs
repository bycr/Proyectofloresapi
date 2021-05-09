using Recursos;

namespace Proyectofloresapi.Models
{
    public class ProduccionViewModel
    {
        public int Idproduccion { get; set; }
        public int Idfinca { get; set; }
        public int Numerobloque { get; set; }
        public string Variedadflor { get; set; }
        public int Plantas { get; set; }
        public double Areas { get; set; }
        public int Camas { get; set; }
        public int Nsemana { get; set; }
    }
}