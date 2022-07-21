using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Capa_Datos
{
    public class Dato_Cliente
    {


        public DataTable ListaCliente(string cadena)
        {
          
            DataTable table = new DataTable();
         
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(cadena))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Lista_cliente";
                    cmd.Connection = myCon;

                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return table;
        }
    }
}
