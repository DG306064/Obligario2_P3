using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IVerSiExisteUsuario
    {
       bool VerSiExisteUsuario(string alias);
    }
}
