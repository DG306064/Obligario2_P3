using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Parametros;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUModificarMinLargoDescripcion : IModificarMinLargoDescripcion
    {
        public IRepositorioParametros RepoParametros { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUModificarMinLargoDescripcion(IRepositorioParametros repoParametros, IRepositorio<RegistroDeCambios> 
                                    repoRegistroCambios)
        {
            RepoParametros = repoParametros;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void Modificar(string nombreParametro, string valorNuevo, string nombreUsuario)
        {
            Parametro parametro = RepoParametros.BuscarParametroPorNombre(nombreParametro);
            
            parametro.Valor = valorNuevo;
            RepoParametros.Update(parametro);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = parametro.Id,
                TipoDeEntidad = "Parametros",
                TipoDeModificacion = "LARGO MIN. DESCRIPCION"

            };

            RepoRegistroCambios.Add(registro);
        }
    }
}
