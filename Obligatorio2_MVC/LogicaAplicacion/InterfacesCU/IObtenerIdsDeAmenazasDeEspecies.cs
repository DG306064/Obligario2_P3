using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IObtenerIdsDeAmenazasDeEspecies
    {
        IEnumerable<int> ObtenerIdsDeAmenazasDeEspecies(int idEspecie);
    }
}
