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
            Ecosistema eco = new Ecosistema
            {
                Id = obj.Id,
                Nombre = new Nombre(obj.Nombre),
                Latitud = obj.Latitud,
                Longitud = obj.Longitud,
                Area = obj.Area,
                Descripcion = new Descripcion(obj.Descripcion),
                Pais = new Pais
                { 
                    Id = obj.Pais.Id,
                    CodigoIsoAlpha = obj.Pais.CodigoIsoAlpha,
                    Nombre = new Nombre(obj.Pais.Nombre)
                },
                EstadoConservacion = RepoEstadoConservacion.FindById(obj.IdEstadoConservacion),
                Amenazas = obj.Amenazas.Select(a => new Amenaza
                {
                    Id = a.Id,
                    Descripcion = new Descripcion(a.Descripcion),
                    Peligrosidad = a.Peligrosidad
                }),
                ImagenEcosistema = obj.NombreImagenEcosistema
            };
            RepoEcosistema.Update(eco);
        }
    }
}
