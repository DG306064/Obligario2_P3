using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace LogicaAplicacion.CasosUso
{
    public class CUAltaEcosistema : IAltaEcosistema
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorio<EstadoConservacion> RepoEstadoConservacion { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }
        public IRepositorioPais RepoPaises { get; set; }

        public CUAltaEcosistema(IRepositorioEcosistema repoEcosistema,IRepositorio<EstadoConservacion> repoEstado, IRepositorio<RegistroDeCambios> 
                                repoRegistroCambios, IRepositorioPais repoPaises)
        {
            RepoEcosistema = repoEcosistema;
            RepoEstadoConservacion = repoEstado;
            RepoRegistroCambios = repoRegistroCambios;
            RepoPaises = repoPaises;
        }

    

        public void Alta(EcosistemaDTO eco, string nombreUsuario)
        {
            Ecosistema ecosistema = new Ecosistema()
            {
                Nombre = new Nombre(eco.Nombre),
                Latitud = eco.Latitud,
                Longitud = eco.Longitud,
                Area = eco.Area,
                Descripcion = new Descripcion(eco.Descripcion),
                Pais = RepoPaises.FindById(eco.IdPaisSeleccionado),
                EstadoConservacion = RepoEstadoConservacion.FindById(eco.IdEstadoConservacion),
                Amenazas = eco.Amenazas.Select(a => new Amenaza()
                {
                    Id = a.Id,
                    Descripcion = new Descripcion(a.Descripcion),
                    Peligrosidad = a.Peligrosidad
                }),
            ImagenEcosistema = eco.NombreImagenEcosistema
            };

            RepoEcosistema.Add(ecosistema);

            eco.Id = ecosistema.Id;

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = eco.Id,
                TipoDeEntidad = "Ecosistema",
                TipoDeModificacion = "ALTA"

            };

            RepoRegistroCambios.Add(registro);

        }
    }
}
