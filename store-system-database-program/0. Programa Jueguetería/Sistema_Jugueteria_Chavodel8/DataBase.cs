using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Sistema_Jugueteria_Chavodel8
{
    class DataBase
    {
        static public string Conexion = "Data source = DESKTOP-ULKMF4J\\RAICELYS; database= DBJugueteriaCHavodel8; integrated security = true;";             //conexion db
        public SqlConnection Conexiondb = new SqlConnection(Conexion);

        public SqlConnection AbrirConexion()
        {
            if (Conexiondb.State == ConnectionState.Closed)                             //Conexion Abierta (estado de la conexion)
                Conexiondb.Open();
            return Conexiondb;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexiondb.State == ConnectionState.Open)                               //Conexion Cerrada (estado de la conexion)
                Conexiondb.Close();
            return Conexiondb;
        }
    }
}
