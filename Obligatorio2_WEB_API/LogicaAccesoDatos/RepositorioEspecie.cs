using ExcepcionesPropias;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEspecie : IRepositorioEspecie
    {
        public EmpresaContext Contexto { get; set; }

        public RepositorioEspecie(EmpresaContext ctx)
        {

            Contexto = ctx;
        }

        public void Add(Especie obj)
        {
            if (obj != null) {

                obj.Validate();
                if (obj.EstadoCons == null) throw new EcosistemaException("EL ECOSISTEMA DEBE CONTENER UN ESTADO DE CONSERVACIÓN");


                if (ExisteNombreEspecie(obj.NombreComun.Value)) throw new EspecieException("YA EXISTE UNA ESPECIE CON ESE NOMBRE COMÚN");
                if (ExisteNombreCientificoEspecie(obj.NombreCientifico)) throw new EspecieException("YA EXISTE UNA ESPECIE CON ESE NOMBRE CIENTÍFICO");

                try
                {
                    Contexto.Entry(obj.EstadoCons).State = EntityState.Unchanged;
                    Contexto.Add(obj);
                    Contexto.SaveChanges();

                } catch (Exception ex)
                {
                    throw new EspecieException("No se pudo realizar el alta", ex);

                }

            }
            else
            {
                throw new EspecieException("No se provee una especie");
            }

        }

        public IEnumerable<Especie> FindAll()
        {
            return Contexto.Especies.ToList();
        }

        public Especie FindById(int id)
        {
            var  resultado = Contexto.Especies
                .Include(especie=>especie.habitats)
                .Include(especie=>especie.EstadoCons)
                .Where(Especie => Especie.Id == id)
                .SingleOrDefault();

            return resultado;
        }

        public void Remove(Especie obj)
        {
            if (obj != null)
            {
                Especie esp = FindById(obj.Id);
                if(esp != null)
                {
                    Contexto.Remove(esp);
                    Contexto.SaveChanges();
                }
                else
                {
                    throw new EspecieException("No se proporcionó una especie");
                }


            }
            else
            {
                throw new EspecieException("No se proporcionó una especie");
            }
        }

        public void Update(Especie obj)
        {

            if (obj != null)
            {
                obj.Validate();


                Contexto.Especies.Update(obj);
                Contexto.SaveChanges();


            }
            else
            {
                throw new EspecieException("La especie proporcionada no existe");
            }

        }

        public IEnumerable<Amenaza> ObtenerAmenazasDeLaEspecie(int idEspecie)
        {
            var amenazasDeLaEspecie = Contexto.Especies
               .Where(especie => especie.Id == idEspecie)
               .SelectMany(especie => especie.Amenazas).ToList();

            if (amenazasDeLaEspecie == null) throw new EspecieException("ocurrió un problema obteniendo las amenazas de esa especie");

            return amenazasDeLaEspecie;

        }

        public IEnumerable<Habitat> ObtenerHabitatsDeLaEspecie(int idEspecie)
        {
            if (idEspecie == 0) throw new EspecieException("OCURRIÓ UN PROBLEMA OBTENIENDO EL HABITAT DE LA ESPECIE");

            var HabitatsDeEspecie = Contexto.Especies
               .Where(especie => especie.Id == idEspecie)
               .SelectMany(especie => especie.habitats).
               Include(habitat => habitat.ecosistema)
               .ToList();

            if (HabitatsDeEspecie == null) throw new EspecieException("ocurrió un problema obteniendo los posibles ecosistemas de esa especie");

            return HabitatsDeEspecie;
        }


        public void AgregarHabitatEnLaEspecie(int idEspecie, int idHabitat)
        {
            var especie = FindById(idEspecie);

            var habitat = Contexto.Habitats
                .Where(habitat => habitat.Id == idHabitat)
                .SingleOrDefault();

            IEnumerable<Habitat> habitatsDeLaEspecie = ObtenerHabitatsDeLaEspecie(idEspecie);

            List<Habitat> listaList = habitatsDeLaEspecie.ToList();

            listaList.Add(habitat);
            especie.habitats = listaList;

            Update(especie);



        }

        public void AsignarUnaAmenaza(int IdEspecie, int IdAmenaza)
        {
            var especie = Contexto.Especies
                .Include(especie => especie.Amenazas)
                .Where(especie => especie.Id == IdEspecie)
                .SingleOrDefault();

            var amenaza = Contexto.Amenazas
                .Include(amenaza => amenaza.Especies)
                        .Where(amenaza => amenaza.Id == IdAmenaza)
                         .SingleOrDefault();


            List<Amenaza> listaList = especie.Amenazas.ToList();

            if (especie.Amenazas.Contains(amenaza)) {

                listaList.Remove(amenaza);
                especie.Amenazas = listaList;
            }
            else
            {
                listaList.Add(amenaza);
                especie.Amenazas = listaList;
            }

            Update(especie);

        }


        public IEnumerable<Ecosistema> EcosistemasQueAunNoTienenPosibleHabitatConEsaEspecie(int idEspecie)
        {

            var ListaFinalDeEosistemasSinHabitat = Contexto.Ecosistemas
                            .Where(eco => !Contexto.Especies.Where(especie => especie.Id == idEspecie)
                            .Any(especie => especie.habitats
                                 .Any(hab => hab.ecosistema.Id == eco.Id)))
                            .ToList();

            return ListaFinalDeEosistemasSinHabitat;

        }

        public Amenaza AmenazaEnComun(int IdEpecie, int IdEcosistema)
        {

            var amenaza = Contexto.Amenazas
                     .Where(amenaza => amenaza.Especies.Any(especie => especie.Id == IdEpecie) &&
                             amenaza.Ecosistemas.Any(ecosistema => ecosistema.Id == IdEcosistema))
                     .SingleOrDefault();

            return amenaza;
        }

        public bool EstadosDeConservacionCompatibles(int IdEpecie, int IdEcosistema)
        {
            bool compatible = false;

            var estadoEspecie = Contexto.Especies
                .Where(especie => especie.Id == IdEpecie)
                .Select(especie => especie.EstadoCons)
                .SingleOrDefault();

            var estadoEcosistema = Contexto.Ecosistemas
                .Where(ecosistema => ecosistema.Id == IdEcosistema)
                .Select(ecosistema => ecosistema.EstadoConservacion)
                .SingleOrDefault();

            if (estadoEcosistema.Valor >= estadoEspecie.Valor)
            {

                compatible = true;
            }

            return compatible;

        }

        public IEnumerable<Especie> EspeciesOrdenadasPorNombreCientifico()
        {

            var especies = Contexto.Especies
                .OrderBy(especie=>especie.NombreCientifico)
                .ToList();

            return especies;
        }

        public IEnumerable<Especie> EspeciesEnPeligroDeExtincion()
        {

            var especies = Contexto.Especies
                .Where(especie => especie.EstadoCons.Valor < 60 || especie.Amenazas.Count() > 3 ||
                (especie.habitats.Any(habitat => habitat.ecosistema.Amenazas.Count() > 3 
                && habitat.habita == true && habitat.ecosistema.EstadoConservacion.Valor < 60))).ToList();
                
            return especies;
        }


        public int ObtenerIdUltimaEspecie()
        {
            int numero = Contexto.Especies.Select(e => e.Id)
                                          .OrderByDescending(e => e)
                                          .FirstOrDefault();
            return numero;
        }

        public bool ExisteNombreEspecie(string nombreEspecie)
        {
            bool existe = Contexto.Especies.Any(e => e.NombreComun.Value == nombreEspecie);
            return existe;
        }

        public bool ExisteNombreCientificoEspecie(string nombreCientificoEspecie)
        {
            if (string.IsNullOrEmpty(nombreCientificoEspecie)) throw new EspecieException("EL NOMBRE CIENTÍFICO NO PUEDE ESTAR VACÍO");

            bool existe = Contexto.Especies.Any(e => e.NombreCientifico == nombreCientificoEspecie);
            return existe;
        }


        public Especie EspeciePorNombreCientifico(string nombre)
        {
            var especie = Contexto.Especies
                .Include(especie=>especie.EstadoCons)
                .Where(e=>e.NombreCientifico == nombre).SingleOrDefault();

            return especie;
        }


        public IEnumerable<Especie> especiesFiltradasPorEcosistema(string ecosistema)
        {
            var especies = Contexto.Especies
                                        .Where(e => e.habitats.Any(h => h.ecosistema.Nombre.Value == ecosistema && h.habita == true))
                                        .ToList();
            return especies;

        }

        public IEnumerable<Amenaza> ObtenerAmenazas(int idEspecie)
        {

            var amenazas = Contexto.Amenazas
                        .Where(amenaza=>amenaza.Especies.Any(especie=>especie.Id == idEspecie)).ToList();

            return amenazas;
        }

        public IEnumerable<Especie> BuscarEspeciesPorRangoDePeso(int pesoMin, int pesoMax)
        {
            if (pesoMax == 0) throw new EspecieException("EL VALOR INGRESADO COMO PESO MÁXIMO NO PUEDE SER 0.");
            if (pesoMax <= pesoMin) throw new EspecieException("EL PESO MÁXIMO DEBE SER MAYOR AL PESO MÍNIMO");
            if (pesoMax < 0 || pesoMin < 0) throw new EspecieException("LOS VALORES NUMÉRICOS DEBEN SER POSITÍVOS");

            IEnumerable<Especie> especies = Contexto.Especies
                                                .Where(e=> e.PesoMinimo >= pesoMin && e.PesoMaximo <= pesoMax)
                                                .ToList();
            return especies;
        }
    }
}
