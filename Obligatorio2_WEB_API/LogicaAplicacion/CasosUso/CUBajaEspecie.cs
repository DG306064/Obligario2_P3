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
    public class CUBajaEspecie : IBajaEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }

        public CUBajaEspecie(IRepositorioEspecie repoEspecie, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            RepoEspecie = repoEspecie;
            RepoRegistroCambios = repoRegistroCambios;

        }


        public void BajaEspecie(Especie obj, string nombreUsuario)
        {
            RepoEspecie.remove(obj);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "BAJA"

            };



            RepoRegistroCambios.Add(registro);


        }

      
    }
}
