using System.ComponentModel.DataAnnotations;

namespace TicketSystem.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public Severity Severity { get; set; }
        public int DepartmentId { get; set; }

        //Navigational Properties are empty until I ask the (Eager Loading or Lazy Loading) to fill these properties but eager is better
        public Department? Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
    public enum Severity
    {
        Low,
        Medium,
        High
    }
}
