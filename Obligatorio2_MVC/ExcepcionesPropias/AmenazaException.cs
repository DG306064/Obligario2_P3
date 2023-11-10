using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class AmenazaException : Exception
    {
        public AmenazaException() { }

        public AmenazaException(string msg) : base(msg) { }

        public AmenazaException(string msg, Exception interna) : base(msg, interna) { }


    }
}
