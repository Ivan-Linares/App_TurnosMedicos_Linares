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
    public partial class GestionTurnos : System.Web.UI.Page
    {
        private bool DarBaja = false;
        private bool TieneTurnos = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();

            if (!IsPostBack)
            {
                DarBaja = false;
                
                if (negocio.ListarTurnosReservados(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario).Count == 0)
                    TieneTurnos = false;
            }

            if (negocio.ListarTurnosReservados(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario).Count == 0)
                TieneTurnos = false;

            if (negocio.ListarTurnosReservados(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario).Count > 0)
            {
                TieneTurnos = true;

                GvTurnosReservados.DataSource = negocio.ListarTurnosReservados(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario);
                GvTurnosReservados.DataBind();
            }
        }
        protected void GvTurnosReservados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DarBaja = true;
        }
        public bool DarBajaT()
        {
            return DarBaja;
        }
        public bool Turnos()
        {
            return TieneTurnos;
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();

            negocio.DarBajaTurno((int)GvTurnosReservados.SelectedDataKey.Value);

            Response.Redirect("GestionTurnosPaciente.aspx", true);
        }
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionTurnosPaciente.aspx", false);
        }
    }
}