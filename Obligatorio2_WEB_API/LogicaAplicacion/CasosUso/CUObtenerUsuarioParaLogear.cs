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
    public class CUObtenerUsuarioParaLogear : IObtenerUsuarioParaLogear
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUObtenerUsuarioParaLogear(IRepositorioUsuario repoUsu)
        {
            RepoUsuario = repoUsu;
        }


        public UsuarioDTO ObtenerUsuarioParaLogear(string alias, string password)
        {
            var usu = RepoUsuario.ObtenerUsuarioParaLogear(alias, password);

            var usuario = new UsuarioDTO()
            {
                Alias = usu.Alias,
                Password = usu.Password,
                HashedPassword = usu.HashedPassword
            };

            return usuario;
        }
    }
}
