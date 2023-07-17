using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDUsuario
    {
        public DB Instancia { get; set; }
        public CDUsuario()
        {
            Instancia = new DB();
        }
        public DataSet Iniciar_Sesion(string Usuario_o_Correo, string contrasenia)
        {
            Instancia.DAAsignarProcedure("INICIAR_SESION");
            Instancia.DAAgregarParametro("@USUARIO_O_CORREO", Usuario_o_Correo);
            Instancia.DAAgregarParametro("@CONTRASENIA", contrasenia);
            return Instancia.DAExecuteDataSet();
        }

        public DataSet Obtener_Datos_Usuario(string Usuario_o_Correo, string contrasenia)
        {
            Instancia.DAAsignarProcedure("OBTENER_DATOS_USUARIOS");
            Instancia.DAAgregarParametro("@USUARIO_O_CORREO", Usuario_o_Correo);
            Instancia.DAAgregarParametro("@CONTRASENIA", contrasenia);
            return Instancia.DAExecuteDataSet();
        }

        public DataSet Select_Usuarios()
        {
            Instancia.DAAsignarProcedure("SELECT_USUARIOS");
            return Instancia.DAExecuteDataSet();
        }
        public int Registra_usuario(string Usuario,string Pass,int IdUnidad,string Alias,string DNI,string Celular,
                            string Correo,string Nombres,string ApPaterno,string ApMaterno,string Ip,string Host,int IdRol)
        {
            Instancia.DAAsignarProcedure("REGISTRA_USUARIO");
            Instancia.DAAgregarParametro("@USUARIO", Usuario);
            Instancia.DAAgregarParametro("@PASSWORD", Pass);
            Instancia.DAAgregarParametro("@IDUNIDAD", IdUnidad);
            Instancia.DAAgregarParametro("@ALIAS", Alias);
            Instancia.DAAgregarParametro("@DNI", DNI);
            Instancia.DAAgregarParametro("@CELULAR", Celular);
            Instancia.DAAgregarParametro("@CORREO", Correo);
            Instancia.DAAgregarParametro("@NOMBRES", Nombres);
            Instancia.DAAgregarParametro("@APPATERNO", ApPaterno);
            Instancia.DAAgregarParametro("@APMATERNO", ApMaterno);
            Instancia.DAAgregarParametro("@IP", Ip);
            Instancia.DAAgregarParametro("@HOSTNAME", Host);
            Instancia.DAAgregarParametro("@ID_ROL", IdRol);
            return Convert.ToInt32(Instancia.DAExecuteScalar());
        }
        public int Edit_usuario(int IdUsuario,int IdUnidad, string Alias, string DNI, string Celular,
                            string Correo, string Nombres, string ApPaterno, string ApMaterno, string Ip, string Host, int IdRol,int Estado)
        {
            Instancia.DAAsignarProcedure("EDIT_USUARIO");
            Instancia.DAAgregarParametro("@ID_USUARIO", IdUsuario);
            Instancia.DAAgregarParametro("@IDUNIDAD", IdUnidad);
            Instancia.DAAgregarParametro("@ALIAS", Alias);
            Instancia.DAAgregarParametro("@DNI", DNI);
            Instancia.DAAgregarParametro("@CELULAR", Celular);
            Instancia.DAAgregarParametro("@CORREO", Correo);
            Instancia.DAAgregarParametro("@NOMBRES", Nombres);
            Instancia.DAAgregarParametro("@APPATERNO", ApPaterno);
            Instancia.DAAgregarParametro("@APMATERNO", ApMaterno);
            Instancia.DAAgregarParametro("@IP", Ip);
            Instancia.DAAgregarParametro("@HOSTNAME", Host);
            Instancia.DAAgregarParametro("@ID_ROL", IdRol); 
            Instancia.DAAgregarParametro("@ESTADO", Estado);
            return Convert.ToInt32(Instancia.DAExecuteScalar());
        }
        public int Cambia_Contraseña(string Correo,string Contrasenia,string Ip, string Host)
        {
            Instancia.DAAsignarProcedure("CAMBIA_CONTRASEÑA");
            Instancia.DAAgregarParametro("@CORREO", Correo);
            Instancia.DAAgregarParametro("@PASSWORD", Contrasenia);
            Instancia.DAAgregarParametro("@IP", Ip);
            Instancia.DAAgregarParametro("@HOSTNAME", Host);
            return Convert.ToInt32(Instancia.DAExecuteScalar());
        }
        public DataSet Verifica_Correo(string Correo)
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT * FROM PERSONA WHERE CORREO ='"+ Correo + "'");
        }
        public DataSet Verifica_DNI(string DNI)
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT * FROM PERSONA WHERE DNI ='" + DNI + "'");
        }
        public DataSet Select_Unidad()
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT IDUNIDAD,NOMBRE FROM UNIDAD");
        }
        public DataSet Verifica_Usuario(string Usuario)
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT * FROM USUARIO WHERE USERNAME = '"+ Usuario + "'");
        }
        public DataSet Get_Rol()
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT idRol, nombre FROM ROL WHERE ESTADO = 1");
        }
        
        public DataSet Select_Usuario(int IdUsuario)
        {
            Instancia.DAAsignarProcedure("SELECT_USUARIO");
            Instancia.DAAgregarParametro("@IDUSUARIO", IdUsuario);
            return Instancia.DAExecuteDataSet();
        }

        public int Valida_Contraseña(int IdUsuario,string Pass,string PassNew)
        {
            Instancia.DAAsignarProcedure("VALIDA_CONTRASEÑA");
            Instancia.DAAgregarParametro("@PASS", Pass);
            Instancia.DAAgregarParametro("@ID_USUARIO", IdUsuario);
            Instancia.DAAgregarParametro("@PASSNEW", PassNew);
            return Convert.ToInt32(Instancia.DAExecuteScalar());
        }

        public DataSet Select_Usuario_Establecimiento(int Id_Establecimiento)
        {
            Instancia.DAAsignarProcedure("SELECT_USUARIO_ESTABLECIMIENTO");
            Instancia.DAAgregarParametro("@ID_ESTABLECIMIENTO", Id_Establecimiento);
            return Instancia.DAExecuteDataSet();
        }

    }
}
