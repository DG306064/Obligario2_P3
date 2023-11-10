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
    public class CUBuscarEcosistemaPorNombre : IBuscarEcosistemaPorNombre
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }

        public CUBuscarEcosistemaPorNombre(IRepositorioEcosistema repo)
        {
            RepoEcosistema = repo;
        }
        public Ecosistema BuscarEcosistemaPorNombre(string nombreEcosistema)
        {
            return RepoEcosistema.BuscarECosistemaPorNombre(nombreEcosistema);
        }
    }
}
