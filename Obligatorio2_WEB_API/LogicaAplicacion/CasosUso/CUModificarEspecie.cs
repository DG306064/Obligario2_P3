﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosUso
{
    public class CUModificarEspecie : IModificarEspecie
    {
        public IRepositorioEspecie RepoEspecie { get; set; }
        public IRepositorioEcosistema RepoEcosistema { get; set; }

        public IRepositorio<EstadoConservacion> RepoEstado { get; set; }

        public CUModificarEspecie(IRepositorioEspecie repoEspecie, IRepositorioEcosistema repoEcosistema, IRepositorio<EstadoConservacion> repoEstado)
        {
            RepoEspecie = repoEspecie;
            RepoEcosistema = repoEcosistema;
            RepoEstado = repoEstado;
        }

        public void ModificarEspecie(EspecieDTO obj)
        {
            var especie = new Especie()
            {
                Id = obj.Id,
                NombreCientifico = obj.NombreCientifico,
                NombreComun = new Nombre(obj.NombreComun),
                PesoMinimo = obj.PesoMinimo,
                PesoMaximo = obj.PesoMaximo,
                LongitudMinima = obj.LongitudMinima,
                LongitudMaxima = obj.LongitudMaxima,
                ImagenEspecie = obj.ImagenEspecie,
                EstadoCons = RepoEstado.FindById(obj.IdEstadoCons),
                Amenazas = obj.Amenazas.Select(a => new Amenaza()
                {
                    Id = a.Id,
                    Descripcion = new Descripcion(a.Descripcion),
                    Peligrosidad = a.Peligrosidad
                }),
                Habitats = obj.Habitats.Select(h => new Habitat()
                {
                    Id = h.Id,
                    Ecosistema = RepoEcosistema.FindById(h.IdEcosistema),
                    Habita = h.Habita
                })
            };
            RepoEspecie.Update(especie);
        }
    }
}
