using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerIdsDeAmenazasDelEcosistema : IObtenerIdsDeAmenazasDelEcosistema
    {

        public IRepositorioAmenaza repoAmenaza { get; set; }

        public CUObtenerIdsDeAmenazasDelEcosistema(IRepositorioAmenaza RepoEsp)
        {
            repoAmenaza = RepoEsp;
        }


        public IEnumerable<int> ObtenerIdsDeAmenazasDelEcosistema(int idEcosistema)
        {
            return repoAmenaza.IdsDeLasAmenazasDeUnEcosistema(idEcosistema);
        }
    }
}
