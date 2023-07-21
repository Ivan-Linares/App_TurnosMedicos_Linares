using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TurnoDisponible
    {
        public int IDTurno { get; set; }
        public String FechaTurno { get; set; }
        public TimeSpan HoraTurno { get; set; }
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string EspecialidadDescrip { get; set; }
        public bool Disponible  { get; set; }
    }
}
