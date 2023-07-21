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
    public partial class ListarDoctores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();

                GvDoctores.DataSource = negocio.ListarDatos();
                GvDoctores.DataBind();
            }
        }
        protected void GvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = GvDoctores.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarDoctor.aspx?id=" + Id, false);
        }
    }
}