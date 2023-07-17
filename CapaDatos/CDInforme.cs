using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    
    public class CDInforme
    {
        public DB Instancia { get; set; }
        public CDInforme()
        {
            Instancia = new DB();
        }
        public DataSet Informe_Carga_Usuarios(int Id_Usuario, int Id_Establecimiento)
        {
            Instancia.DAAsignarProcedure("INFORME_CARGA_USUARIOS");
            Instancia.DAAgregarParametro("@ID_USUARIO", Id_Usuario);
            Instancia.DAAgregarParametro("@ID_ESTABLECIMIENTO", Id_Establecimiento);
            return Instancia.DAExecuteDataSet();
        }
    }
}
