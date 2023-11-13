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
    public class CUBuscarParametroPorNombre : IBuscarParametroPorNombre
    {
        IRepositorioParametros RepositorioParametros { get; set; }

        public CUBuscarParametroPorNombre(IRepositorioParametros repositorio)
        {
            RepositorioParametros = repositorio;
        }
        public ParametroDTO BuscarParametroPorNombre(string nombre)
        {
            var p = RepositorioParametros.BuscarParametroPorNombre(nombre);

            ParametroDTO parametro = new ParametroDTO()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Valor = p.Valor
            };

            return parametro;
        }
    }
}
