using System.ComponentModel.DataAnnotations;

namespace TicketSystem.DAL.Models
{
    public class Developer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
