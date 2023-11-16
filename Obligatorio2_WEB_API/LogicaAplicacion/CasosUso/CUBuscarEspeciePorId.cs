using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarEspeciePorId : IBuscarEspeciePorId
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUBuscarEspeciePorId(IRepositorioEspecie repoEspecie, IRepositorioAmenaza repoAmenaza)
        {
            RepoEspecie = repoEspecie;
            RepoAmenaza = repoAmenaza;
        }

        public EspecieDTO Buscar(int id)
        {
            var e = RepoEspecie.FindById(id);
            EspecieDTO especie = new EspecieDTO()
            {
                Id = e.Id,
                NombreCientifico = e.NombreCientifico,
                NombreComun = e.NombreComun.Value,
                Descripcion = e.Descripcion.Value,
                PesoMinimo = e.PesoMinimo,
                PesoMaximo = e.PesoMaximo,
                LongitudMinima = e.LongitudMinima,
                LongitudMaxima = e.LongitudMaxima,
                ImagenEspecie = e.ImagenEspecie,
                EstadoCons = new EstadoConservacionDTO()
                {
                    Id = e.EstadoCons.Id,
                    Nombre = e.EstadoCons.Nombre.Value,
                    Valor = e.EstadoCons.Valor
                },
                Amenazas = e.Amenazas.Select(a => new AmenazaDTO()
                {
                    Id = a.Id,
                    Descripcion = a.Descripcion.Value,
                    Peligrosidad = a.Peligrosidad
                }),
                Habitats = e.Habitats.Select(h => new HabitatDTO()
                {
                    Id = h.Id,
                    NombreEcosistema = h.Ecosistema.Nombre.Value,
                    Habita = h.Habita
                })
    };

            return especie;
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

        /*public IEnumerable<HabitatDTO> ConvertirHabitats(IEnumerable<Habitat> habitats)
        {
            return habitats.Select(h => new HabitatDTO()
            {
                Id = h.Id,
                Ecosistema = h.Ecosistema.Nombre.Value,
                Habita = h.Habita
            });
        }*/
    }
}
