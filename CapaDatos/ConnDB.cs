using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConnDB
    {

        private SqlConnection Conn;
        private SqlCommand Cmd;
        private SqlDataReader DataReader;
        public ConnDB()
        {
            Conn = new SqlConnection("server=.\\SQLEXPRESS; database=Sistema_de_gestion_clinica; integrated security=true");
            Cmd = new SqlCommand();
        }

        public void Setear_Sp(string sp)
        {
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.CommandText = sp;
        }
        public void Setear_Sp(string sp, string Id)
        {
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.CommandText = sp;

        }

        public SqlDataReader Lector
        {
            get { return DataReader; }
        }

        public void ejecutarLectura()
        {
            Cmd.Connection = Conn;
            try
            {
                Conn.Open();
                DataReader = Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            Cmd.Connection = Conn;
            try
            {
                Conn.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            Cmd.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (DataReader != null)
                DataReader.Close();
            Conn.Close();
        }

    }
}
