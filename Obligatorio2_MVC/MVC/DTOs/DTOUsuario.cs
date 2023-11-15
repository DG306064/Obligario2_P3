

namespace MVC.DTOs
{
    public class DTOUsuario
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Rol { get; set; }
    }
}
