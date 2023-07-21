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
    public partial class GestionDatosSecretaria : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                CargarDatos();
            }
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Usuario user = new Usuario();
                UsuarioNegocio Negocio = new UsuarioNegocio();

                user = new Usuario();
                user.IdUsuario = ((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario;
                user.Tipo = 0;
                user.DNI = int.Parse(TextDNI.Text);
                user.Nombre = TextNombre.Text;
                user.Apellido = TextApellido.Text;
                user.Email = TextEmail.Text;
                user.Domicilio = TextDomicilio.Text;
                user.Telefono = TextTelefono.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                user.Estado = true;
                user.Estado = true;

                Negocio.Modificar_Usuario(user);

                Response.Redirect("Index.aspx");
            }
        }
        private void CargarDatos()
        {
            TextDNI.Text = usuario.DNI.ToString();
            TextNombre.Text = usuario.Nombre.ToString();
            TextApellido.Text = usuario.Apellido.ToString();
            txtFechaNac.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
            TextDomicilio.Text = usuario.Domicilio.ToString();
            TextTelefono.Text = usuario.Telefono.ToString();
            TextEmail.Text = usuario.Email.ToString();
        }

        protected void cvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaNacimiento;

            if (DateTime.TryParse(args.Value, out fechaNacimiento))
            {
                int edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (fechaNacimiento > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                if (edad >= 18)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}