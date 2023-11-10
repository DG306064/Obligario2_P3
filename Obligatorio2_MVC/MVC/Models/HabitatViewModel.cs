namespace MVC.Models;
using LogicaNegocio;

public class HabitatViewModel
{
    
    public Habitat Habitat  { get; set; }
    public Especie Especie  { get; set; }

    public IEnumerable<Ecosistema> Ecosistemas { get; set; }
    public IEnumerable<Habitat> Habitats { get; set; }
    public IEnumerable<Especie> Especies { get; set; }

    public int IdEcosistema  { get; set; }

    public int IdEspecie  { get; set; }
    public int IdHabitat { get; set; }

}
