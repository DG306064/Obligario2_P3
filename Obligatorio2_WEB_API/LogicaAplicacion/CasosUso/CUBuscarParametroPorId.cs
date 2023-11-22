using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarParametroPorId : IBuscarParametroPorId
    {
        IRepositorioParametros RepoParametros { get; set; }

        public CUBuscarParametroPorId(IRepositorioParametros repositorio)
        {
            RepoParametros = repositorio;
        }

        public ParametroDTO Buscar(int id)
        {
            var parametro = RepoParametros.FindById(id);
            var parametroDTO = new ParametroDTO
            {
                Id = parametro.Id,
                Nombre = parametro.Nombre,
                Valor = parametro.Valor
            };

            return parametroDTO;
        }
    }
}
