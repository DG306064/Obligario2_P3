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
    public class CUAltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUAltaEspecie(IRepositorioEspecie RepoEsp, IRepositorio<RegistroDeCambios> repoRegistroCambios)
        {
            repoEspecie = RepoEsp;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void Add(Especie obj, string nombreUsuario)
        {
            repoEspecie.Add(obj);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "ALTA"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
