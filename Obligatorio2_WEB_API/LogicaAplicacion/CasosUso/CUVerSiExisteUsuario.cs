using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUVerSiExisteUsuario : IVerSiExisteUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUVerSiExisteUsuario(IRepositorioUsuario repoUsu)
        {
            RepoUsuario = repoUsu;

        }


        public bool VerSiExisteUsuario(string alias)
        {
            return RepoUsuario.VerSiExisteUsuario(alias);
        }
    }
}
