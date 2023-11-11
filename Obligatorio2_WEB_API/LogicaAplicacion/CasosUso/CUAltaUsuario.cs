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
using ExcepcionesPropias;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepoUsu { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repoUsu, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoUsu = repoUsu;
            RepoRegistroCambios = repoRegistroCambios;
        }



        public void AltaUsuario(UsuarioDTO obj, string nombreUsuario)
        {
            if (obj == null) throw new UsuarioException("El usuario no puede ser nulo.");

            Usuario usuario = new Usuario()
            {
                Id = obj.Id,
                Alias = obj.Alias,
                Password = obj.Password,
                HashedPassword = obj.HashedPassword
            };

            RepoUsu.Add(usuario);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Usuario",
                TipoDeModificacion = "ALTA"

            };



            RepoRegistroCambios.Add(registro);

        }
    }
}
