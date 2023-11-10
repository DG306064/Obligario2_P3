using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExcepcionesPropias;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos
{
    public class RepositorioEcosistema : IRepositorioEcosistema
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioEcosistema(EmpresaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Ecosistema obj)
        {
            if(obj!= null)
            {
                obj.Validate();
                if (ExisteNombreEcosistema(obj.Nombre.Value)) throw new EcosistemaException("YA EXISTE UN ECOSISTEMA CON ESE NOMBRE");
                if (obj.Pais == null) throw new EcosistemaException("EL ECOSISTEMA DEBE CONTENER UN PAIS");
                if (obj.EstadoConservacion == null) throw new EcosistemaException("EL ECOSISTEMA DEBE CONTENER UN ESTADO DE CONSERVACIÓN");


                try
                {
                    Contexto.Entry(obj.EstadoConservacion).State = EntityState.Unchanged;
                    Contexto.Entry(obj.Pais).State = EntityState.Unchanged;
                    Contexto.Ecosistemas.Add(obj);
                    Contexto.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new EcosistemaException("No se pudo realizar el alta", ex);
                }

            }else
            {
                throw new EcosistemaException("No se provee un ecosistema");
            }
        }

        public IEnumerable<Ecosistema> FindAll()
        {
                return Contexto.Ecosistemas.Include(e => e.Pais)
                                           .Include(e => e.EstadoConservacion)
                                           .Include(e => e.Amenazas)
                                           .ToList();
        }



        public Ecosistema FindById(int id)
        {
            return Contexto.Ecosistemas.Find(id);
        }

        public void remove(Ecosistema obj)
        {
            if (obj != null)
            {
                if (CantidadDeEspeciesHabitandoUnEcosistema(obj.Id) != 0) throw new EcosistemaException("EL ECOSISTEMA TIENE ESPECIES HABITÁNDOLO");
                try
                {
                    Contexto.Remove(obj);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EcosistemaException("Ocurrió un error al eliminar un ecosistema");
                }

            }
            else
            {
                throw new EcosistemaException("NO SE PROPORCIONÓ UN ECOSISTEMA");
            }
        }

        public void Update(Ecosistema obj)
        {
            obj.Validate();

            if (obj != null)
            {
                Contexto.Ecosistemas.Update(obj);
                Contexto.SaveChanges();

            }
            else
            {
                    throw new EcosistemaException("EL ECOSISTEMA PROPORCIONADO NO EXISTE");
            }
            
        }

        public int CantidadDeEspeciesHabitandoUnEcosistema(int IdEcosistema)
        {
            var cantidad = Contexto.Especies
                 .Count(especie => especie.habitats.Any(habitat=>habitat.ecosistema.Id == IdEcosistema && habitat.habita == true));

            return cantidad;
        
        }

        public void AsignarUnaAmenaza(int IdEcosistema, int IdAmenaza)
        {
            var ecosistema = Contexto.Ecosistemas
                .Include(ecosistema => ecosistema.Amenazas)
                .Where(ecosistema => ecosistema.Id == IdEcosistema)
                .SingleOrDefault();

            var amenaza = Contexto.Amenazas
                .Include(amenaza => amenaza.Ecosistemas)
                        .Where(amenaza => amenaza.Id == IdAmenaza)
                            .SingleOrDefault();

            List<Amenaza> listaList = ecosistema.Amenazas.ToList();

            if (ecosistema.Amenazas.Contains(amenaza))
            {
                listaList.Remove(amenaza);
                ecosistema.Amenazas = listaList;
            }
            else
            {
                listaList.Add(amenaza);
                ecosistema.Amenazas = listaList;
            }

            Update(ecosistema);

        }

        

        public bool ExisteNombreEcosistema(string nombreEcosistema)
        {
            bool existe = Contexto.Ecosistemas.Any(e => e.Nombre.Value == nombreEcosistema);
            return existe;
        }

        public IEnumerable<Amenaza> ObtenerAmenazas(int idEcoistema)
        {

            var amenazas = Contexto.Amenazas
                        .Where(amenaza => amenaza.Ecosistemas.Any(eco => eco.Id == idEcoistema)).ToList();

            return amenazas;
        }

        public IEnumerable<Ecosistema> EcosistemasQueNoPuedeHabitarUnaEspecie(string nombreEspecie)
        {

            IEnumerable<Ecosistema> ecosistemas = Contexto.Ecosistemas.Include(eco => eco.Amenazas)
                                                                      .Include(eco => eco.Pais)
                                                                      .Include(eco => eco.EstadoConservacion)
                                                                      .Where(eco => eco.Amenazas.Any(a => a.Especies.Any(esp => esp.NombreCientifico == nombreEspecie)))
                                                                      .ToList();

            return ecosistemas;
        }
        public Ecosistema BuscarECosistemaPorNombre(string nombreEcosistema)
        {
            var eco = Contexto.Ecosistemas
                    .Include(eco=>eco.EstadoConservacion)
                    .Where(eco => eco.Nombre.Value == nombreEcosistema)
                    .SingleOrDefault();

            return eco;
        }

     
    }
}
