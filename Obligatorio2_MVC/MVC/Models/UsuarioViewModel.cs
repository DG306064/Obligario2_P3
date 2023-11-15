using MVC.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Rol { get; set; }
        
        


    }
}
