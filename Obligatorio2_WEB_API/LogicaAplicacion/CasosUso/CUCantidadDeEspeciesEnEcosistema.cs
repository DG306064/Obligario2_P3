using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUCantidadDeEspeciesEnEcosistema : ICantidadDeEspeciesEnEcosistema
    {
        public IRepositorioEcosistema RepoEco { get; set; }

        public CUCantidadDeEspeciesEnEcosistema(IRepositorioEcosistema repoEco)
        {
            RepoEco = repoEco;

        }

        public int CantidadDeEspecies(int IdEcosistema)
        {
            return RepoEco.CantidadDeEspeciesHabitandoUnEcosistema(IdEcosistema);
        }
    }
}
