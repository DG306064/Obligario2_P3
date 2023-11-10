using LogicaNegocio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public string RolSeleccionado { get; set; }

        [Display(Name ="Confirmar contraseña")]
        public string ContraseñaAConfirmar { get; set; }


    }
}
