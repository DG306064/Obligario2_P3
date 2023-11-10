using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAsignarAmenazaAEcosistema : IAsignarAmenazaAEcosistema
    {

        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUAsignarAmenazaAEcosistema(IRepositorioEcosistema repoEcosistema, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoEcosistema = repoEcosistema;
            RepoRegistroCambios = repoRegistroCambios;
        }


        public void AsignarAmenazaAUnEcosistema(int IdEcosistema, int IdAmenaza, string nombreUsuario)
        {
            RepoEcosistema.AsignarUnaAmenaza(IdEcosistema, IdAmenaza);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = IdEcosistema,
                TipoDeEntidad = "Ecosistema",
                TipoDeModificacion = "AMENAZA ASIGNADA"

            };



            RepoRegistroCambios.Add(registro);


        }
    }
}
