namespace SistemInregistrareEvenimente.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EvenimentId { get; set; }
        public Eveniment Eveniment { get; set; }
        public int Rating { get; set; }
        public string Comentarii { get; set; }
    }
}
