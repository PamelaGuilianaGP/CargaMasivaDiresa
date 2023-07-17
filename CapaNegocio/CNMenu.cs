using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Newtonsoft.Json;
using static CapaNegocio.Util;

namespace CapaNegocio
{
    public class CNMenu
    {
       
        public string GET_MENU(int IdUsuario)
        {
            try
            {
                string MenuHtml = "";
                int count = 0;
                DataSet ds = new CDMenu().GET_ROL_MENU(IdUsuario);
                foreach (DataRow dtRow in ds.Tables[0].Rows)
                {

                    DataSet dsSubMenu = new CDMenu().Get_SubMenus(Convert.ToInt32(dtRow["idMenu"].ToString()));
                    if (dsSubMenu.Tables[0].Rows.Count > 0)
                    {
                        MenuHtml += "<li class='nav-item'>" +
                                        "<a class='nav-link' onclick='MuestraSubmenu(" + count + ")'>" +
                                            "<i class='material-icons MenuPadre_"+ count + "'>keyboard_arrow_left</i>" +
                                                "<p>" + dtRow["NOMBRE"].ToString() + "</p>" +
                                        "</a>" +
                                        "<ul class='nav Submenu_" + count + "' style='margin-left:20px;display:none;'>";

                        foreach (DataRow dtRowSubmenu in dsSubMenu.Tables[0].Rows)
                        {
                            MenuHtml += "<li class='nav-item '>" +
                                                "<a class='nav-link' href='"+ dtRowSubmenu["URL"].ToString() + "'>" +
                                                    "<i class='material-icons' style='font-size:small;'>stop_circle</i>" +
                                                    "<p style='font-size:small;'>" + dtRowSubmenu["NOMBRE"].ToString() + "</p>" +
                                                "</a>" +
                                            "</li>";
                        }
                        MenuHtml += "</ul></li>";

                    }
                    else
                    {
                        MenuHtml += "<li class='nav-item'>" +
                                        "<a class='nav-link' href='" + dtRow["url"].ToString() + "'>" +
                                        "<i class='material-icons'>library_books</i>" +
                                                "<p>" + dtRow["NOMBRE"].ToString() + "</p>" +
                                        "</a>" +
                                    "</li>";
                    }

                    count++;
                }
                return MenuHtml;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string Select_Establecimiento(string Nombre)
        {
            DataSet ds = new CDMenu().Select_Establecimiento(Nombre);
            string jsonData = JsonConvert.SerializeObject(ds.Tables[0]);
            return jsonData;
        }
    }
}
