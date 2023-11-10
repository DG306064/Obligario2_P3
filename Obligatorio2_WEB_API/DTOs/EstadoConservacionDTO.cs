using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class EstadoConservacionDTO
    {
        public int Id { get; set; }
        public NombreDTO Nombre { get; set; }
        public int Valor { get; set; }
    }
}
