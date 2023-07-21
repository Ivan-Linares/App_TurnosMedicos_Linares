using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public Usuario Usuario { get; set; }
        public Cobertura Cobertura { get; set; }
        public bool Estado { get; set; }
    }
}
