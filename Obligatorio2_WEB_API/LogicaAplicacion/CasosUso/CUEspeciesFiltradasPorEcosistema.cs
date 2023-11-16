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
            });

            return especiesDTO;
        }
    }
}
