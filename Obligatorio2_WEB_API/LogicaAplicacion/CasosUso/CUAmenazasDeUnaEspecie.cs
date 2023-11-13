using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUAmenazasDeUnaEspecie : IAmenazasDeUnaEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }


        public CUAmenazasDeUnaEspecie(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }

        public IEnumerable<AmenazaDTO> AmenazasDeLaEspecie(int idEspecie)
        {
            var amenazas = repoEspecie.ObtenerAmenazas(idEspecie);

            var amenazasDTO = amenazas.Select(a => new AmenazaDTO()
            {
                Id = a.Id,
                Descripcion = a.Descripcion.Value,
                Peligrosidad = a.Peligrosidad
            });

            return amenazasDTO;
        }
    }
}
