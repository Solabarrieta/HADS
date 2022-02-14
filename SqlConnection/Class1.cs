using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlConnect
{
    public class Conectar
    {
        string connectionString = "Server=tcp:hads2205a.database.windows.net,1433;Initial Catalog=HADS22-05A;Persist Security Info=False;User ID=tesnaola001;Password=AprobarHADS2205;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection conexion;

        conexion = new SqlConnection(connectionString);

        c
    }
}
