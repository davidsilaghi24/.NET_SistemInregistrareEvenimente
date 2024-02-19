namespace SistemInregistrareEvenimente.Models
{
    public class Rezervare
    {
        public int Id { get; set; }
        public int EvenimentId { get; set; }
        public Eveniment Eveniment { get; set; }
        public int NumarLocuri { get; set; }
    }
}
