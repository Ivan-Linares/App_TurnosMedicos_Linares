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
    public partial class GestionContraseñaSecretaria : System.Web.UI.Page
    {
        Usuario usuario;
        UsuarioNegocio usuarioNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            usuario = new Usuario();
            usuarioNegocio = new UsuarioNegocio();

            usuario = usuarioNegocio.Loguear(((CapaNegocio.Usuario)Session["ActualUser"]));
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", false);
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TextContraVieja.Text != usuario.Password)
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

            else if ((TextContraVieja.Text == usuario.Password) && (TextContraNueva.Text == TextConfirmarContra.Text))
            {
                usuario.Password = TextContraNueva.Text;

                usuarioNegocio.Modificar_Usuario(usuario);

                Response.Redirect("Index.aspx", false);
            }
        }
    }
}