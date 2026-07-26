using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Models;

namespace StaffCoreRD.Data
{
    public class StaffDbContext : IdentityDbContext<IdentityUser>
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Personal { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb); 

            mb.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    Nombre = "Ramon Mateo Lora",
                    Cedula = "001-1234567-8",
                    Cargo = "Analista de Sistemas",
                    Departamento = "Tecnología",
                    Salario = 45000,
                    FechaIngreso = new DateTime(2022, 3, 15),
                    Activo = true
                },
                new Staff
                {
                    Id = 2,
                    Nombre = "Elian Camino Mercedes",
                    Cedula = "001-9876543-2",
                    Cargo = "Especialista en Nómina",
                    Departamento = "Recursos Humanos",
                    Salario = 38000,
                    FechaIngreso = new DateTime(2021, 7, 1),
                    Activo = true
                }
            );
        }
    }
}