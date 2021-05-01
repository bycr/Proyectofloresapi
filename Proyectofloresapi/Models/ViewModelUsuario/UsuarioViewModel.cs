using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectoflores.Models.ViewModelUsuario
{
    public class UsuarioViewModel
    {
        [Required]
        [Display (ResourceType = typeof(Recurso), Name = "Usuario_cedula")]
        public int Cedula { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_contraseña")]
        public string Password { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_apellidos")]
        public string Apellidos { get; set; }
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_rol")]
        public int Idrol { get; set; }
        [Display(ResourceType = typeof(Recurso), Name = "Finca_Lista_nombre")]
        public int Idfinca { get; set; }
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_correo")]
        public string Email { get; set; }
        public string Token { get; set; }

    }
}