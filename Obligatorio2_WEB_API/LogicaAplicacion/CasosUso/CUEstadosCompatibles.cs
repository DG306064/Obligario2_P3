using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUEstadosCompatibles : IEstadosCompatibles
    {
        public IRepositorioEspecie repoEspecie { get; set; }

        public CUEstadosCompatibles(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }
        public bool Compatibles(int IdEspecie, int IdEcosistema)
        {
            return repoEspecie.EstadosDeConservacionCompatibles(IdEspecie, IdEcosistema);
        }
    }
}
