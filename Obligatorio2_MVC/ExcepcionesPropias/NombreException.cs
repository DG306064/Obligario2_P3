using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class NombreException : Exception
    {
        public NombreException()
        {
        }

        public NombreException(string? message) : base(message)
        {
        }

        public NombreException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
