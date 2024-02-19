using System;
using System.Collections.Generic;

namespace SistemInregistrareEvenimente.Models
{
    public class Eveniment
    {
        public Eveniment()
        {
            Bilete = new List<Bilet>();
            EvenimentArtisti = new List<EvenimentArtist>();
        }

        public int Id { get; set; }
        public string Nume { get; set; }
        public DateTime DataOra { get; set; }
        public int LocatieId { get; set; }
        public Locatie Locatie { get; set; }
        public List<Bilet> Bilete { get; set; }
        public List<EvenimentArtist> EvenimentArtisti { get; set; }
    }
}
