using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOHabitat
    {
        public int Id { get; set; }
        public DTOEcosistema Ecosistema { get; set; }
        public int IdEcosistema { get; set; }
        public string NombreEcosistema { get; set; }
        public bool Habita { get; set; }
    }
}
