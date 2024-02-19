using System.Collections.Generic;

namespace SistemInregistrareEvenimente.Models
{
    public class Artist
    {
        public Artist()
        {
            EvenimentArtisti = new List<EvenimentArtist>();
        }

        public int Id { get; set; }
        public string Nume { get; set; }
        public List<EvenimentArtist> EvenimentArtisti { get; set; }
    }
}
