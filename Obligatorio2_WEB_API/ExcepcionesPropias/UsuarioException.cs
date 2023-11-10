using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class UsuarioException : Exception
    {
        public UsuarioException() : base() { }
        public UsuarioException(string message) : base(message) { }
        public UsuarioException(string message, Exception interna) : base(message, interna) { }
    }
}
