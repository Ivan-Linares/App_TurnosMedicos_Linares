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
    public partial class GestionContraeñaDoctor : System.Web.UI.Page
    {
        Medico med;
        MedicoNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            med = new Medico();
            negocio = new MedicoNegocio();

            med = negocio.BuscarMedico(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario);
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", false);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TextContraVieja.Text != med.Usuario.Password)
            {
                LbError.Text = "La contraseña actual no coincide! Intenta otra vez";
                LbError.Visible = true;
                LbError2.Visible = false;
            }
            else if (TextContraNueva.Text != TextConfirmarContra.Text)
            {
                LbError2.Text = "Los valores de contraseña nueva no coinciden! Intenta otra vez";
                LbError2.Visible = true;
                LbError.Visible = false;
            }

            else if ((TextContraVieja.Text == med.Usuario.Password) && (TextContraNueva.Text == TextConfirmarContra.Text))
            {
                med.Usuario.Password = TextContraNueva.Text;

                negocio.ModificarMedico(med);

                Response.Redirect("Index.aspx", false);
            }
        }
    }
}