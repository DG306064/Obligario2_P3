using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class HabitatDTO
    {
        public int Id { get; set; }
        public Ecosistema Ecosistema { get; set; }
        public bool Habita { get; set; }
    }
}
