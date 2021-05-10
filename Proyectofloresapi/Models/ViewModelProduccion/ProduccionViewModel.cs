using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectofloresapi.Models
{
    public class ProduccionViewModel
    {
        public int Idproduccion { get; set; }
        [Display(ResourceType = typeof(Recurso), Name = "Finca_Lista_nombre")]
        public int Idfinca { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_numero")]
        public int Numerobloque { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Variedad_flor")]
        public string Variedadflor { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "")]
        public int Plantas { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Produccion_area")]
        public double Areas { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Produccion_camas")]
        public int Camas { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "")]
        public int Nsemana { get; set; }
    }
}