using Proyectofloresapi.Models.ViewModelsFinca;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyectofloresapi.Models.ViewModelInvernadero
{
    public class ListInvernaderoViewModel
    {
        public int Idinvernadero { get; set; }
        public int Numeroinvernadero { get; set; }
        public int Idfinca { get; set; }
        public string Namefinca { get; set; }



    }
}