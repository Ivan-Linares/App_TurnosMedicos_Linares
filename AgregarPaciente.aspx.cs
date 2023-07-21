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
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        Paciente pac;
        private bool eliminar = false;
        private bool EsCarga=false;
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

            eliminar = false;
            EsCarga = false;

            if (Request.QueryString["Id"] != null)
                CargarModificiacion(Request.QueryString["Id"]);
        }
        protected void BotonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionUsuariosSecretaria.aspx", false);
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

                    Response.Redirect("GestionUsuariosSecretaria.aspx", false);
                }
                catch (Exception)
                {
                    throw;
                }
            }
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
        private void CargarModificiacion(string id)
        {
            eliminar = true;
            EsCarga = true;
            try
            {
                if (!IsPostBack)
                {
                    PacienteNegocio negocio = new PacienteNegocio();

                    List<Paciente> lista = negocio.Listar();

                    foreach (Paciente p in lista)
                    {
                        if (p.IdPaciente == int.Parse(id))
                            pac = p;
                    }

                    TextDNI.Text = pac.Usuario.DNI.ToString();
                    TextNombre.Text = pac.Usuario.Nombre.ToString();
                    TextApellido.Text = pac.Usuario.Apellido.ToString();
                    txtFechaNac.Text = pac.Usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                    DDCobertura.SelectedValue = pac.Cobertura.IdCobertura.ToString();
                    TextDomicilio.Text = pac.Usuario.Domicilio.ToString();
                    TextTelefono.Text = pac.Usuario.Telefono.ToString();
                    TextEmail.Text = pac.Usuario.Email.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool PuedeEliminar()
        {
            return eliminar;
        }
        public bool Carga()
        {
            return EsCarga;
        }

        protected void BotonEliminar_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();

            negocio.Eliminar_Paciente(int.Parse(Request.QueryString["Id"]));

            Response.Redirect("ListarPacientes.aspx", false);
        }
    }
}
