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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            DatosUsuario();
        }
        void DatosUsuario()
        {
            if (((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 0)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                LbCobertura.Text = negocio.Cobertura_Usuario(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario);

                LbCobertura.Visible=true;
                Lbcob.Visible=true;
            }

            ApeNom.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Nombre.ToString() + " " + ((CapaNegocio.Usuario)Session["ActualUser"]).Apellido.ToString() + "!";

            //LbIDUsuario.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario.ToString();
            LbDni.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).DNI.ToString();
            //LbNombre.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Nombre.ToString();
            //LbApellido.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Apellido.ToString();
            LbEmail.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Email.ToString();
            //LbDomicilio.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Domicilio.ToString();
            //LbTelefono.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).Telefono.ToString();
           //LbFechaNac.Text = ((CapaNegocio.Usuario)Session["ActualUser"]).FechaNacimiento.ToShortDateString();

        }

        protected void BtnAgendar_Click(object sender, EventArgs e)
        {
            if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 0))
                Response.Redirect("AsistenteTurnosPaciente.aspx", false);
            
            else if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 1))
                Response.Redirect("AsistenteTurnosDoctor.aspx", false);
            
            else if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 2))
                Response.Redirect("AsistenteTurnosSecretaria.aspx", false);
        }

        protected void BtnGestionar_Click(object sender, EventArgs e)
        {
            if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 0))
                Response.Redirect("GestionTurnosPaciente.aspx", false);

            else if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 1))
                Response.Redirect("GestionTurnosDoctor.aspx", false);

            else if ((((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 2))
                Response.Redirect("GestionTurnosSecretaria.aspx", false);
        }
    }
}