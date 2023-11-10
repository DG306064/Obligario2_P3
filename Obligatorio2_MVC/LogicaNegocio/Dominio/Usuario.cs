using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Alias requerido")]
        [MinLength(6, ErrorMessage = "El alias debe tener al menos 6 caracteres")]

        [Display(Name = "Usuario")]

        public string Alias { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; }

        public string HashedPassword { get; set; }

        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Rol requerido")]
        public string Rol { get; set; }

        public void Validate()
        {

            if (Password.Length < 8) throw new UsuarioException("La contraseña debe tener al menos 8 caracteres");
            if (Alias.Length < 6) throw new UsuarioException("El alias debe tener al menos 8 caracteres");
            if (FechaIngreso > DateTime.Today) throw new UsuarioException("La fecha de registro no es válida");
            if (string.IsNullOrEmpty(Password)) throw new UsuarioException("Debe ingresar una contraseña");
            if (string.IsNullOrEmpty(Alias)) throw new UsuarioException("Debe ingresar un alias");
            if (FechaIngreso == null) throw new UsuarioException("No se le adjudicó una fecha de ingreso");
            if (string.IsNullOrEmpty(Rol)) throw new UsuarioException("Debe ingresar una un rol");


            if (!Password.Any(l => char.IsLower(l))) throw new UsuarioException("La constraseña debe contener al menos una letra minúscula");
            if (!Password.Any(l => char.IsUpper(l))) throw new UsuarioException("La constraseña debe tener al menos una letra mayúscula");
            if (!Password.Any(l => char.IsDigit(l))) throw new UsuarioException("La constraseña debe tener al menos un número");

            if (!Password.Any(l => l == '.' || l == ',' || l == ';' || l == ':' || l == '!' || l == '#'))
            {
                throw new UsuarioException("La constraseña debe tener al menos un caracter del los siguientes:" + " ." + " ," + " :" + " ;" + " !");
            }
        }

    }
}

