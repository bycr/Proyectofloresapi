//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyectofloresapi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int cedula { get; set; }
        public string password { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int idrol { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public int idusuario { get; set; }
    
        public virtual rol rol { get; set; }
    }
}
