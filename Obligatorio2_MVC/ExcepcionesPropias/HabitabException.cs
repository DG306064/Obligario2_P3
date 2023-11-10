using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class HabitatException : Exception
    {
        public HabitatException() : base() { }
        public HabitatException(string message) : base(message) { }
        public HabitatException(string message, Exception interna) : base(message, interna) { }
    }
}
