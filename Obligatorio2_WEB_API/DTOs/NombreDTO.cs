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
    public class NombreDTO
    {
        public static int MinLargoCharNombre { get; set; }
        public static int MaxLargoCharNombre { get; set; }
        public string? Value { get; private set; }

        public NombreDTO(string value)
        {
            Value = value;
        }
    }
}
