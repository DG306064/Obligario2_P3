using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicaNegocio.ValueObjects
{
    public class Descripcion
    {
        public static int MinLargoCharDescripcion { get; set; }
        public static int MaxLargoCharDescripcion { get; set; }



        [Column("Descripcion")]
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Descripción")]
        public string Value { get; private set; }

        public Descripcion(string value)
        {
            Value = value;
            Validate();

        }

        private Descripcion()
        {

        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new DescripcionException("La descripcion no puede estar vacia.");
            if (Value.Length < MinLargoCharDescripcion || Value.Length > MaxLargoCharDescripcion)
            {
                throw new DescripcionException("La descripcion debe tener entre " + MinLargoCharDescripcion + " y " + MaxLargoCharDescripcion+" caracteres");
            }
        }
    }
}
