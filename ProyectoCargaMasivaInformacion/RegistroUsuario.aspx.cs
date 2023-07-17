using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;

namespace ProyectoCargaMasivaInformacion
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUnidad();
                CargarRol();
            }
        }
        public void CargarUnidad()
        {
            DataSet ds = new CNUsuario().Select_Unidad();
            ddUnidad.Items.Clear();
            ddUnidad.AppendDataBoundItems = true;
            ddUnidad.Items.Add(new ListItem("Seleccione Unidad", ""));
            ddUnidad.DataSource = ds;
            ddUnidad.DataTextField = "NOMBRE";
            ddUnidad.DataValueField = "IDUNIDAD";
            ddUnidad.DataBind();
        }
        public void CargarRol()
        {
            DataSet ds = new CNUsuario().Get_Rol();
            ddlRol.Items.Clear();
            ddlRol.AppendDataBoundItems = true;
            ddlRol.Items.Add(new ListItem("Seleccione Rol", ""));
            ddlRol.DataSource = ds;
            ddlRol.DataTextField = "nombre";
            ddlRol.DataValueField = "idRol";
            ddlRol.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string Usuario = txtusuario.Text.TrimEnd();
            string Password = txtPass2.Text.TrimEnd();
            int IdUnidad = Convert.ToInt32(ddUnidad.SelectedValue);
            string Alias = TxtAlias.Text.TrimEnd();
            string DNI = txtIdentificador.Text.TrimEnd();
            string Celular = txtCelular.Text.TrimEnd();
            string Correo = txtCorreo.Text.TrimEnd();
            string Nombres = txtNombres.Text.TrimEnd();
            string ApPaterno = txtApPaterno.Text.TrimEnd();
            string Apmaterno = txtApMaterno.Text.TrimEnd();
            int Rol = Convert.ToInt32(ddlRol.SelectedValue);

            int resp = new CNUsuario().Registra_usuario(Usuario, Password, IdUnidad, Alias, DNI, Celular, Correo, Nombres, ApPaterno, Apmaterno, Rol);
            lbmsg.Value = resp.ToString();
            if (resp>0)
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "RespGuardado();", true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "GuardadoConError();", true);
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Verifica_Correo(string email)
        {
            return new CNUsuario().Verifica_Correo(email);
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Verifica_Dni(string Dni)
        {
            return new CNUsuario().Verifica_DNI(Dni);
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Verifica_Usuario(string Usuario)
        {
            return new CNUsuario().Verifica_Usuario(Usuario);
        }
    }
}