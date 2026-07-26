using System.ComponentModel.DataAnnotations;

namespace StaffCoreRD.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria")]
        public string Cedula { get; set; } = string.Empty; 

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(23223, double.MaxValue, ErrorMessage = "Mínimo RD$23,223")]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;
    }
}