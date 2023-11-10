using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesPropias;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ValueObjects;
//using Microsoft.EntityFrameworkCore;


namespace LogicaNegocio
{
   // [Index(nameof(Nombre), IsUnique = true)]
    public class EstadoConservacion : IValidable
    {
        public int Id { get; set; }
    
       
        [Display(Name = "Nombre del estado de conservacion")]
        [Required(ErrorMessage = "Campo requerido")]
        public Nombre Nombre { get; set; }

        [Display(Name = "Nivel estado de conservacion")]
        [Required(ErrorMessage = "Campo requerido")]
        public int Valor { get; set; }


        public void Validate()
        {
          
            if(Valor < 1 || Valor > 100) throw new EstadoConservacionException("EL VALOR DEL ESTADO DEBE ESTAR ENTRE 1 Y 100");

        }



    }
}
