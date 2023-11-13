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
    public class CUObtenerAmenaza : IObtenerAmenaza
    {
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUObtenerAmenaza(IRepositorioAmenaza repoAmenaza)
        {
            RepoAmenaza = repoAmenaza;
        }
        public AmenazaDTO ObtenerAmenaza(int idAmenaza)
        {
            var amenaza = RepoAmenaza.FindById(idAmenaza);

            var amenazaDTO = new AmenazaDTO()
            {
                Id = amenaza.Id,
                Descripcion = amenaza.Descripcion.Value,
                Peligrosidad = amenaza.Peligrosidad,
                Ecosistemas = amenaza.Ecosistemas.Select(eco => eco.Nombre.Value),
                Especies = amenaza.Especies.Select(esp => esp.NombreComun.Value)
            };

            return amenazaDTO;  
        }
    }
}
