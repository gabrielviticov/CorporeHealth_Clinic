using CorporeHealth_Clinic.API.Domains.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CorporeHealth_Clinic.API.Data
{
    public class DoctorDbContext : IdentityDbContext
    {
        public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options)
        {
            
        }

        //Sobrescrever o método OnModelCreating para definir que a classe 'Person' não será uma entidade e seus atributos farão partes da entidade 'Doctor'. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>()
            .OwnsOne(embedded => embedded.Person)
            .WithOwner();
            base.OnModelCreating(builder);
        }
    }
}