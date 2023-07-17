using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CapaNegocio.Util;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class ListadoUsuarios : System.Web.UI.Page
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
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerUsuarios()
        {
            return new CNUsuario().Select_Usuarios();
        }
    }
}