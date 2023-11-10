using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EstadoConservacionException : Exception
    {
        public EstadoConservacionException() : base() { }
        public EstadoConservacionException(string message) : base(message) { }
        public EstadoConservacionException(string message, Exception interna) : base(message, interna) { }
    }
}
