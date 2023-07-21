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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BotonLogin_Click(object sender, EventArgs e)
        {
            Usuario ingreso;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                ingreso = new Usuario(int.Parse(TxDNI.Text), TxPassword.Text);
                ingreso = negocio.Loguear(ingreso);

                if (ingreso.IdUsuario != 0)
                {
                    Session.Add("ActualUser", ingreso);
                    Response.Redirect("Index.aspx", false);
                }
                else
                {
                    LbError.Text = "Usuario no encontrado! Proba otra vez";
                    LbError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                
                LbError.Text = "Debes ingresar solo numeros en tu DNI! Proba otra vez";
                LbError.Visible = true;
            }
        }
    }
}