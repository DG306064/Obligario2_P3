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
    public class CUBajaUsuario : IBajaUsuario
    {
        public IRepositorioUsuario RepoUsu { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUBajaUsuario(IRepositorioUsuario repoUsu, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoUsu = repoUsu;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void BajaUsuario(UsuarioDTO obj, string nombreUsuario)
        {
            var usuario = new Usuario() { Id = obj.Id };
            RepoUsu.Remove(usuario);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Usuario",
                TipoDeModificacion = "BAJA"

            };



            RepoRegistroCambios.Add(registro);



        }
    }
}
