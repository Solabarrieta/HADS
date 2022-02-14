using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsertUserDB
{
    public class Insert
    {
        public string Insertar(string mail, string nombre, string apellidos, int numconfir, bool confirmado, string tipo, string pass) {
            try
            {
                SqlConnect.Conectar cnn = new SqlConnect.Conectar();

                SqlConnection c = cnn.conectar();

                string comando = "insert into Usuarios (email) values ()";

                SqlCommand cmo = new SqlCommand(comando, c);

                int numregs = cmo.ExecuteNonQuery();

                return (numregs + mail + " insertado");

            }
            catch (Exception ex) {
                return ("INSERT ERROR: " + ex.Message);            
            }

            
        }
    }
}
