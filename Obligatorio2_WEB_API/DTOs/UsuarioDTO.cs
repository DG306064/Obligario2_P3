using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Rol { get; set; }
    }
}
