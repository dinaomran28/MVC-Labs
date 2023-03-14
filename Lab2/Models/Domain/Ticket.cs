namespace Lab2.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsClosed { get; set; }
        public Severities Severity { get; set; }
        public string? Description { get; set; }

        private static readonly List<Ticket> _tickets = new()
        {
            new Ticket { Id = Guid.NewGuid(), CreatedDate = new DateTime(2000,3,5), IsClosed = true, Severity = Severities.high, Description = "ticket1"},
            new Ticket { Id = Guid.NewGuid(), CreatedDate = new DateTime(1998,2,28), IsClosed = true, Severity = Severities.medium, Description = "ticket2"},
            new Ticket { Id = Guid.NewGuid(), CreatedDate = new DateTime(2000,5,1), IsClosed = true, Severity = Severities.low, Description = "ticket3"},
            new Ticket { Id = Guid.NewGuid(), CreatedDate = new DateTime(2000,4,7), IsClosed = false, Severity = Severities.high, Description = "ticket4"}
        };
        public static List<Ticket> GetTicketsList() => _tickets;
    }
}
