using Recursos;
using System.ComponentModel.DataAnnotations;

namespace Proyectofloresapi.Models.ViewModelUsuario
{
    public class UsuarioViewModel
    {
        public int Idusuario { get; set; }

        [Required]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_cedula")]
        public int Cedula { get; set; }

        [MinLength(6)]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_nombres")]
        public string Nombres { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_apellidos")]
        public string Apellidos { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Usuario_rol")]
        public int Idrol { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(ResourceType = typeof(Recurso), Name = "Usuario_correo")]
        public string Email { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

    }
}