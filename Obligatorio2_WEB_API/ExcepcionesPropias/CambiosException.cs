using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class CambiosException : Exception
    {
        public CambiosException() : base() { }
        public CambiosException(string message) : base(message) { }
        public CambiosException(string message, Exception interna) : base(message, interna) { }
    }
}
