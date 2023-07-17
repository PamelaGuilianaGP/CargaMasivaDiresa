using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using static CapaNegocio.Util;

namespace ProyectoCargaMasivaInformacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string aviso = new CNUsuario().Iniciar_Sesion(txtemail.Text, txtPass.Text);
            if (aviso != "")
            {
                lbMensaje.Text = aviso;
                lbMensaje.ForeColor = System.Drawing.Color.Red;
                lbMensaje.Visible = true;
            }
            else
            {
                Usuario us = new CapaNegocio.CNUsuario().Login(txtemail.Text, txtPass.Text);
                string usua = new JavaScriptSerializer().Serialize(us);
                if (us.username != "")
                {
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtemail.Text, DateTime.Now, DateTime.Now.AddMonths(1), true, usua, FormsAuthentication.FormsCookiePath);
                    HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tkt));

                    //System.Windows.Forms.MessageBox.Show(ck)
                    Session["SistemasUsuario"] = txtemail.Text;
                    Response.Cookies.Add(ck);
                    //string strRedirect = Request["ReturnUrl"];
                    if (Session["Url"] != null)
                        Response.Redirect(new Util().SecureUrl(Session["Url"].ToString()));
                    else
                        Response.Redirect(new Util().SecureUrl("Admin/Index.aspx"));
                }
            }
        }
    }
}