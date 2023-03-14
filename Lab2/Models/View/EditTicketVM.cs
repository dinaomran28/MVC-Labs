using Lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2.Models.View
{
    public record EditTicketVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severities Severity { get; init; }
        public string? Description { get; init; }

        [Display(Name = "Department")]
        public Guid DepartmentId { get; init; }

        [Display(Name = "Developer")]
        public ICollection<Guid> DevelopersIds { get; init; } = null!;
    }
}
