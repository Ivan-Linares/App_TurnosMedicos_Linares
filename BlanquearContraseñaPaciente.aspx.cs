using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace App_TurnosMedicos_Linares
{
    public partial class BlanquearContraseñasUsuarios : System.Web.UI.Page
    {
        PacienteNegocio negocio;
        Paciente paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                negocio = new PacienteNegocio();

                GvPacientes.DataSource = negocio.Listar();
                GvPacientes.DataBind();
            }
        }

        protected void GvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            negocio = new PacienteNegocio();

            List<Paciente> lista = negocio.Listar();

            foreach (Paciente p in lista)
            {
                if (p.IdPaciente == int.Parse(GvPacientes.SelectedDataKey.Value.ToString()))
                    paciente = p;
            }

            paciente.Usuario.Password = paciente.Usuario.DNI.ToString();

            negocio.Modificar_Paciente(paciente);

            if(paciente.Usuario.Password == paciente.Usuario.DNI.ToString())
            {
                LbConfirmacion.Text = "Contraseña blanqueada con exito!";
                LbConfirmacion.Visible = true;
            }
        }
    }
}