using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectofloresapi.Models.ViewModelsFinca
{
    public class ListFincaViewModel
    {
        public int Idfinca { get; set; }
        public string Nombrefinca { get; set; }
        public long Iddepartamento_ { get; set; }
        public long Idmunicipio { get; set; }
    }
}