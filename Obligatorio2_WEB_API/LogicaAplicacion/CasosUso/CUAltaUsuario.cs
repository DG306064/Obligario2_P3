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
    public class CUAltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepoUsu { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repoUsu, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoUsu = repoUsu;
            RepoRegistroCambios = repoRegistroCambios;
        }



        public void AltaUsuario(Usuario obj, string nombreUsuario)
        {
            RepoUsu.Add(obj);

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
