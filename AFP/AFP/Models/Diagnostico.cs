﻿using System;
namespace AFP.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public Paciente Paciente { get; set; }
    }
}
