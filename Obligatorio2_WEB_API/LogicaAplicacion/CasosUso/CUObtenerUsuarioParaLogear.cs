using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerUsuarioParaLogear : IObtenerUsuarioParaLogear
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUObtenerUsuarioParaLogear(IRepositorioUsuario repoUsu)
        {
            RepoUsuario = repoUsu;
        }


        public IEnumerable<Usuario> ObtenerUsuarioParaLogear(string alias, string password)
        {
            return RepoUsuario.ObtenerUsuarioParaLogear(alias, password);
        }
    }
}
