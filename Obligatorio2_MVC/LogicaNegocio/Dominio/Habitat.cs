using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Habitat : IValidable
    {
        public int Id { get; set; }
        public Ecosistema ecosistema { get; set; }

        public bool habita { get; set; }

        public void Validate()
        {
            if (ecosistema == null) throw new HabitatException("NO SE ENCONOTRÓ EL ECOSISTEMA");
        }
    }
}
