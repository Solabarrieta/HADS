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
        private SqlConnection cnn;
        public SqlConnection conectar()
        {
            
                string connectionString = "Server=tcp:hads2205a.database.windows.net,1433;Initial Catalog=HADS22-05A;Persist Security Info=False;User ID=tesnaola001;Password=AprobarHADS2205;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                cnn = new SqlConnection(connectionString);

                cnn.Open();
            
            
            return cnn;
        }

        public void cerrarCon() {
            cnn.Close();       
        }

        public string insertUser(string mail, string nombre, string apellidos, int numconfir, string tipo, string pass)
        {
            try
            {
                this.conectar();

                string comando = "insert into Usuarios (email, nombre, apellidos, numconfir, confirmado, tipo, pass) values (@mail, @nombre, @apellidos, @numconf, @confirmado, @tipo, @pass)";

                SqlCommand cmo = new SqlCommand(comando, cnn);

                cmo.Parameters.AddWithValue("@mail", mail);
                cmo.Parameters.AddWithValue("@nombre", nombre);
                cmo.Parameters.AddWithValue("@apellidos", apellidos);
                cmo.Parameters.AddWithValue("@numconf", numconfir);
                cmo.Parameters.AddWithValue("@confirmado", false);
                cmo.Parameters.AddWithValue("@tipo", tipo);
                cmo.Parameters.AddWithValue("@pass", pass);

                int numregs = cmo.ExecuteNonQuery();

                cerrarCon();

                return "OK";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public bool existUser(string email)
        {
            this.conectar();

            string comando = "select count(*) from Usuarios where email=@email";

            SqlCommand cmo = new SqlCommand(comando, cnn);

            cmo.Parameters.AddWithValue("@email", email);

            if (Convert.ToInt32(cmo.ExecuteScalar())> 0) {
                this.cerrarCon();
                return true;
            }
            this.cerrarCon();
            return false;
        }

        public string confUser(string mail, int num) {

            string n = this.getConfNum(mail);

            this.conectar();

            if (n.Equals(num.ToString())) {
                try
                {
                    string comando2 = "UPDATE Usuarios SET confirmado='TRUE' WHERE email=@email";

                    SqlCommand cmo = new SqlCommand(comando2, cnn);
                    cmo.Parameters.AddWithValue("@email", mail);

                    cmo.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            
            return "Error";
        }
      

        public string getConfNum(string mail)
        {
            this.conectar();

            string comando = "select numconfir from Usuarios where email=@email";

            SqlCommand cmoUser = new SqlCommand(comando, cnn);

            cmoUser.Parameters.AddWithValue("@email", mail);

            SqlDataReader data = cmoUser.ExecuteReader();

            while (data.Read()) {
                return data.GetInt32(0).ToString();
            }

            return "";

            this.cerrarCon();
        }
    }
}