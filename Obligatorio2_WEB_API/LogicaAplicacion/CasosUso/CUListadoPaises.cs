using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoPaises : IListadoPaises
    {
        public IRepositorioPais RepoPais { get; set; }

        public CUListadoPaises(IRepositorioPais repoPais)
        {
            RepoPais = repoPais;
        }



        public IEnumerable<PaisDTO> Listado()
        {
            var paises = RepoPais.FindAll();

            var paisesDTO = paises.Select(p => new PaisDTO()
            {
                Id = p.Id,
                CodigoIsoAlpha = p.CodigoIsoAlpha,
                Nombre = p.Nombre
            });

            return paisesDTO; 
        }
    }
}
