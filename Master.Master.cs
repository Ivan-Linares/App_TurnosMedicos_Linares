using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_TurnosMedicos_Linares
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool EsPaciente()
        {
            try
            {
                if (Session["ActualUser"] != null && ((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EsDoctor()
        {
            try
            {
                if (Session["ActualUser"] != null && ((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 1)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EsRecepcionista()
        {
            try
            {
                if (Session["ActualUser"] != null && ((CapaNegocio.Usuario)Session["ActualUser"]).Tipo == 2)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnUnlog_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", true);
        }
    }
}