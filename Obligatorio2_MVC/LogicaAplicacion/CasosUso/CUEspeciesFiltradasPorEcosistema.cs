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
    public class CUEspeciesFiltradasPorEcosistema : IEspeciesFiltradasPorEcosistema
    {
            public IRepositorioEspecie repoEspecie { get; set; }

            public CUEspeciesFiltradasPorEcosistema(IRepositorioEspecie RepoEsp)
            {
                repoEspecie = RepoEsp;
            }

        public IEnumerable<Especie> EspeciesFIltradasPorEcosistema(string nombreEcosistema)
        {
             return repoEspecie.especiesFiltradasPorEcosistema(nombreEcosistema);
        }

       
    }
}
