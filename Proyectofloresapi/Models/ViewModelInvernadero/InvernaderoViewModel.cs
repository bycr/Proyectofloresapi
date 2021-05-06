using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectofloresapi.Models.ViewModelInvernadero
{
    public class InvernaderoViewModel
    {
       
        public int Idinvernadero { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Invernadero_errorm_numero")]
        [Display (ResourceType =typeof(Recurso), Name = "Invernadero_numero")]
        public int Numeroinvernadero { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Invernadero_finca")]
        public int Idfinca { get; set; }

    }
}