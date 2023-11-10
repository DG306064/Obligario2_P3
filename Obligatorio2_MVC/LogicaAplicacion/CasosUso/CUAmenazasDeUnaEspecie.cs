using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAmenazasDeUnaEspecie : IAmenazasDeUnaEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }


        public CUAmenazasDeUnaEspecie(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }

        public IEnumerable<Amenaza> AmenazasDeLaEspecie(int idEspecie)
        {
            return repoEspecie.ObtenerAmenazas(idEspecie);
        }
    }
}
