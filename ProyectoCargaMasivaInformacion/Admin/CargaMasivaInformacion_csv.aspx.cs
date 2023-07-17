using CapaNegocio;
using System;
using System.Data;
using System.IO;
using static CapaNegocio.Util;
using CapaNegocio;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
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

        #region [Metodos]
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FuFile.HasFile)
            {
                if (new CNCargaInformacion().ChecarExtension(FuFile.FileName))
                {
                    FuFile.SaveAs(MapPath("Archivos/" + FuFile.FileName));

                    DataTable dt = new CNCargaInformacion().CargarDatos(MapPath("Archivos/" + FuFile.FileName),Convert.ToInt32(HfIdUsuario.Value));

                    GvResumenCarga.DataSource = dt;
                    GvResumenCarga.DataBind();
                }
                else
                    LbError.Text = "Error al subir el archivo, no es el tipo .CSV";
            }
            else
            {
                LbError.Text = "Error al subir el archivo o no es el tipo .CSV";
            }
        }
        #endregion

       

        
    }
}