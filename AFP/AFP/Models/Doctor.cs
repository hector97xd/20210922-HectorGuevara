using System;
namespace AFP.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
