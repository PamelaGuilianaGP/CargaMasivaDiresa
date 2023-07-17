using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCargaMasivaInformacion
{
    public partial class OlvideClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool resp = new Util().Envio_Correo_Olvido_Pass(txtemail.Text);
            if (resp)
            {
                HfVerifica.Value = "Su contraseña temporal fue enviada a su correo";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "MostrarAlerta();", true);
            }    
            else
            {
                HfVerifica.Value = "Ocurrio un error al momento de enviar el correo intentelo nuevamente";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "MostrarAlerta();", true);
            }
                
        }
    }
}