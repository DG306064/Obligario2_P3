﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.RegistrodeCambios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaHabitat : IAltaHabitat
    {
        public IRepositorioHabitat RepoHabitat { get; set; }
        public IRepositorio<RegistroDeCambios> RepoRegistroCambios { get; set; }
        public IRepositorioEcosistema RepoEcosistema { get; set; }

        public CUAltaHabitat(IRepositorioHabitat repoHab, IRepositorio<RegistroDeCambios> repoRegistroCambios,IRepositorioEcosistema repoEcosistema)
        {
            RepoHabitat = repoHab;
            RepoRegistroCambios = repoRegistroCambios;
            RepoEcosistema = repoEcosistema;
        }



        public void Alta(HabitatDTO obj, string nombreUsuario)
        {
            Habitat habitat = new Habitat()
            {
                Id = obj.Id,
                Ecosistema = RepoEcosistema.FindById(obj.IdEcosistema),
                Habita = obj.Habita,
            };
            RepoHabitat.Add(habitat);

            RegistroDeCambios registro = new RegistroDeCambios()
            {

                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now,
                IdEntidadModificada = obj.Id,
                TipoDeEntidad = "Especie",
                TipoDeModificacion = "POSIBLE HABITAT ASIGNADO"

            };



            RepoRegistroCambios.Add(registro);
        }
    }
}
