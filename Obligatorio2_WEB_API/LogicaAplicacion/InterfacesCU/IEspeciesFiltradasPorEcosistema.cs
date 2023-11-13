using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using DTOs;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IEspeciesFiltradasPorEcosistema
    {
        IEnumerable<EspecieDTO> EspeciesFIltradasPorEcosistema(string nombreEcosistema);
    }
}
