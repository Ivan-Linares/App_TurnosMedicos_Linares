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
    public partial class ListarPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteNegocio negocio = new PacienteNegocio();

                GvPacientes.DataSource = negocio.Listar();
                GvPacientes.DataBind();
            }
        }
        protected void GvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = GvPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarPaciente.aspx?id=" + Id, false);
        }
    }
}