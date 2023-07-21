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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CoberturaNegocio negocio = new CoberturaNegocio();
                List<Cobertura> lista = negocio.Listar();

                DDCobertura.DataSource = lista;
                DDCobertura.DataValueField = "IdCobertura";
                DDCobertura.DataTextField = "Descripcion";
                DDCobertura.DataBind();
            }
        }

        protected void BotonRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Paciente user = new Paciente();
                    PacienteNegocio Negocio = new PacienteNegocio();

                    user.Usuario = new Usuario();
                    user.Usuario.Tipo = 0;
                    user.Usuario.DNI = int.Parse(TextDNI.Text);
                    user.Usuario.Nombre = TextNombre.Text;
                    user.Usuario.Apellido = TextApellido.Text;
                    user.Usuario.Email = TextEmail.Text;
                    user.Usuario.Password = TextContra.Text;
                    user.Usuario.Domicilio = TextDomicilio.Text;
                    user.Usuario.Telefono = TextTelefono.Text;
                    user.Usuario.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                    user.Usuario.Estado = true;
                    user.Estado = true;

                    user.Cobertura = new Cobertura();
                    user.Cobertura.IdCobertura = int.Parse(DDCobertura.SelectedValue);

                    Negocio.Agregar_Paciente(user);

                    Response.Redirect("/Login.aspx", false);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void BotonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx", false);
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