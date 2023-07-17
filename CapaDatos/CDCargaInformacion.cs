using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCargaInformacion
    {
        public DB Instancia { get; set; }
        public CDCargaInformacion()
        {
            Instancia = new DB();
        }

        public int Registro_Paciente(string Id_Paciente,int Id_Tipo_Documento_Paciente,string Numero_Documento_Paciente,string Apellido_Paterno_Paciente,
                                    string Apellido_Materno_Paciente,string Nombres_Paciente,string Fecha_Nacimiento_Paciente,
                                    string Genero,string Id_Etnia,string Historia_Clinica,string Ficha_Familiar,string Ubigeo_Nacimiento,
                                    string Ubigeo_Reniec,string Domicilio_Reniec,string Ubigeo_Declarado,string Domicilio_Declarado,
                                    string Referencia_Domicilio,string Id_Pais,int Id_Establecimiento,string Fecha_Alta,string Fecha_Modificacion,int Id_Usuario)
        {
            Instancia.DAAsignarProcedure("REGISTRO_PACIENTE");
            Instancia.DAAgregarParametro("@Id_Paciente", Id_Paciente);
            Instancia.DAAgregarParametro("@Id_Tipo_Documento_Paciente", Id_Tipo_Documento_Paciente);
            Instancia.DAAgregarParametro("@Numero_Documento_Paciente", Numero_Documento_Paciente);
            Instancia.DAAgregarParametro("@Apellido_Paterno_Paciente", Apellido_Paterno_Paciente);
            Instancia.DAAgregarParametro("@Apellido_Materno_Paciente", Apellido_Materno_Paciente);
            Instancia.DAAgregarParametro("@Nombres_Paciente", Nombres_Paciente);
            Instancia.DAAgregarParametro("@Fecha_Nacimiento_Paciente", Fecha_Nacimiento_Paciente);
            Instancia.DAAgregarParametro("@Genero", Genero);
            Instancia.DAAgregarParametro("@Id_Etnia", Id_Etnia);
            Instancia.DAAgregarParametro("@Historia_Clinica", Historia_Clinica);
            Instancia.DAAgregarParametro("@Ficha_Familiar", Ficha_Familiar);
            Instancia.DAAgregarParametro("@Ubigeo_Nacimiento", Ubigeo_Nacimiento);
            Instancia.DAAgregarParametro("@Ubigeo_Reniec", Ubigeo_Reniec);
            Instancia.DAAgregarParametro("@Domicilio_Reniec", Domicilio_Reniec);
            Instancia.DAAgregarParametro("@Ubigeo_Declarado", Ubigeo_Declarado);
            Instancia.DAAgregarParametro("@Domicilio_Declarado", Domicilio_Declarado);
            Instancia.DAAgregarParametro("@Referencia_Domicilio", Referencia_Domicilio);
            Instancia.DAAgregarParametro("@Id_Pais", Id_Pais);
            Instancia.DAAgregarParametro("@Id_Establecimiento", Id_Establecimiento);
            Instancia.DAAgregarParametro("@Fecha_Alta", Fecha_Alta);
            Instancia.DAAgregarParametro("@Fecha_Modificacion", Fecha_Modificacion);
            Instancia.DAAgregarParametro("@Id_Usuario", Id_Usuario);
            return Convert.ToInt32(Instancia.DAExecuteScalar());
        }
    }
}
