using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoUsuario : IListadoUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repoUsu)
        {
            RepoUsuario = repoUsu;
        }


        public IEnumerable<UsuarioDTO> Listado()
        {
            return RepoUsuario.FindAll().Select(e => new UsuarioDTO
            {
                Id = e.Id,
                Alias = e.Alias
            });
        }
    }
}
