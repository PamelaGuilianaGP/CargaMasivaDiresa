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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Usuario us = new Util().getUserData();
                LbNombres.Text = us.nombreUser;
                LbTipoUsuario.Text = us.tipoUser;
                LbEstablecimiento.Text = us.Establecimiento;
                LbMenu.Text = new CNMenu().GET_MENU(us.idUsuario);
            }
        }
    }
}