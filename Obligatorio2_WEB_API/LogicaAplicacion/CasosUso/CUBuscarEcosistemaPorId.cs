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
    public class CUBuscarEcosistemaPorId : IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema RepoEco { get; set; }

        public CUBuscarEcosistemaPorId(IRepositorioEcosistema repoEco)
        {
            RepoEco = repoEco;

        }

        
        public EcosistemaDTO BuscarEcoPorId(int id)
        {
            var e = RepoEco.FindById(id);
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
                Descripcion = a.Descripcion,
                Peligrosidad = a.Peligrosidad
            });
        }
    }
}
