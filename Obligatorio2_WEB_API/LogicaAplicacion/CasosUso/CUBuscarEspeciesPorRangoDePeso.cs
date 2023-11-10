using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarEspeciesPorRangoDePeso : IBuscarEspeciesPorRangoDePeso
    {
        IRepositorioEspecie RepositorioEspecie { get; set; }

        public CUBuscarEspeciesPorRangoDePeso(IRepositorioEspecie repositorio)
        {
            RepositorioEspecie = repositorio;
        }
        public IEnumerable<Especie> BuscarEspeciesPorRangoDePeso(int pesoMin, int pesoMax)
        {
            return RepositorioEspecie.BuscarEspeciesPorRangoDePeso(pesoMin, pesoMax);
        }
    }
}
