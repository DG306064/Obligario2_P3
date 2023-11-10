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
    public class CUBuscarUsuarioPorId : IBuscarUsuarioPorId
    {
        public IRepositorioUsuario RepoUsu { get; set; }

        public CUBuscarUsuarioPorId(IRepositorioUsuario repoUsu)
        {
            RepoUsu = repoUsu;
        }
        public Usuario BuscarPorId(int idUsuario)
        {
           return RepoUsu.FindById(idUsuario);
        }
    }
}
