﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCargaMasivaInformacion.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SistemasUsuario"] != null)
                {

                }
                else
                {
                    Response.Redirect("../Login.aspx");

                }
            }
        }
    }
}