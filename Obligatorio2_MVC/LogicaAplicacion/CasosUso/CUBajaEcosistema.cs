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
    public class CUBajaEcosistema : IBajaEcosistema
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }
        
        public CUBajaEcosistema(IRepositorioEcosistema repo, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoEcosistema = repo;
            RepoRegistroCambios = repoRegistroCambios;
        }
        
        
        
        
        public void BorrarEcosistema(Ecosistema obj, string nombreUsuario)
        {
            RepoEcosistema.remove(obj);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Ecosistema",
                TipoDeModificacion = "BAJA"

            };

            RepoRegistroCambios.Add(registro);
        }
    }
}

