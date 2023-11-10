using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogicaNegocio.RegistrodeCambios
{
    public class RegistroDeCambios : IValidable
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEntidadModificada { get; set; }
        public string TipoDeEntidad { get; set; }
        public string TipoDeModificacion { get; set; }


        public void Validate()
        {
            if (string.IsNullOrEmpty(NombreUsuario)) throw new CambiosException("Debe contener el nombre del usuario que hizo el cambio");
            if (Fecha == null) throw new CambiosException("El registro debe contener la fecha");
            if (Fecha > DateTime.Now) throw new CambiosException("La fecha debe ser del dia de hoy o anterior");
            if (IdEntidadModificada <= 0) throw new CambiosException("El Id proporcionado no existe");
            if (string.IsNullOrEmpty(TipoDeEntidad)) throw new CambiosException("Debe contener el tipo de la entidad");
            if (string.IsNullOrEmpty(TipoDeModificacion)) throw new CambiosException("Debe contener el tipo de modificación");

        }
    }
}
