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
    public class CUEspeciesFiltradasPorEcosistema : IEspeciesFiltradasPorEcosistema
    {
            public IRepositorioEspecie repoEspecie { get; set; }

            public CUEspeciesFiltradasPorEcosistema(IRepositorioEspecie RepoEsp)
            {
                repoEspecie = RepoEsp;
            }

        public IEnumerable<EspecieDTO> EspeciesFIltradasPorEcosistema(string nombreEcosistema)
        {
            var especies = repoEspecie.especiesFiltradasPorEcosistema(nombreEcosistema);

            var especiesDTO = especies.Select(e => new EspecieDTO()
            {
                Id = e.Id,
                NombreCientifico = e.NombreCientifico,
                TextoNombreComun = e.NombreComun.Value,
                TextoDescripcion = e.Descripcion.Value,
                PesoMinimo = e.PesoMinimo,
                PesoMaximo = e.PesoMaximo,
                LongitudMinima = e.LongitudMinima,
                LongitudMaxima = e.LongitudMaxima,
                ImagenEspecie = e.ImagenEspecie,
                EstadoCons = e.EstadoCons,
                Amenazas = ConvertirAmenazas(e.Amenazas)
            });

            return especiesDTO;
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
