using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;

namespace App_TurnosMedicos_Linares
{
    public partial class GestionTurnosDoctor : System.Web.UI.Page
    {
        private bool TurnosDisponibles = false;
        private bool TurnosReservados = false;
        private bool TieneTurnosDisponibles = false;
        private bool TieneTurnosReservados = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
               TurnosDisponibles = false;
               TurnosReservados = false;
               TieneTurnosDisponibles = false;
               TieneTurnosReservados = false;
            }

            CargarGV();
        }
        protected void GvTurnosReservados_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnosReservados = true;
        }
        protected void GvTurnosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnosDisponibles = true;
        }
        public bool Disponibles()
        {
            return TurnosDisponibles;
        }
        public bool Reservados()
        {
            return TurnosReservados;
        }
        public bool TieneDispo()
        {
            return TieneTurnosDisponibles;
        }
        public bool TieneReser()
        {
            return TieneTurnosReservados;
        }
        private void CargarGV()
        {
            TurnosDisponiblesNegocio negocio = new TurnosDisponiblesNegocio();
            TurnosAgendadosNegocio agendado = new TurnosAgendadosNegocio();
            MedicoNegocio medicoDao = new MedicoNegocio();
            Medico aux = medicoDao.BuscarMedico((((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario));

            if (negocio.ListarMedico(aux.IdMedico).Count > 0)
                TieneTurnosDisponibles = true;

            if (TieneTurnosDisponibles)
            {
                GvTurnosDisponibles.DataSource = negocio.ListarMedico(aux.IdMedico);
                GvTurnosDisponibles.DataBind();

                LbDisponible.Text = "Turnos Disponibles!";
                LbDisponible.Visible = true;
            }
            else
            {
                LbDisponible.Text = "No tenes turnos disponibles, contacta con el personal administrativo!";
                LbDisponible.Visible = true;
            }

            if(agendado.ListarTurnosReservadosMedicos((((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario)).Count > 0)
                TieneTurnosReservados = true;

            if (TieneTurnosReservados)
            {
                GvTurnosReservados.DataSource = agendado.ListarTurnosReservadosMedicos((((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario));
                GvTurnosReservados.DataBind();

                LbReservados.Text = "Turnos Reservados!";
                LbReservados.Visible = true;
            }
            else
            {
                LbReservados.Text = "Aun no tiene turnos reservados!";
                LbReservados.Visible = true;
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionTurnosDoctor.aspx", true);
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void BtnCancelarReser_Click(object sender, EventArgs e)
        {
            TurnosAgendadosNegocio agendado = new TurnosAgendadosNegocio();

            agendado.DarBajaTurno((int)GvTurnosReservados.SelectedDataKey.Value);

            Response.Redirect("GestionTurnosDoctor.aspx", true);
        }
        protected void BtnRealizado_Click(object sender, EventArgs e)
        {
            TurnosAgendadosNegocio agendado = new TurnosAgendadosNegocio();

            agendado.TurnoRealizado((int)GvTurnosReservados.SelectedDataKey.Value);

            Response.Redirect("GestionTurnosDoctor.aspx", true);
        }
    }
}