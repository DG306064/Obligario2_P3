using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerIdsDeAmenazasDeEspecies : IObtenerIdsDeAmenazasDeEspecies
    {

        public IRepositorioAmenaza repoAmenaza { get; set; }

        public CUObtenerIdsDeAmenazasDeEspecies(IRepositorioAmenaza RepoEsp)
        {
            repoAmenaza = RepoEsp;
        }


        public IEnumerable<int> ObtenerIdsDeAmenazasDeEspecies(int idEspecie)
        {
            return repoAmenaza.IdsDeLasAmenazasDeUnaEspecie(idEspecie);
        }
    }
}
