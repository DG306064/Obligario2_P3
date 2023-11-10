using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LogicaNegocio.ValueObjects;
using LogicaNegocio.Dominio;

namespace LogicaNegocio
{
    public class Especie : IValidable
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre científico")]
        public string NombreCientifico { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Nombre NombreComun { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Descripcion Descripcion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, double.PositiveInfinity)]
        [Display(Name = "Peso Mínimo")]

        public int PesoMinimo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, double.PositiveInfinity)]
        [Display(Name = "Peso Máximo")]

        public int PesoMaximo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, double.PositiveInfinity)]
        [Display(Name = "Longitud Mínima")]
        public int LongitudMinima { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, double.PositiveInfinity)]
        [Display(Name = "Longitud Máxima")]
        public int LongitudMaxima { get; set; }

        [Required(ErrorMessage = "Imagen requerida")]
        public string ImagenEspecie { get; set; }


        public EstadoConservacion EstadoCons { get; set; }

        public IEnumerable<Amenaza> Amenazas { get; set; }
        public IEnumerable<Habitat> habitats { get; set; }





        public void Validate()
        {
            
            if (string.IsNullOrEmpty(NombreCientifico)) throw new EspecieException("Debe ingresar el nombre científico");

            if(PesoMinimo < 0) throw new EspecieException("El peso mínimo debe ser mayor a 0");
            if (PesoMaximo < 0) throw new EspecieException("El peso máximo debe ser mayor a 0");

            if (LongitudMinima < 0) throw new EspecieException("La longitud mínima debe ser mayor a 0");
            if (LongitudMaxima < 0) throw new EspecieException("La longitud máxima debe ser mayor a 0");

           
        }


        //public List<string> Imagenes { get; set; }
    }
}
