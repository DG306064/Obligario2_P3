using DTOs;
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
    public class CUModificarParametro : IModificarParametro
    {
        public IRepositorioParametros RepoParametros { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }


        public CUModificarParametro(IRepositorioParametros repoParametros, IRepositorio<RegistroDeCambios>
                                            repoRegistroCambios)
        {
            RepoParametros = repoParametros;
            RepoRegistroCambios = repoRegistroCambios;
        }

        public void Modificar(ParametroDTO obj, string nombreUsuario)
        {
            Parametro parametro = RepoParametros.FindById(obj.Id);

            parametro.Nombre = obj.Nombre;
            parametro.Valor = obj.Valor;

            RepoParametros.Update(parametro);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = parametro.Id,
                TipoDeEntidad = "Parametros",
                TipoDeModificacion = "Modificación"

            };

            RepoRegistroCambios.Add(registro);
        }
    }
}

