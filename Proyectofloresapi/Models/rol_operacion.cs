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
    
    public partial class rol_operacion
    {
        public int idrolope { get; set; }
        public int idrol { get; set; }
        public int idoperacion { get; set; }
    
        public virtual operaciones operaciones { get; set; }
        public virtual rol rol { get; set; }
    }
}
