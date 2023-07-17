using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDMenu
    {
        public DB Instancia { get; set; }
        public CDMenu()
        {
            Instancia = new DB();
        }
        public DataSet GET_ROL_MENU(int Id_Usuario)
        {
            Instancia.DAAsignarProcedure("GET_ROL_MENU");
            Instancia.DAAgregarParametro("@ID_USUARIO", Id_Usuario);
            return Instancia.DAExecuteDataSet();
        }
        public DataSet Get_SubMenus(int IdPadre)
        {
            return Instancia.DAExecuteSimpleQuerySelect("SELECT NOMBRE,URL FROM MENU WHERE DEPENDENCIA = "+ IdPadre+ " AND IDMENU <>'"+ IdPadre + "' ");
        }

        public DataSet Select_Establecimiento(string Nombre)
        {
            Instancia.DAAsignarProcedure("Select_Establecimiento");
            Instancia.DAAgregarParametro("@NOMBRE", Nombre);
            return Instancia.DAExecuteDataSet();
        }

    }
}
