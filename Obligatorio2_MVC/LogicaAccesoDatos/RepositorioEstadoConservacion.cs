﻿using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEstadoConservacion : IRepositorio<EstadoConservacion>
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioEstadoConservacion(EmpresaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoConservacion> FindAll()
        {
            return Contexto.Estados.ToList();
        }

        public EstadoConservacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void remove(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
