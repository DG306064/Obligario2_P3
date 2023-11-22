
using MVC.DTOs;

namespace MVC.Models;
public class HabitatViewModel
{
    
    public DTOHabitat Habitat  { get; set; }
    public EspecieDTO Especie  { get; set; }

    public IEnumerable<EcosistemaDTO> Ecosistemas { get; set; }
    public IEnumerable<DTOHabitat> Habitats { get; set; }
    public IEnumerable<EspecieDTO> Especies { get; set; }

    public int IdEcosistema  { get; set; }

    public int IdEspecie  { get; set; }
    public int IdHabitat { get; set; }

}
