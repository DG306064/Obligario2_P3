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
    public class CUBuscarHabitatPorId : IBuscarHabitatPorId
    {
        public IRepositorioHabitat RepoHabitat { get; set; }

        public CUBuscarHabitatPorId(IRepositorioHabitat repoHabitat)
        {
            RepoHabitat = repoHabitat;
        }


        public HabitatDTO BuscarHabitatPorId(int id)
        {
            Habitat h = RepoHabitat.FindById(id);

            HabitatDTO habitat = new HabitatDTO()
            {
                Id = h.Id,
                NombreEcosistema = h.Ecosistema.Nombre.Value,
                Habita = h.Habita
            };

            return habitat;
        }
    }
}
