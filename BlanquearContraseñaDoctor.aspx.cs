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
    public partial class BlanquearContraseñaDoctor : System.Web.UI.Page
    {
        MedicoNegocio negocio;
        Medico medi;
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
            negocio = new MedicoNegocio();

            List<Medico> lista = negocio.Listar();

            foreach (Medico p in lista)
            {
                if (p.IdMedico == int.Parse(GvDoctores.SelectedDataKey.Value.ToString()))
                    medi = p;
            }

            medi.Usuario.Password = medi.Usuario.DNI.ToString();

            negocio.ModificarMedico(medi);

            if (medi.Usuario.Password == medi.Usuario.DNI.ToString())
            {
                LbConfirmacion.Text = "Contraseña blanqueada con exito!";
                LbConfirmacion.Visible = true;
            }
        }
    }
}