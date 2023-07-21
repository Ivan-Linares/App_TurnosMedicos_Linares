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
    public partial class AsistenteTurnosDoctor : System.Web.UI.Page
    {

        EspecialidadNegocio Espnegocio;
        MedicoNegocio mednegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["ActualUser"] == null || ((CapaNegocio.Usuario)Session["ActualUser"]).Estado == false))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                Espnegocio = new EspecialidadNegocio();

                List<Especialidad> lista = Espnegocio.Listar();

                DDEspecialidades.DataSource = lista;
                DDEspecialidades.DataValueField = "IdEspecialidad";
                DDEspecialidades.DataTextField = "Descripcion";
                DDEspecialidades.DataBind();
            }
        }
        protected void DDEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            mednegocio = new MedicoNegocio();

            List<Medico> listamed = mednegocio.ListarPorEspecialidad(int.Parse(DDEspecialidades.SelectedValue));

            DDMedicos.DataSource = listamed;
            DDMedicos.DataValueField = "IdMedico";
            DDMedicos.DataTextField = "Apellido";
            DDMedicos.DataBind();
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TurnosDisponiblesNegocio Negocio = new TurnosDisponiblesNegocio();

                DateTime Fecha = DateTime.Parse(txtFechaTurno.Text.ToString());
                TimeSpan Hora = TimeSpan.Parse(TxtHora.Text.ToString());
                int idepec = int.Parse(DDEspecialidades.SelectedValue);
                int idmed = int.Parse(DDMedicos.SelectedValue);

                Negocio.AgregarTurnoDisponible(idmed, Fecha, Hora, idepec);

                Response.Redirect("AsistenteTurnosDoctor.aspx", true);
            }
        }
        protected void cvFecha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaIngresada;

            if (DateTime.TryParse(args.Value, out fechaIngresada))
            {
                if (fechaIngresada < DateTime.Now)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TimeSpan horaIngresada;
            TimeSpan inicio = new TimeSpan(8, 00, 00);
            TimeSpan fin = new TimeSpan(20, 00, 00);

            if (TimeSpan.TryParse(args.Value, out horaIngresada))
            {
                if (horaIngresada >= inicio && horaIngresada <= fin)
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