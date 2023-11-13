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
    public class CUListadoAmenaza : IListadoAmenaza
    {
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUListadoAmenaza(IRepositorioAmenaza repoAmenaza)
        {
            RepoAmenaza = repoAmenaza;
        }


        public IEnumerable<AmenazaDTO> ListadoAmenaza()
        {
            var amenazas = RepoAmenaza.FindAll();

            var amenazasDTO = amenazas.Select(a => new AmenazaDTO()
            {
                Id = a.Id,
                Descripcion = a.Descripcion.Value,
                Peligrosidad = a.Peligrosidad

            });

            return amenazasDTO
        }
    }
}
