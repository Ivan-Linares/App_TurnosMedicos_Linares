using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int Tipo { get; set; } //0 PACIENTE - 1 DOCTOR - 2 RECEPCIONISTA
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; }
        public Usuario ()
        {

        }
        public Usuario(int DNI, string Password)
        {
            this.DNI = DNI;
            this.Password = Password;
        }
    }
}
