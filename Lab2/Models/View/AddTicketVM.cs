using Lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.View
{
    public record AddTicketVM
    {
        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severities Severity { get; init; }
        public string? Description { get; init; }
    };
}