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
    public class CUBuscarHabitatPorId : IBuscarHabitatPorId
    {
        public IRepositorioHabitat RepoHabitat { get; set; }

        public CUBuscarHabitatPorId(IRepositorioHabitat repoHabitat)
        {
            RepoHabitat = repoHabitat;
        }


        public Habitat BuscarHabitatPorId(int id)
        {
            return RepoHabitat.FindById(id);
        }
    }
}
