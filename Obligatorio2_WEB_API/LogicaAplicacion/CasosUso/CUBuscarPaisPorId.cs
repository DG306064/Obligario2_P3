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
    public class CUBuscarPaisPorId : IBuscarPaisPorId
    {
        IRepositorioPais RepoPaises { get; set; }

        public CUBuscarPaisPorId(IRepositorioPais repo)
        {
            RepoPaises = repo;
        }

        public PaisDTO Buscar(int id)
        {
            var pais = RepoPaises.FindById(id);
            return new PaisDTO
            {
                Id = pais.Id,
                CodigoIsoAlpha = pais.CodigoIsoAlpha,
                Nombre = pais.Nombre.Value
            };
        }
    }
}
