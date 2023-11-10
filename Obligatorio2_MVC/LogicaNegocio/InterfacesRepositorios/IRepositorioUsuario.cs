using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> ObtenerUsuarioParaLogear(string alias, string password);

        bool VerSiExisteUsuario(string alias);
    }
}
