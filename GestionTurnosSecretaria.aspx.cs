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
    public partial class GestionTurnosSecretaria : System.Web.UI.Page
    {
        private bool DniPac = false;
        private bool DarBaja = false;
        private bool TieneTurnos = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DarBaja = false;
                DniPac = false;

                TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();

                if (Session["DNI"] != null)
                {
                    if (negocio.ListarTurnosReservadosDNIPac((int)Session["DNI"]).Count > 0) 
                    {
                        

                        GvTurnosReservados.DataSource = negocio.ListarTurnosReservadosDNIPac((int)Session["DNI"]);
                        GvTurnosReservados.DataBind();
                    }
                }
            }
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Session.Add("DNI", TxtDNIPac.Text);
            
            DniPac = true;

            TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();
            if (negocio.ListarTurnosReservadosDNIPac((int)Session["DNI"]).Count > 0) 
            {
                TieneTurnos = true;
            }
            }
        protected void GvTurnosReservados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DarBaja = true;
        }
        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionTurnosSecretaria.aspx", false);
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            TurnosAgendadosNegocio negocio = new TurnosAgendadosNegocio();

            negocio.DarBajaTurno((int)GvTurnosReservados.SelectedDataKey.Value);

            Response.Redirect("GestionTurnosSecretaria.aspx", true);
        }
        public bool DniPaciente()
        {
            return DniPac;
        }
        public bool DarBajaT()
        {
            return DarBaja;
        }
        public bool Turnos()
        {
            return TieneTurnos;
        }
    }
}