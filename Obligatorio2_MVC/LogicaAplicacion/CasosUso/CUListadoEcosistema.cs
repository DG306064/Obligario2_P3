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
    public class CUListadoEcosistema : IListadoEcosistemas
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public CUListadoEcosistema( IRepositorioEcosistema repo ) 
        {
            RepoEcosistema = repo;
        }




        public IEnumerable<EcosistemaDTO> Listado()
        {
            return RepoEcosistema.FindAll().Select(e => new EcosistemaDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                Descripcion = e.Descripcion,
                Pais = e.Pais.Nombre.Value,
                EstadoConservacion = e.EstadoConservacion.Nombre.Value,
                Amenazas = e.Amenazas,
                ImagenEcosistema = e.ImagenEcosistema
            });
        }
    }
}
