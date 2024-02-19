using System.Collections.Generic;

namespace SistemInregistrareEvenimente.Models
{
    public class Locatie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public List<Eveniment> Evenimente { get; set; }
    }
}
