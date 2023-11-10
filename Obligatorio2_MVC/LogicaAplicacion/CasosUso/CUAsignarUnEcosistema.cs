using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.RegistrodeCambios;

namespace LogicaAplicacion.CasosUso
{
    public class CUAsignarUnEcosistema : IAsignarUnEcosistema
    {
        public IRepositorioHabitat RepoHabitat { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAsignarUnEcosistema(IRepositorioHabitat repoHab, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoHabitat = repoHab;
            RepoRegistroCambios = repoRegistroCambios;

        }


        public void AsignarUnEcosistema(int idEspecie, int idEcosistema, string nombreUsuario)
        {

            RepoHabitat.AsignarElEcosistema(idEspecie, idEcosistema);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = idEspecie,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "HABITANDO ECOSISTEMA"

            };



            RepoRegistroCambios.Add(registro);


        }
    }
}
