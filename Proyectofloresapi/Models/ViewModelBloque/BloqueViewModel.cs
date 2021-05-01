using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectoflores.Models.ViewModelBloque
{
    public class BloqueViewModel
    {
      
        public int Idbloque { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_numero")]
        public int Numerobloque { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_presupuestadoaño")]
        public double Presupuestadoaño { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_llevamosaño")]
        public double Llevamosaño { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_diferenciaaño")]
        public double Diferenciaaño { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_presupuestadomes")]
        public double Presupuestadomes { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_llevamosmes")]
        public double Llevamosmes { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Bloque_diferenciames")]
        public double Diferenciames { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_cedula")]
        public int Cedula { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Invernadero_numero")]
        public int Idinvernadero { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Invernadero_finca")]
        public int Idfinca { get; set; }
        public System.DateTime Fechacreado { get; set; }
    }
}