using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }
        public IRepositorio<EstadoConservacion> RepoEstadoConservacion { get; set; }


        public CUAltaEspecie(IRepositorioEspecie RepoEsp, IRepositorio<RegistroDeCambios> repoRegistroCambios, IRepositorio<EstadoConservacion> repoEstadoConservacion)
        {
            RepoEspecie = RepoEsp;
            RepoRegistroCambios = repoRegistroCambios;
            RepoEstadoConservacion = repoEstadoConservacion;
        }

        public void Add(EspecieDTO obj, string nombreUsuario)
        {
            Especie especie = new Especie()
            {
                Id = obj.Id,
                NombreCientifico = obj.NombreCientifico,
                NombreComun = new Nombre(obj.NombreComun),
                Descripcion = new Descripcion(obj.Descripcion),
                PesoMinimo = obj.PesoMinimo,
                PesoMaximo = obj.PesoMaximo,
                LongitudMinima = obj.LongitudMinima,
                LongitudMaxima = obj.LongitudMaxima,
                ImagenEspecie = obj.ImagenEspecie,
                EstadoCons = RepoEstadoConservacion.FindById(obj.IdEstadoCons),
                Amenazas = Enumerable.Empty<Amenaza>(),
                Habitats = Enumerable.Empty<Habitat>()
            };

            RepoEspecie.Add(especie);

            obj.Id = especie.Id;

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = especie.Id,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "ALTA"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
