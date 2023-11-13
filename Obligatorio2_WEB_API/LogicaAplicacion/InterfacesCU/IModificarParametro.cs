using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IModificarParametro
    {
        void Modificar(ParametroDTO obj, string nombreUsuario);
    }
}
