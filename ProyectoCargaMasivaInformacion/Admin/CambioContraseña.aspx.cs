using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CapaNegocio.Util;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class CambioContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SistemasUsuario"] != null)
                {
                    Usuario us = new Util().getUserData();
                    HfIdUsuario.Value = us.idUsuario.ToString();
                }
                else
                {
                    Response.Redirect("../Login.aspx");

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string PassActual = txtPassActual.Text;
            string PassNew2 = txtPassNew2.Text;

            int Resp = new CNUsuario().Valida_Contraseña(Convert.ToInt32(HfIdUsuario.Value),
                                                            PassActual,
                                                            PassNew2);
            lbmsg.Value = Resp.ToString();

            if (Resp > 0)
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "RespGuardado();", true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "GuardadoConError();", true);
        }
    }
}