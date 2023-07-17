using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Newtonsoft.Json;
using static CapaNegocio.Util;

namespace CapaNegocio
{
    public class CNUsuario
    {
        public string Iniciar_Sesion(string Usuario_o_Correo, string contrasenia)
        {
            string flag = "";
            try
            {
                DataSet ds = new CDUsuario().Iniciar_Sesion(Usuario_o_Correo, contrasenia);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Resp = Convert.ToInt32(ds.Tables[0].Rows[0]["RESPUESTA"].ToString());
                    switch (Resp)
                    {
                        case 2:
                            flag = "La Constraseña que esta ingresando es incorrecta";
                            break;
                        case 3:
                            flag = "El usuario no esta registrado en nuestra base de datos ";
                            break;
                        case 4:
                            flag = "El usuario esta bloqueado ,favor de comunicarse con el administrador";
                            break;
                        case 0:
                            flag = "Ocurrio un error,vuelva a intentar si el error persiste favor de comunicarse con el administrador";
                            break;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public Usuario Login(string Usuario_o_Correo, string contrasenia)
        {
            Usuario us = new Usuario();
            DataSet ds = new CDUsuario().Obtener_Datos_Usuario(Usuario_o_Correo, contrasenia);
            if (ds.Tables[0].Rows.Count > 0)
            {
                us.username = Usuario_o_Correo.ToString();
                us.idUsuario = Convert.ToInt32(ds.Tables[0].Rows[0]["IDUSUARIO"]);
                us.email = ds.Tables[0].Rows[0]["CORREO"].ToString();
                us.tipoUser = ds.Tables[0].Rows[0]["TIPO_USUARIO"].ToString();
                //us.idTipoUser = Convert.ToInt32(ds.Tables[0].Rows[0]["ID_TIPOUSUARIO"]);
                us.dni = ds.Tables[0].Rows[0]["DNI"].ToString();
                us.nombreUser = ds.Tables[0].Rows[0]["NOMBRES"].ToString();
                us.Establecimiento = ds.Tables[0].Rows[0]["ESTABLECIMIENTO"].ToString();
            }
            return us;
        }
        public DataSet Select_Unidad()
        {
            return new CDUsuario().Select_Unidad();
        }
        public string Verifica_Correo(string Correo)
        {
            try
            {
                string Resp = "";
                DataSet ds = new CDUsuario().Verifica_Correo(Correo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resp = "El correo ya esta siendo utilizado por otro usuario";
                }
                return Resp;
            }
            catch(Exception)
            {
                return "Ocurrio un Error";
            }
            
        }
        public string Verifica_DNI(string DNI)
        {
            try
            {
                string Resp = "";
                DataSet ds = new CDUsuario().Verifica_DNI(DNI);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resp = "El DNI ya esta registrado";
                }
                return Resp;
            }
            catch (Exception)
            {
                return "Ocurrio un Error";
            }
        }
        public string Verifica_Usuario(string Usuario)
        {
            try
            {
                string Resp = "";
                DataSet ds = new CDUsuario().Verifica_Usuario(Usuario);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resp = "El Nombre del usuario ya esta siendo usado";
                }
                return Resp;
            }
            catch (Exception)
            {
                return "Ocurrio un Error";
            }
        }
        public int Registra_usuario(string Usuario, string Pass, int IdUnidad, string Alias, string DNI, string Celular,
                            string Correo, string Nombres, string ApPaterno, string ApMaterno,int IdRol)
        {
            string Ip = new Util().GetLocalIPAddress();
            string HostName = new Util().GetNombrePc();
            return new CDUsuario().Registra_usuario(Usuario, Pass, IdUnidad, Alias, DNI, Celular,
                            Correo, Nombres, ApPaterno, ApMaterno, Ip, HostName, IdRol);
        }
        public int Edit_usuario(int IdUsuario, int IdUnidad, string Alias, string DNI, string Celular,
                            string Correo, string Nombres, string ApPaterno, string ApMaterno, int IdRol,int Estado)
        {
            string Ip = new Util().GetLocalIPAddress();
            string HostName = new Util().GetNombrePc();
            return new CDUsuario().Edit_usuario(IdUsuario, IdUnidad, Alias, DNI, Celular,
                            Correo, Nombres, ApPaterno, ApMaterno, Ip, HostName, IdRol, Estado);
        }
        public int Valida_Contraseña(int IdUsuario,string Pass,string PassNew)
        {
            return new CDUsuario().Valida_Contraseña(IdUsuario, Pass, PassNew);
        }
        public int Cambia_Contraseña(string Correo,string Contraseña)
        {
            string Ip = new Util().GetLocalIPAddress();
            string HostName = new Util().GetNombrePc();
            return new CDUsuario().Cambia_Contraseña(Correo, Contraseña,Ip,HostName);

        }
        public DataSet Get_Rol()
        {
            return new CDUsuario().Get_Rol();
        }
        public DataSet Select_Usuario(int IdUsuario)
        {
            return new CDUsuario().Select_Usuario(IdUsuario);
        }
        public string Select_Usuarios()
        {
            DataSet ds = new CDUsuario().Select_Usuarios();
            string jsonData = JsonConvert.SerializeObject(ds.Tables[0]);
            return jsonData;
        }
        public string Select_Usuario_Establecimiento(int Id_Establecimiento)
        {
            DataSet ds = new CDUsuario().Select_Usuario_Establecimiento(Id_Establecimiento);
            string jsonData = JsonConvert.SerializeObject(ds.Tables[0]);
            return jsonData;
        }
    }
}
