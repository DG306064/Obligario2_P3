using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.ValueObjects
{
    
    public class Nombre
    {
        public static int MinLargoCharNombre { get; set; }
        public static int MaxLargoCharNombre { get; set; }

        [Column("Nombre")]
        [Display(Name = "Nombre")]
        public string Value { get; private set; }

        public Nombre(string value)
        {
            Value = value;
            Validate();
        }

        private Nombre()
        {

        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new NombreException("EL NOMBRE NO PUEDE ESTAR VACIO");
            if (Value.Length < MinLargoCharNombre || Value.Length > MaxLargoCharNombre) throw new NombreException("El nombre debe tener entre " + MinLargoCharNombre+ "y " + MaxLargoCharNombre + " caracteres");
        }
    }
}
