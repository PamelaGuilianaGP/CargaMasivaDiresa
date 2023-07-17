using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CapaNegocio.Util;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class EditUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SistemasUsuario"] != null)
                {
                    string Id_Usuario = Request.QueryString["IdUsuario"];
                    
                    if (Id_Usuario!="" && Id_Usuario!=null)
                    {
                        HfIdUsuario.Value = Request.QueryString["IdUsuario"];
                    }
                    else
                    {
                        Usuario us = new Util().getUserData();
                        HfIdUsuario.Value = us.idUsuario.ToString();
                    }
                    Usuario us1 = new Util().getUserData();

                    if (us1.tipoUser != "ADMINISTRADOR")
                        ddlRol.Enabled = false;
                    else
                        ddlRol.Enabled = true;

                    CargarRol();
                    CargarUnidad();
                    GetDatosUsuario(Convert.ToInt32(HfIdUsuario.Value));
                }
                else
                {
                    Response.Redirect("../Login.aspx");

                }
            }
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
        public void CargarUnidad()
        {
            DataSet ds = new CNUsuario().Select_Unidad();
            ddlUnidad.Items.Clear();
            ddlUnidad.AppendDataBoundItems = true;
            ddlUnidad.Items.Add(new ListItem("Seleccione Unidad", ""));
            ddlUnidad.DataSource = ds;
            ddlUnidad.DataTextField = "NOMBRE";
            ddlUnidad.DataValueField = "IDUNIDAD";
            ddlUnidad.DataBind();
        }
        public void GetDatosUsuario(int IdUsuario)
        {
            DataSet ds = new CNUsuario().Select_Usuario(IdUsuario);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUsuario.Text = ds.Tables[0].Rows[0]["userName"].ToString();
                rbEstado.SelectedValue = ds.Tables[0].Rows[0]["ESTADO"].ToString();
                ddlUnidad.SelectedValue = ds.Tables[0].Rows[0]["idUnidad"].ToString();
                ddlRol.SelectedValue = ds.Tables[0].Rows[0]["idRol"].ToString();
                txtAlias.Text = ds.Tables[0].Rows[0]["alias"].ToString();
                txtDNI.Text = ds.Tables[0].Rows[0]["dni"].ToString();
                txtCelular.Text = ds.Tables[0].Rows[0]["nroCelular"].ToString();
                txtCorreo.Text = ds.Tables[0].Rows[0]["correo"].ToString();
                txtNombres.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
                txtAPPaterno.Text = ds.Tables[0].Rows[0]["apepat"].ToString();
                txtAPMaterno.Text = ds.Tables[0].Rows[0]["apemat"].ToString();
            }

        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Estado = rbEstado.SelectedValue;
            int IdUnidad = Convert.ToInt32(ddlUnidad.SelectedValue);
            string Alias = txtAlias.Text.TrimEnd();
            string DNI = txtDNI.Text.TrimEnd();
            string Celular = txtCelular.Text.TrimEnd();
            string Correo = txtCorreo.Text.TrimEnd();
            string Nombres = txtNombres.Text.TrimEnd();
            string ApPaterno = txtAPPaterno.Text.TrimEnd();
            string Apmaterno = txtAPMaterno.Text.TrimEnd();
            int Rol = Convert.ToInt32(ddlRol.SelectedValue);
            string Usuario = txtUsuario.Text;
           

            int resp = new CNUsuario().Edit_usuario(Convert.ToInt32(HfIdUsuario.Value),
                                                    IdUnidad,
                                                    Alias,
                                                    DNI,
                                                    Celular,
                                                    Correo,
                                                    Nombres,
                                                    ApPaterno,
                                                    Apmaterno,
                                                    Rol,
                                                    Convert.ToInt32(Estado));
            lbmsg.Value = resp.ToString();
            txtUsuario.Text = Usuario;
            if (resp > 0)
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "RespGuardado();", true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "GuardadoConError();", true);
        }
    }
}