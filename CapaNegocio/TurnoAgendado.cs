using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TurnoAgendado
    {
        public int IDTurno { get; set; }
        public TurnoDisponible TurnoDisponible { get; set; }
        public int IdPaciente { get; set; }
        public bool Activo { get; set; }
        public string NombreMed { get; set; }
        public string Apemed { get; set; }
        public string NombrePac { get; set; }
        public string ApePac { get; set; }
        public string Especialidad { get; set; }
        public bool Estado { get; set; }
    }
}
