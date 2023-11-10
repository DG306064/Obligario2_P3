using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio
{
    public class Pais : IValidable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(3)]
        public string CodigoIsoAlpha { get; set; }
   
        [Range(2, 50)]
        [Required(ErrorMessage = "Campo requerido")]
        public Nombre Nombre { get; set; }

        public void Validate()
        {
            
            if (string.IsNullOrEmpty(CodigoIsoAlpha)) throw new PaisException("Debe ingresar una un codigo iso alpha");
            if (CodigoIsoAlpha.Length != 3 && !CodigoIsoAlpha.All(char.IsLetter)) throw new PaisException("El código del país solo puede tener 3 letras");



        }
    }
    

}
