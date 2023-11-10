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
    public class CUAmenazasDeUnEcosistema : IAmenazasDeUnEcosistema
    {
            public IRepositorioEcosistema RepoEcosistema { get; set; }
            public CUAmenazasDeUnEcosistema(IRepositorioEcosistema repoEcosistema)
            {
                RepoEcosistema = repoEcosistema;
            }

            public IEnumerable<Amenaza> AmenazasDeUnEcosistema(int idEcosistema)
            {
            return RepoEcosistema.ObtenerAmenazas(idEcosistema);
            }
    }
}
