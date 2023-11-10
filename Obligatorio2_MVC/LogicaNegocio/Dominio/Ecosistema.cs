using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Ecosistema : IValidable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Nombre Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(-90, 90)]

        public double Latitud { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(-180, 180)]
        public double Longitud { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(1, double.PositiveInfinity)]

        public int Area { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Descripcion Descripcion { get; set; }


        public Pais Pais { get; set; }

        [Display(Name = "Estado de conservación")]

        public EstadoConservacion EstadoConservacion { get; set; }

        public IEnumerable<Amenaza> Amenazas { get; set; }

        [Required(ErrorMessage = "Imagen requerida")]
        public string ImagenEcosistema { get; set; }


        public void Validate()
        {

            if (Latitud < -90 || Latitud > 90) throw new EcosistemaException("Escriba una latitud correcta");
            if (Longitud < -180 || Longitud > 180) throw new EcosistemaException("Escriba una longitud correcta");

            if (Area < 0) throw new EcosistemaException("El área debe ser mayor a 0");





        }
    }
}
