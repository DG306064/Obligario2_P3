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
    public class CUEcosistemasQueNoPuedeHabitarUnaEspecie : IEcosistemasQueNoPuedeHabitarUnaEspecie
    {
        IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUEcosistemasQueNoPuedeHabitarUnaEspecie(IRepositorioEcosistema repositorio)
        {
            RepositorioEcosistema = repositorio;
        }
        public IEnumerable<Ecosistema> EcosistemasQueNoPuedeHabitarUnaEspecie(string nombreEspecie)
        {
            return RepositorioEcosistema.EcosistemasQueNoPuedeHabitarUnaEspecie(nombreEspecie);
        }
    }
}
