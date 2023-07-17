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
    public partial class Informe_Actualizacion : System.Web.UI.Page
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
        public static string SelectEstablecimientos(string Nombres)
        {
            return new CNMenu().Select_Establecimiento(Nombres);
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string SelectUsuarios(int IdEstablecimiento)
        {
            return new CNUsuario().Select_Usuario_Establecimiento(IdEstablecimiento);
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerInforme(int IdEstablecimiento,int IdUsuario)
        {
            return new CNInforme().Informe_Carga_Usuarios(IdEstablecimiento.ToString()==""?0:IdEstablecimiento, IdUsuario.ToString()==""?0: IdUsuario);
        }
    }
}