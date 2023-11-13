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
    public class CUObtenerHabitatsDeLaEspecie : IObtenerHabitatsDeLaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public CUObtenerHabitatsDeLaEspecie(IRepositorioEspecie repo)
        {
            RepoEspecie = repo;
        }



        public IEnumerable<HabitatDTO> ObtenerHabitatsDeLaEspecie(int idEspecie)
        {
            var habitats = RepoEspecie.ObtenerHabitatsDeLaEspecie(idEspecie);

            var habitatsDTO = habitats.Select(h => new HabitatDTO()
            {
                Id = h.Id,
                NombreEcosistema = h.Ecosistema.Nombre.Value,
                Habita = h.Habita
            });

            return habitatsDTO; 
        }

      
    }
}
