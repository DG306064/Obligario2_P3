
using MVC.DTOs;

namespace MVC.Models;
public class HabitatViewModel
{
    
    public DTOHabitat Habitat  { get; set; }
    public DTOEspecie Especie  { get; set; }

    public IEnumerable<DTOEcosistema> Ecosistemas { get; set; }
    public IEnumerable<DTOHabitat> Habitats { get; set; }
    public IEnumerable<DTOEspecie> Especies { get; set; }

    public int IdEcosistema  { get; set; }

    public int IdEspecie  { get; set; }
    public int IdHabitat { get; set; }

}
