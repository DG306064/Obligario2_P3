﻿

namespace MVC.DTOs
{
    public class DTOHabitat
    {
        public int Id { get; set; }
        public EcosistemaDTO Ecosistema { get; set; }
        public int IdEcosistema { get; set; }
        public int IdEspecie { get; set; }
        public string NombreEcosistema { get; set; }
        public bool Habita { get; set; }
        public IEnumerable<DTOHabitat> Habitats { get; set; }
        public IEnumerable<EcosistemaDTO> Ecosistemas { get; set; }
    }
}
