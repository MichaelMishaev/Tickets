namespace exercise.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int PersonId { get; set; }
        public DateTime DateCreated { get; set; }
        public TicketType TicketType { get; set; }
    }
}
