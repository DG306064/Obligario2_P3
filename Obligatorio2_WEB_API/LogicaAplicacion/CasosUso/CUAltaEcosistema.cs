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
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAltaEcosistema(IRepositorioEcosistema repoEcosistema, IRepositorio<RegistroDeCambios> 
                                repoRegistroCambios)
        {
            RepoEcosistema = repoEcosistema;
            RepoRegistroCambios = repoRegistroCambios;
        }

    

        public void Alta(EcosistemaDTO eco, string nombreUsuario)
        {
            Ecosistema ecosistema = new Ecosistema()
            {
                Nombre = eco.Nombre,
                Latitud = eco.Latitud,
                Longitud = eco.Longitud,
                Area = eco.Area,
                Descripcion = eco.Descripcion,
                Pais = eco.Pais,
                EstadoConservacion = eco.EstadoConservacion,
                Amenazas = ConvertirAmenazas(eco.Amenazas),
                ImagenEcosistema = eco.ImagenEcosistema
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

        public IEnumerable<Amenaza> ConvertirAmenazas(IEnumerable<AmenazaDTO> amenazas)
        {
            return amenazas.Select(a => new Amenaza()
            {
                Id = a.Id,
                Descripcion = new Descripcion(a.Descripcion),
                Peligrosidad = a.Peligrosidad
            });
        }
    }
}
