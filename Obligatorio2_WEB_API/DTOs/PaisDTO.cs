﻿using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PaisDTO
    {
        public int Id { get; set; }
        public string? CodigoIsoAlpha { get; set; }
        public string? Nombre { get; set; }
    }
}
