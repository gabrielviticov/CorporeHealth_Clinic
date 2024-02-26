using Microsoft.AspNetCore.Identity;

namespace CorporeHealth_Clinic.API.Domains.Entities.Models
{
    public class Doctor : IdentityUser
    {
        public Person Person { get; set; } = default!;
        public string? Crm { get; init; } 
        public string Specialty { get; set; } = string.Empty;
        public DateOnly Admission { get; init; }
        public DateOnly Demission { get; set; }
        public bool IsActive { get; set; } = default;

    }
}