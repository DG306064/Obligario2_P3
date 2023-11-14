using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoEspecie : IListadoEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUListadoEspecie(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }


        public IEnumerable<EspecieDTO> Listado()
        {
            return RepoEspecie.FindAll().Select(e => new EspecieDTO
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
        }
    }
}
 
 




