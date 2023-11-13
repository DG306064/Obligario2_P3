using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUModificarUsuario : IModificarUsuario
    {
        public IRepositorioUsuario RepoUsu { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUModificarUsuario(IRepositorioUsuario repoUsu, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoUsu = repoUsu;
            RepoRegistroCambios = repoRegistroCambios;
        }
        public void Modificar(UsuarioDTO usuario, string nombreUsuario)
        {
            var usu = new Usuario()
            {
                Id = usuario.Id,
                Alias = usuario.Alias,
                Password = usuario.Password,
                HashedPassword = usuario.HashedPassword
            };
            RepoUsu.Update(usu);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = usuario.Id,
                TipoDeEntidad = "Usuario",
                TipoDeModificacion = "MODIFICACIÓN"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
