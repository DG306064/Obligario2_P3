using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class ParametrosException : Exception
    {
        public ParametrosException() : base() { }
        public ParametrosException(string message) : base(message) { }
        public ParametrosException(string message, Exception interna) : base(message, interna) { }
    }
}
