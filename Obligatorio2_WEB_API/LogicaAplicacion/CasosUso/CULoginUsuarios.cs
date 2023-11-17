using DTOs;
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
    public class CULoginUsuarios : ILoginUsuarios
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public CULoginUsuarios(IRepositorioUsuario repo)
        {
            RepoUsuarios = repo;
        }

        public UsuarioDTO Login(string alias, string password)
        {
            Usuario u = RepoUsuarios.Login(alias, password);
            if (u != null)
            {
                return new UsuarioDTO()
                {
                    Id = u.Id,
                    Alias = u.Alias,
                    Password = u.Password,
                    Rol = u.Rol
                };
            }
            else
            {
                return null;
            }
        }
    }
}
