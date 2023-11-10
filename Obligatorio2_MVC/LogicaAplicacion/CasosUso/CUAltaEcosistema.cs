using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace LogicaAplicacion.CasosUso
{
    public class CUAltaEcosistema : IAltaEcosistema
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUAltaEcosistema(IRepositorioEcosistema repoEcosistema, IRepositorio<RegistroDeCambios> 
                                repoRegistroCambios)
        {
            RepoEcosistema = repoEcosistema;
            RepoRegistroCambios = repoRegistroCambios;
        }




        public void Alta(Ecosistema obj, string nombreUsuario)
        {
            RepoEcosistema.Add(obj);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Ecosistema",
                TipoDeModificacion = "ALTA"

            };

            RepoRegistroCambios.Add(registro);




        }

    
       
    }
}
