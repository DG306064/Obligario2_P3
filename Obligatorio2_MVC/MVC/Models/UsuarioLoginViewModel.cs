using MVC.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UsuarioLoginViewModel
    {
        public DTOUsuario Usuario { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirmar contraseña")]
        public string PasswordAConfirmar { get; set; }
    }
}
