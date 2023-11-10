//using Microsoft.EntityFameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Parametros
{


   //[Index(nameof(Nombre), IsUnique=true)] 


    public class Parametro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }


    }
}
