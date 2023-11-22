using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoParametros : IListadoParametros
    {
        IRepositorioParametros RepoParametros { get; set; }

        public CUListadoParametros(IRepositorioParametros repositorio)
        {
            RepoParametros = repositorio;
        }

        public IEnumerable<ParametroDTO> Listado()
        {
            var parametros = RepoParametros.FindAll();
            var parametrosDTO = parametros.Select(p => new ParametroDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Valor = p.Valor
            });

            return parametrosDTO;
        }
    }
}
