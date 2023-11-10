using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
{
    public class DescripcionDTO
    {
        public static int MinLargoCharDescripcion { get; set; }
        public static int MaxLargoCharDescripcion { get; set; }
        public string Value { get; private set; }
    }
}
