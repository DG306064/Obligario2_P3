using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EcosistemaException : Exception
    {
        public EcosistemaException() : base() { }
        public EcosistemaException(string message) : base(message) { }
        public EcosistemaException(string message, Exception interna) : base(message, interna) { }
    }
}
