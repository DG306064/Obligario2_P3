using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Dominio
{
    public class Amenaza : IValidable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripcion requerido")]
        public Descripcion Descripcion { get; set; }

        [Required(ErrorMessage = " peligrosidad requerida")]
        public int Peligrosidad { get; set; }

        public IEnumerable<Especie> Especies { get; set; }
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }



        public void Validate()
        {
            if (Peligrosidad < 1) throw new AmenazaException("El nivel de peligrosidad debe ser mayor a 0");
            if (Peligrosidad > 10) throw new AmenazaException("El nivel de peligrosidad debe ser menor a 10");
            if (string.IsNullOrEmpty(Descripcion)) throw new AmenazaException("La descripcion no puede estar vacia.");
            if (Descripcion.Length < 2 || Descripcion.Length > 50) throw new AmenazaException("La descripcion debe tener entre 2 y 50 caracteres");

        }
    }
}
