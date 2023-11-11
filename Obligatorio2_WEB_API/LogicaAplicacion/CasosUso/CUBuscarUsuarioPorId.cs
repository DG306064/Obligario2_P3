using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarUsuarioPorId : IBuscarUsuarioPorId
    {
        public IRepositorioUsuario RepoUsu { get; set; }

        public CUBuscarUsuarioPorId(IRepositorioUsuario repoUsu)
        {
            RepoUsu = repoUsu;
        }
        public UsuarioDTO BuscarPorId(int idUsuario)
        {
            Usuario u = RepoUsu.FindById(idUsuario);
            UsuarioDTO usuario = new UsuarioDTO()
            {
                Id = u.Id,
                Alias = u.Alias
            };

            return usuario;
        }
    }
}
