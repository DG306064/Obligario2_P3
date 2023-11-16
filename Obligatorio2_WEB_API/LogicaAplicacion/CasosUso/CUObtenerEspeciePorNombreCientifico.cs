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
    public class CUObtenerEspeciePorNombreCientifico : IObtenerEspeciePorNombreCientifico
    {
        public IRepositorioEspecie repoEspecie { get; set; }

        public CUObtenerEspeciePorNombreCientifico(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }
        public EspecieDTO IObtenerEspeciePorNombreCientifico(string nombre)
        {
            var e = repoEspecie.EspeciePorNombreCientifico(nombre);

            var especie = new EspecieDTO()
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
                    Peligrosidad = a.Peligrosidad,
                })
                //Habitats = ConvertirHabitats(e.Habitats)
            };

            return especie;
        }
    }
}
