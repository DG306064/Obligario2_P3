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
                Nombre = e.Nombre.Value,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                Descripcion = e.Descripcion.Value,
                Pais = new PaisDTO()
                {
                    Id = e.Pais.Id,
                    CodigoIsoAlpha = e.Pais.CodigoIsoAlpha,
                    Nombre = e.Pais.Nombre.Value,

                },
                EstadoConservacion = new EstadoConservacionDTO()
                {
                    Id = e.EstadoConservacion.Id,
                    Nombre = e.EstadoConservacion.Nombre.Value,
                    Valor = e.EstadoConservacion.Valor
                },
                Amenazas = e.Amenazas.Select(a=> new AmenazaDTO()
                {
                    Id = a.Id,
                    Descripcion = a.Descripcion.Value,
                    Peligrosidad = a.Peligrosidad
                }),
                ImagenEcosistema = e.ImagenEcosistema
            };

            return ecosistema;
        }
    }
}
