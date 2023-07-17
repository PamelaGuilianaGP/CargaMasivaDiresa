using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using CapaDatos;

namespace CapaNegocio
{
    public class Util
    {
        public DB Instancia { get; set; }
        public Util()
        {
            Instancia = new DB();
        }
        public DataSet GetDataSetSimpleQuery(String query)
        {
            try
            {
                return Instancia.DAExecuteSimpleQuerySelect(query);

                //DataSet dt = new DataSet();
                //SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Coneccion"].ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter(query, sqlconn);
                //sqlconn.Open();
                //da.Fill(dt);
                //sqlconn.Close();
                //return dt;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public int ExecuteNonQuerySimpleQuery(String query)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Coneccion"].ConnectionString);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                int ans = cmd.ExecuteNonQuery();
                cmd.Dispose();
                sqlconn.Close();
                return ans;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string RecortarCadenaXDesborde(string texto, int maxCaracteres)
        {
            try
            {
                return texto.Length > maxCaracteres ? texto.Substring(0, maxCaracteres) + "..." : texto;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public string SecureUrl(string url)
        {
            url = url.Replace("//", "/");
            string ruta = ConfigurationManager.AppSettings["DirectorioRaiz"].ToString() + url;
            ruta.Replace("'", "").Replace("<", "").Replace(">", "");
            return ruta;
        }
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public string RandomString(int length)
        {
            try
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public bool Envio_Correo_Olvido_Pass(string Correo)
        {
            try
            {
                bool flag = true;
                string Cuerpo = "";
                string Query = "SELECT U.userName, +' '+apepat+' '+apemat AS NOMBRES " +
                               "FROM PERSONA P "+
                               "INNER JOIN USUARIO U ON U.idPersonal = P.idPersonal "+
                               "WHERE CORREO = '"+ Correo + "'";
                DataSet ds = new Util().GetDataSetSimpleQuery(Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Contraseña = RandomString(8);
                    Cuerpo += "<h3>Estimado(a):" + ds.Tables[0].Rows[0]["userName"].ToString() + " " + ds.Tables[0].Rows[0]["NOMBRES"].ToString() + "</h3>";
                    Cuerpo += "<h3>Ud. Solicito una nueva contraseña</h3>";
                    Cuerpo += "<h4>CONTRASEÑA TEMPORAL :" + Contraseña + " </h4>";
                    Cuerpo += "<h4><a href='" + SecureUrl("Admin/Index.aspx") + "'>Ingresa al sistema desde aqui</a> </h4>";


                    string client_smtp = ConfigurationManager.AppSettings["MAILsmtp"];
                    string port = ConfigurationManager.AppSettings["MAILpuerto"];
                    string usuario = ConfigurationManager.AppSettings["MAILusuario"];
                    string password = ConfigurationManager.AppSettings["MAILpassword"];
                    bool ssl = Convert.ToBoolean(ConfigurationManager.AppSettings["MAILSSL"]);
                    MailMessage msg = new MailMessage();
                    msg.To.Add(Correo);
                    msg.From = new MailAddress(usuario, "NoResponder", System.Text.Encoding.UTF8);
                    msg.Subject = "Solicitud de contraseña";
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = GenerarFormatoCorreo(Cuerpo);
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient(client_smtp);
                    client.Credentials = new System.Net.NetworkCredential(usuario, password);
                    client.Port = Convert.ToInt32(port);
                    client.EnableSsl = ssl;
                    try
                    {
                        client.Send(msg);
                        flag = true;
                        int resp = new CNUsuario().Cambia_Contraseña(Correo, Contraseña);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public string GenerarFormatoCorreo(string body)
        {
            try
            {
                string Header = "<div style ='color: #4d4d4d; font-family: Helvetica,Arial,sans-serif; font-size: 14px; font-weight: normal; line-height: 19px; margin: 0; min-width: 100%; padding: 0; text-align: left; width: 100%' >" +
                                    "<table style = 'border-collapse: collapse; border-spacing: 0; color: #4d4d4d; font-family: Helvetica,Arial,sans-serif; font-size: 14px; font-weight: normal; height: 100%; line-height: 19px; margin: 0; padding: 0; text-align: left; vertical-align: top; width: 100%'>" +
                                         "<tbody>" +
                                             "<tr style = 'padding: 0; text-align: left; vertical-align: top'>" +
                                                 "<td align = center valign = top style = 'border-collapse: collapse; color: #4d4d4d; font-family: Helvetica,Arial,sans-serif; font-size: 14px; font-weight: normal; line-height: 19px; margin: 0; padding: 0; text-align: center; vertical-align: top; word-break: break-word'>" +
                                                     "<center style = 'width: 100%'>" +
                                                           "<table style = 'background-color:#E6E6E6;border-collapse:collapse;border-spacing:0;color:#fff;padding:0;text-align:inherit;vertical-align:top;width:100%'>" +
                                                              "<tbody>" +
                                                                   "<tr style = 'padding:0;text-align:center;vertical-align:top'>" +
                                                                        "<td style = 'border-collapse:collapse;color:#4d4d4d;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;padding:0;text-align:left;vertical-align:top;word-break:break-word'>" +
                                                                            "<div style = 'display:block;margin:0 auto;max-width:100%; padding:12px 333px'>" +
                                                                               "<p style = 'font-weight: 800;color:black;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;margin-bottom:10px;padding:0;text-align:center'>" +
                                                                                   "Servicio de Correo" +
                                                                                "</p>" +
                                                                              "</div>" +
                                                                             "</td>" +
                                                                            "</tr>" +
                                                                    "</tbody>" +
                                                           "</table>";
                string Footer = "<table style = 'border-collapse:collapse;border-spacing:0;padding:0;text-align:inherit;vertical-align:top;width:100%'>" +
                                    "<tbody>" +
                                        "<tr style = 'padding:0;text-align:left;vertical-align:top'>" +
                                            "<td style = 'border-collapse:collapse;color:#4d4d4d;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;padding:0;text-align:left;vertical-align:top;word-break:break-word'>" +
                                                "<div style = 'display:block;margin:0 auto;max-width:580px;padding:12px 16px'>" +
                                                "</div>" +
                                            "</td>" +
                                            "</tr>" +
                                        "</tbody>" +
                                "</table>" +
                                    "<table style = 'background-color: #454b52; border-collapse:collapse;border-spacing:0;padding:0;text-align:inherit;vertical-align:top;width:100%'>" +
                                        "<tbody>" +
                                            "<tr style = 'padding:0;text-align:left;vertical-align:top'>" +
                                            "<td style = 'border-collapse:collapse;color:#4d4d4d;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;padding:0;text-align:left;vertical-align:top;word-break:break-word'>" +
                                                "<div style = 'display:block;margin:0 auto;max-width:100%;padding:12px 16px'>" +
                                                    "<p style = 'color:#9b9b9b;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;margin-bottom:10px;padding:0;text-align:center'>" +
                                                        "</p>" +
                                                        "<p style = 'color:white;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;margin-bottom:10px;padding:0;text-align:center'>" +
                                                            "Atentamente : Soluciones de Sistemas " + "<br> " + "<br> " +
                                                                DateTime.Now.ToString("dd-MM-yyyy") + " | " + DateTime.Now.ToString("HH:mm:ss") +
                                                        "</p>" +
                                                        "<p style = 'color:#9b9b9b;font-family:Helvetica,Arial,sans-serif;font-size:14px;font-weight:normal;line-height:19px;margin:0;margin-bottom:10px;padding:0;text-align:center'>" +
                                                    "</p>" +
                                                "</div>" +
                                                "</td>" +
                                            "</tr>" +
                                            "</tbody>" +
                                    "</table>" +
                            "</center>" +
                        "</td>" +
                    "</tr>" +
                "</tbody>" +
            "</table>" +
        "</div>";
                return Header + body + Footer;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string GetNombrePc()
        {
            string strHostName = string.Empty;
            return Dns.GetHostName(); 
        }
        public Usuario getUserData()
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                Usuario us = new Usuario();
                JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                us = (Usuario)serializer1.Deserialize(ticket.UserData, us.GetType());
                return us;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public class Usuario
        {
            public string nombreUser { get; set; }
            public int idUsuario { get; set; }
            public string email { get; set; }
            public int idTipoUser { get; set; }
            public string tipoUser { get; set; }
            public string username { get; set; }
            public string dni { get; set; }
            public string Establecimiento { get; set; }

        }
    }
}
