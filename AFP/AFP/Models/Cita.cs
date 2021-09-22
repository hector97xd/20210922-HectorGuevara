using System;
using System.ComponentModel.DataAnnotations;

namespace AFP.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaCita { get; set; }
        [Required(ErrorMessage = "El Descripcion es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Paciente es obligatorio")]
        public string Paciente { get; set; }
        [Required(ErrorMessage = "El Doctor es obligatorio")]
        public string Doctor { get; set; }
    }
}
