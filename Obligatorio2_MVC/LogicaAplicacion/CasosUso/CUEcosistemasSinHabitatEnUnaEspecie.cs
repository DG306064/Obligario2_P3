using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class CUEcosistemasSinHabitatEnUnaEspecie : IEcosistemasSinHabitatEnUnaEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }

        public CUEcosistemasSinHabitatEnUnaEspecie(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }

        public IEnumerable<Ecosistema> ObtenerEcosistemasSinHabitatEnUnaEspecie(int idEspecie)
        {
            return repoEspecie.EcosistemasQueAunNoTienenPosibleHabitatConEsaEspecie(idEspecie);
        }
    }
}
