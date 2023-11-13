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
    public class CUBuscarEcosistemaPorNombre : IBuscarEcosistemaPorNombre
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }

        public CUBuscarEcosistemaPorNombre(IRepositorioEcosistema repo)
        {
            RepoEcosistema = repo;
        }
        public EcosistemaDTO BuscarEcosistemaPorNombre(string nombreEcosistema)
        {
            var e = RepoEcosistema.BuscarECosistemaPorNombre(nombreEcosistema);
            EcosistemaDTO ecosistema = new EcosistemaDTO()
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                Descripcion = e.Descripcion,
                Pais = e.Pais,
                EstadoConservacion = e.EstadoConservacion,
                Amenazas = ConvertirAmenazas(e.Amenazas),
                ImagenEcosistema = e.ImagenEcosistema
            };

            return ecosistema;
        }

        public IEnumerable<AmenazaDTO> ConvertirAmenazas(IEnumerable<Amenaza> amenazas)
        {
            return amenazas.Select(a => new AmenazaDTO()
            {
                Id = a.Id,
                Descripcion = a.Descripcion.Value,
                Peligrosidad = a.Peligrosidad
            });
        }
    }
}
