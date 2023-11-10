using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IAsignarAmenazaAEcosistema
    {
        void AsignarAmenazaAUnEcosistema(int IdEcosistema, int IdAmenaza, string nombreUsuario);
    }
}
