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

        public CUBuscarEspeciePorId(IRepositorioEspecie repoEspecie)
        {
            RepoEspecie = repoEspecie;
        }

        public EspecieDTO Buscar(int id)
        {
            var e = RepoEspecie.FindById(id);
            EspecieDTO especie = new EspecieDTO()
            {
                Id = e.Id,
                NombreCientifico = e.NombreCientifico,
                NombreComun = e.NombreComun,
                Descripcion = e.Descripcion.Value,
                PesoMinimo = e.PesoMinimo,
                PesoMaximo = e.PesoMaximo,
                LongitudMinima = e.LongitudMinima,
                LongitudMaxima = e.LongitudMaxima,
                ImagenEspecie = e.ImagenEspecie,
                EstadoCons = e.EstadoCons.Nombre.Value,
                Amenazas = e.Amenazas,
                habitats = e.habitats
    };

            return especie;
        }
    }
}
