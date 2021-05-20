using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectofloresapi.Models.ViewModelsFinca
{
    public class FincaViewModel
    {
        public int Idfinca { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Finca_errorm_nombre")]
        [StringLength(50)]
        [Display(ResourceType = typeof(Recurso), Name = "Finca_Lista_nombre")]
        public string Nombrefinca { get; set; }

        [Required]
        [Display(ResourceType =typeof(Recurso), Name = "Finca_Lista_region")]
        public int Iddepartamento { get; set; }

        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Finca_Lista_ciudad")]
        public int Idmunicipio { get; set; }


    }
}