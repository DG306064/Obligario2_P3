using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class DescripcionException : Exception
    {
        public DescripcionException() { }

        public DescripcionException(string msg) : base(msg) { }

        public DescripcionException(string msg, Exception interna) : base(msg, interna) { }
    }
}
