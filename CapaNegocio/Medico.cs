using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public Usuario Usuario { get; set; }
        public Especialidad Especialidad { get; set; }
        public bool Estado { get; set; }
        public string Apellido { get; set; }
    }
}
