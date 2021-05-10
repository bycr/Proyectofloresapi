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

        [NotMapped]
        public List<ListFincaViewModel> ListFincaViewModelCollection { get; set; }
    }
}