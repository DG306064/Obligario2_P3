using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IModificarMinLargoDescripcion
    {
        void Modificar(string nombreParametro, string valorNuevo, string nombreUsuario);
    }
}
