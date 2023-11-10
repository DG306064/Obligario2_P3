using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerHabitatsDeLaEspecie : IObtenerHabitatsDeLaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUObtenerHabitatsDeLaEspecie(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }



        public IEnumerable<Habitat> ObtenerHabitatsDeLaEspecie(int idEspecie)
        {
            return RepoEspecie.ObtenerHabitatsDeLaEspecie(idEspecie);
        }

      
    }
}
