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
    public class CUBuscarEcosistemaPorId : IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema RepoEco { get; set; }

        public CUBuscarEcosistemaPorId(IRepositorioEcosistema repoEco)
        {
            RepoEco = repoEco;

        }

        
        public Ecosistema BuscarEcoPorId(int id)
        {
            return RepoEco.FindById(id);
        }
    }
}
