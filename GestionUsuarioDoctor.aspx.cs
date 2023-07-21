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
    public partial class GestionUsuarioDoctor : System.Web.UI.Page
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

            CargarDatos();
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Medico user = new Medico();
                negocio = new MedicoNegocio();

                user.Usuario = new Usuario();
                user.Usuario.IdUsuario = ((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario;
                user.Usuario.Tipo = 1;
                user.Usuario.DNI = int.Parse(TextDNI.Text);
                user.Usuario.Nombre = TextNombre.Text;
                user.Usuario.Apellido = TextApellido.Text;
                user.Usuario.Email = TextEmail.Text;
                user.Usuario.Domicilio = TextDomicilio.Text;
                user.Usuario.Telefono = TextTelefono.Text;
                user.Usuario.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                user.Usuario.Estado = true;
                user.Estado = true;

                negocio.ModificarMedico(user);

                Response.Redirect("Index.aspx");
            }
        }
        private void CargarDatos()
        {
            TextDNI.Text = med.Usuario.DNI.ToString();
            TextNombre.Text = med.Usuario.Nombre.ToString();
            TextApellido.Text = med.Usuario.Apellido.ToString();
            txtFechaNac.Text = med.Usuario.FechaNacimiento.ToString("yyyy-MM-dd");
            TextDomicilio.Text = med.Usuario.Domicilio.ToString();
            TextTelefono.Text = med.Usuario.Telefono.ToString();
            TextEmail.Text = med.Usuario.Email.ToString();
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