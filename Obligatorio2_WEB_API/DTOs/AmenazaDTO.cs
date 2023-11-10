using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AmenazaDTO
    {
        public int Id { get; set; }      
        public string Descripcion { get; set; }
        public int Peligrosidad { get; set; }
        public IEnumerable<EspecieDTO> Especies { get; set; }
        public IEnumerable<EcosistemaDTO> Ecosistemas { get; set; }
    }
}
