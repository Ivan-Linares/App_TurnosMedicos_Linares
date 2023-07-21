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
    public partial class AsistenteTurnos : System.Web.UI.Page
    {
        private bool Especialidad = false;
        private bool Medico = false;
        private bool MedicoXEspecialidad = false;
        private bool Turnos = false;
        private bool ConfirmarTurno = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                Especialidad = false;
                Medico = false;
                MedicoXEspecialidad = false;
                Turnos = false;
                ConfirmarTurno = false;
            }
        }
        protected void Btnsiguiente_Click(object sender, EventArgs e)
        {
            if (RadioBL.SelectedIndex == 0)
            {
                Especialidad = true;

                EspecialidadNegocio negocio = new EspecialidadNegocio();

                GvEspecialidades.DataSource = negocio.Listar();
                GvEspecialidades.DataBind();
            }
            else
            {
                Medico = true;

                MedicoNegocio negocio = new MedicoNegocio();

                GvMedicos.DataSource = negocio.ListarDatos();
                GvMedicos.DataBind();
            }
        }
        public bool MostrarEpecialidades()
        {
            return Especialidad;
        }
        public bool MostrarMedicos()
        {
            return Medico;
        }
        public bool MostrarMedicoEspe()
        {
            return MedicoXEspecialidad;
        }
        public bool MostrarTurnos()
        {
            return Turnos;
        }
        public bool Confirmarturno()
        {
            return ConfirmarTurno;
        }
        protected void GvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicoXEspecialidad = true;

            MedicoNegocio negocio = new MedicoNegocio();

            GvMedicoEspec.DataSource = negocio.ListarPorEspecialidad((int)GvEspecialidades.SelectedDataKey.Value);
            GvMedicoEspec.DataBind();
        }
        protected void GvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turnos = true;

            TurnosDisponiblesNegocio turnos = new TurnosDisponiblesNegocio();

            if (turnos.ListarMedico((int)GvMedicos.SelectedDataKey.Value).Count > 0)
            {
                GvTurnos.DataSource = turnos.ListarMedico((int)GvMedicos.SelectedDataKey.Value);
                GvTurnos.DataBind();
            }
            else
            {
                LbError.Text = "Upss, este medico no tiene turnos disponibles! Contactese con nuestro personal administrativo!";
                LbError.Visible = true;
            }
        }
        protected void GvMedicoEspec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turnos = true;

            TurnosDisponiblesNegocio turnos = new TurnosDisponiblesNegocio();

            if (turnos.ListarEspecialidadMedico((int)GvMedicoEspec.SelectedDataKey.Value, (int)GvEspecialidades.SelectedDataKey.Value).Count > 0)
            {
                GvTurnos.DataSource = turnos.ListarEspecialidadMedico((int)GvMedicoEspec.SelectedDataKey.Value, (int)GvEspecialidades.SelectedDataKey.Value);
                GvTurnos.DataBind();
            }
            else
            {
                LbError.Text = "Upss, este medico no tiene turnos disponibles! Contactese con nuestro personal administrativo!";
                LbError.Visible = true;
            }
        }

        protected void GvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmarTurno = true;
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();

            negocio.ReservarTurno((int)GvTurnos.SelectedDataKey.Value, ((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario);

            Response.Redirect("AsistenteTurnosPaciente.aspx", true);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsistenteTurnosPaciente.aspx", true);
        }
    }
}