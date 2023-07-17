using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Newtonsoft.Json;

namespace CapaNegocio
{
    public class CNInforme
    {
        public string Informe_Carga_Usuarios(int Id_Establecimiento , int Id_Usuario)
        {
            DataSet ds = new CDInforme().Informe_Carga_Usuarios(Id_Usuario, Id_Establecimiento);
            string jsonData = JsonConvert.SerializeObject(ds.Tables[0]);
            return jsonData;
        }
    }
}
