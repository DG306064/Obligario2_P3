 using LogicaNegocio;



namespace MVC.Models
{
    public class UsuarioLoginViewModel
    {
        public Usuario Usuario { get; set; }
        public string alias { get; set; }
        public string password { get; set; }
    }
}
