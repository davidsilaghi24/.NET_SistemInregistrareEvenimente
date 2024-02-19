namespace SistemInregistrareEvenimente.Models
{
    public class EvenimentArtist
    {
        public int EvenimentId { get; set; }
        public Eveniment Eveniment { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
