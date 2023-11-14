using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;
using LogicaNegocio.ValueObjects;
using LogicaNegocio.RegistrodeCambios;

namespace LogicaAplicacion.CasosUso
{
    public class CUActualizarEcosistema : IActualizarEcosistema
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorio<EstadoConservacion> RepoEstadoConservacion { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public IRepositorioAmenaza RepositorioAmenaza { get; set; }

        public CUActualizarEcosistema(IRepositorioEcosistema repoEcosistema, IRepositorio<EstadoConservacion> repoEstado, IRepositorio<RegistroDeCambios>
                                repoRegistroCambios, IRepositorioAmenaza repoAmenaza)
        {
            RepoEcosistema = repoEcosistema;
            RepoEstadoConservacion = repoEstado;
            RepoRegistroCambios = repoRegistroCambios;
            RepositorioAmenaza = repoAmenaza;
        }

        public void Actualizar(EcosistemaDTO obj)
        {
            Ecosistema eco = RepoEcosistema.FindById(obj.Id);
            eco.Nombre = new Nombre(obj.Nombre);
            eco.Latitud = obj.Latitud;
            eco.Longitud = obj.Longitud;
            eco.Area = obj.Area;
            eco.Descripcion = new Descripcion(eco.Descripcion.Value);
            eco.Pais = new Pais(){Id = obj.Pais.Id};
            eco.EstadoConservacion = RepoEstadoConservacion.FindById(obj.IdEstadoConservacion);
            eco.Amenazas = obj.Amenazas.Select(a => RepositorioAmenaza.FindById(a.Id));
            eco.ImagenEcosistema = obj.ImagenEcosistema;

            RepoEcosistema.Update(eco);
        }
    }
}
