using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IObtenerIdsDeAmenazasDelEcosistema
    {

        IEnumerable<int> ObtenerIdsDeAmenazasDelEcosistema(int idEcosistema);

    }
}
