using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["SistemasUsuario"] = null;
                Session["Url"] = null;
                Response.Redirect("../Login.aspx");
            }
            catch (Exception ex)
            {
                Session["SistemasUsuario"] = null;
                Session["Url"] = null;
                Response.Redirect("../Login.aspx");
            }
        }
    }
}