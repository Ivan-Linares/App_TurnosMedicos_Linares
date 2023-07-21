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
    public partial class GestionPaciente : System.Web.UI.Page
    {
        private Paciente pac;
        private PacienteNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            pac = new Paciente();
            negocio = new PacienteNegocio();

            pac = negocio.Paciente_Usuario(((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario);

            if (!IsPostBack)
            {
                CoberturaNegocio negocio = new CoberturaNegocio();
                List<Cobertura> lista = negocio.Listar();

                DDCobertura.DataSource = lista;
                DDCobertura.DataValueField = "IdCobertura";
                DDCobertura.DataTextField = "Descripcion";
                DDCobertura.DataBind();

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
                Paciente user = new Paciente();
                PacienteNegocio Negocio = new PacienteNegocio();

                user.Usuario = new Usuario();
                user.Usuario.IdUsuario = ((CapaNegocio.Usuario)Session["ActualUser"]).IdUsuario;
                user.Usuario.Tipo = 0;
                user.Usuario.DNI = int.Parse(TextDNI.Text);
                user.Usuario.Nombre = TextNombre.Text;
                user.Usuario.Apellido = TextApellido.Text;
                user.Usuario.Email = TextEmail.Text;
                user.Usuario.Domicilio = TextDomicilio.Text;
                user.Usuario.Telefono = TextTelefono.Text;
                user.Usuario.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                user.Usuario.Estado = true;
                user.Estado = true;

                user.Cobertura = new Cobertura();
                user.Cobertura.IdCobertura = int.Parse(DDCobertura.SelectedValue);

                Negocio.Modificar_Paciente(user);

                Response.Redirect("Index.aspx");
            }
        }
        private void CargarDatos()
        {
            TextDNI.Text = pac.Usuario.DNI.ToString();
            TextNombre.Text = pac.Usuario.Nombre.ToString();
            TextApellido.Text = pac.Usuario.Apellido.ToString();
            txtFechaNac.Text = pac.Usuario.FechaNacimiento.ToString("yyyy-MM-dd");
            DDCobertura.SelectedValue = pac.Cobertura.IdCobertura.ToString();
            TextDomicilio.Text = pac.Usuario.Domicilio.ToString();
            TextTelefono.Text = pac.Usuario.Telefono.ToString();
            TextEmail.Text = pac.Usuario.Email.ToString();
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