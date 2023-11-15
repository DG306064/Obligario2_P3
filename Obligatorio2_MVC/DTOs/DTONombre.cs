using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExcepcionesPropias;

namespace DTOs
{
    public class DTONombre
    {
        public static int MinLargoCharNombre { get; set; }
        public static int MaxLargoCharNombre { get; set; }
        public string? Value { get; private set; }

        public DTONombre(string value)
        {
            Value = value;
        }
    }
}
