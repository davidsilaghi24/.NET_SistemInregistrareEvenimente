namespace SistemInregistrareEvenimente.Models
{
    public class Bilet
    {
        public int Id { get; set; }
        public int EvenimentId { get; set; }
        public Eveniment Eveniment { get; set; }
        public int Numar { get; set; } // Numărul biletului sau cantitatea
        public decimal Pret { get; set; }
    }
}
