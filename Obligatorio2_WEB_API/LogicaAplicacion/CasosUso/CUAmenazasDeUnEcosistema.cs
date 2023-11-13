using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUAmenazasDeUnEcosistema : IAmenazasDeUnEcosistema
    {
            public IRepositorioEcosistema RepoEcosistema { get; set; }
            public CUAmenazasDeUnEcosistema(IRepositorioEcosistema repoEcosistema)
            {
                RepoEcosistema = repoEcosistema;
            }

            public IEnumerable<AmenazaDTO> AmenazasDeUnEcosistema(int idEcosistema)
            {
                var amenazas = RepoEcosistema.ObtenerAmenazas(idEcosistema);

                var amenazasDTO = amenazas.Select(a => new AmenazaDTO()
                {
                    Id = a.Id,
                    Descripcion = a.Descripcion.Value,
                    Peligrosidad = a.Peligrosidad
                });

                return amenazasDTO;
            }
    }
}
