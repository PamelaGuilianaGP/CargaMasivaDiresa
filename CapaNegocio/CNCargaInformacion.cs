using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class CNCargaInformacion
    {
        public static string FilaCabecera;
        public DataTable CargarDatos(string strm,int Id_Usuario)
        {
            DataTable tabla = null;
            StreamReader lector = new StreamReader(strm);
            String fila = String.Empty;
            Int32 cantidad = 0;
            do
            {
                fila = lector.ReadLine();
                if (fila == null)
                {
                    break;
                }
                if (0 == cantidad++)
                {
                    tabla = new CNCargaInformacion().CrearTabla(fila);
                    FilaCabecera = fila;
                }
                else
                    new CNCargaInformacion().AgregarFila(fila, tabla, FilaCabecera);
            } while (true);

            return GuardaRegistro(tabla, Id_Usuario);           
        }
        #region [Guardado de Informacion]
        public DataTable GuardaRegistro(DataTable tabla,int Id_Usuario)
        {
            string FilasError = "";
            int RegistrosLeidos = 0;
            int RegistrosInsert = 0;
            int RegistrosError = 0;
            foreach (DataRow row in tabla.Rows)
            {
                try
                {
                    
                    string Id_Paciente = row["Id_Paciente"].ToString();
                    int Id_Tipo_Documento = Convert.ToInt32(row["Id_Tipo_Documento"].ToString());
                    string Numero_Documento = row["Numero_Documento"].ToString();
                    string Apellido_Paterno_Paciente = row["Apellido_Paterno_Paciente"].ToString();
                    string Apellido_Materno_Paciente = row["Apellido_Materno_Paciente"].ToString();
                    string Nombres_Paciente = row["Nombres_Paciente"].ToString();
                    string Fecha_Nacimiento = row["Fecha_Nacimiento"].ToString();
                    string Genero = row["Genero"].ToString();
                    string Id_Etnia = row["Id_Etnia"].ToString();
                    string Historia_Clinica = row["Historia_Clinica"].ToString();
                    string Ficha_Familiar = row["Ficha_Familiar"].ToString();
                    string Ubigeo_Nacimiento = row["Ubigeo_Nacimiento"].ToString();
                    string Ubigeo_Reniec = row["Ubigeo_Reniec"].ToString();
                    string Domicilio_Reniec = row["Domicilio_Reniec"].ToString();
                    string Ubigeo_Declarado = row["Ubigeo_Declarado"].ToString();
                    string Domicilio_Declarado = row["Domicilio_Declarado"].ToString();
                    string Referencia_Domicilio = row["Referencia_Domicilio"].ToString();
                    string Id_Pais = row["Id_Pais"].ToString();
                    int Id_Establecimiento = Convert.ToInt32(row["Id_Establecimiento"].ToString());
                    string Fecha_Alta = row["Fecha_Alta"].ToString();
                    string Fecha_Modificacion = row["Fecha_Modificacion"].ToString();
                    string ValidaCarga = ConfigurationManager.AppSettings["ValidaCarga"].ToString();
                    //valida el numero de documento.
                  
                    if ((Id_Paciente != "" && Numero_Documento != "") || (ValidaCarga == "NO"))
                    {
                        //valida que los nombres del paciente tengan datos
                        if ((Nombres_Paciente != "" && Apellido_Paterno_Paciente != "" && Apellido_Materno_Paciente != "") || (ValidaCarga == "NO"))
                        {
                            //valida el historial clinico que tenga datos
                            if ((Historia_Clinica != "") || (ValidaCarga == "NO"))
                            {
                                //Valida que la longitud de algunas variables.
                                if ((Apellido_Paterno_Paciente.Length <= 50 && Apellido_Materno_Paciente.Length <= 50) || (ValidaCarga == "NO"))
                                {
                                    int resp = new CDCargaInformacion().Registro_Paciente(Id_Paciente,
                                                                                        Id_Tipo_Documento,
                                                                                        Numero_Documento,
                                                                                        Apellido_Paterno_Paciente,
                                                                                        Apellido_Materno_Paciente,
                                                                                        Nombres_Paciente,
                                                                                        Fecha_Nacimiento,
                                                                                        Genero,
                                                                                        Id_Etnia,
                                                                                        Historia_Clinica,
                                                                                        Ficha_Familiar,
                                                                                        Ubigeo_Nacimiento,
                                                                                        Ubigeo_Reniec,
                                                                                        Domicilio_Reniec,
                                                                                        Ubigeo_Declarado,
                                                                                        Domicilio_Declarado,
                                                                                        Referencia_Domicilio,
                                                                                        Id_Pais,
                                                                                        Id_Establecimiento,
                                                                                        Fecha_Alta,
                                                                                        Fecha_Modificacion,
                                                                                        Id_Usuario);
                                    if (resp == 1)
                                        RegistrosInsert++;

                                    if (resp == 2)
                                    {
                                        FilasError += Id_Paciente + ",Ya existe en base de datos,,*";
                                        RegistrosError++;
                                    }
                                }
                                else
                                {
                                    FilasError += Id_Paciente + ",Los apellidos superan la longitud de caracteres,,*";
                                    RegistrosError++;
                                }
                            }
                            else
                            {
                                FilasError += Id_Paciente + ",Tiene historial clinico vacio,,*";
                                RegistrosError++;
                            }
                        }
                        else
                        {
                            FilasError += Id_Paciente + ",Los nombres del paciente estan vacios,,*";
                            RegistrosError++;
                        }
                    }
                    else
                    {
                        FilasError += Id_Paciente + ",El Numero de documento esta vacio,,*";
                        RegistrosError++;
                    } 
                }
                catch (Exception ex)
                {
                    FilasError = ex.Message;
                }

                RegistrosLeidos++;
            }

            //GENERA TABLA DE ERRORES:
            DataTable tablaError = null;
            tablaError = CrearTabla("Id_Paciente,Error,Registros Leidos,Registros Sin error,Registros Con error");
            FilasError += ",," + RegistrosLeidos + "," + RegistrosInsert + "," + RegistrosError + "";
            String[] valoresError = FilasError.Split(new char[] { '*' });
            foreach (String val in valoresError)
            {
                AgregarFila(val, tablaError, "Id_Paciente,Error,Registros Leidos,Registros Sin error,Registros Con error");
            }
            return tablaError;
        }
        #endregion

        #region [Creacion DataTable]
        public bool ChecarExtension(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".csv":
                    return true;
                default:
                    return false;
            }
        }
        public DataTable CrearTabla(String fila)
        {

            DataTable tabla = new DataTable("Datos");
            String[] valores = fila.Split(new char[] { ',' });
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", val);
                tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
            }
            return tabla;
            
        }

        public DataRow AgregarFila(String fila, DataTable tabla,string FilaCabecera)
        {
            int cantidadColumnas = 100;
            String[] valores = fila.Split(new char[] { ',' });
            Int32 numeroTotalValores = valores.Length;
            if (numeroTotalValores > cantidadColumnas)
            {
                Int32 diferencia = numeroTotalValores - cantidadColumnas;
                for (Int32 i = 0; i < diferencia; i++)
                {

                    String nombreColumna = String.Format("{0}", (cantidadColumnas + i));
                    tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
                }
                cantidadColumnas = numeroTotalValores;
            }
            String[] FilasCabecera = FilaCabecera.Split(new char[] { ',' });
            DataRow dfila = tabla.NewRow();
            int index = 0;
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", FilasCabecera[index]);
                dfila[nombreColumna] = val.Trim();
                index++;
            }
            tabla.Rows.Add(dfila);
            return dfila;
        }
        #endregion
    }
}
