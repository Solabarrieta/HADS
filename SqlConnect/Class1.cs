using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;

namespace SqlConnect
{
    public class Conectar
    {
        private SqlConnection cnn;
        private SqlDataAdapter dataAdapter;
        private DataSet dataset = new DataSet();
        private DataTable datatable = new DataTable();
        private DataView dataview;
        private Entities.Message message;
        public SqlConnection conectar()
        {

            string connectionString = "Server = tcp:hads2205b.database.windows.net,1433; Initial Catalog=HADS22-05B; Persist Security Info = False; User ID = oier; Password =CrClONHEs25; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            cnn = new SqlConnection(connectionString);

            cnn.Open();


            return cnn;
        }

        public DataSet exportarTareas(string asignatura)
        {
            this.conectar();
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand("select * from TareaGenerica where codAsig=@asignatura",cnn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@asignatura", asignatura);
            dataset = new DataSet();
            datatable = new DataTable();
            dataAdapter.Fill(dataset, "TareaGenerica");
            return dataset;
        }


        /*
         * Si se importa todo correctamente devuelve una lista con el string Ok.
         * Si hay asignaturas que no se han insertado devuelve una lista con el código de dichas asignaturas.
         * Si ocuerre una excepción devuelve una lista con el mensaje de la excepción.
         */
        public List<string> importarDocumentoXml(XmlDocument xmlDoc, string asignatura)
        {
            List<string> resultado = new List<string>();
            try
            {
                this.conectar();
                dataAdapter = new SqlDataAdapter("select * from TareaGenerica", cnn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                commandBuilder.GetInsertCommand();
                dataset = new DataSet();
                datatable = new DataTable();
                dataAdapter.Fill(dataset, "TareaGenerica");
                datatable = dataset.Tables["TareaGenerica"];

                XmlNodeList nodeList;
                nodeList = xmlDoc.GetElementsByTagName("tarea");

                for (int i = 0; i < nodeList.Count; i++)
                {
                    Entities.Tarea tarea = new Entities.Tarea();
                    tarea.Codigo = nodeList[i].Attributes[0].Value;
                    tarea.Descripcion = nodeList[i].ChildNodes[0].ChildNodes[0].Value;
                    tarea.CodigoAsig = asignatura;
                    tarea.HEstimadas = Int32.Parse(nodeList[i].ChildNodes[1].ChildNodes[0].Value);
                    tarea.Explotacion = bool.Parse(nodeList[i].ChildNodes[3].ChildNodes[0].Value);
                    tarea.TipoTarea = nodeList[i].ChildNodes[2].ChildNodes[0].Value;
                    string state = this.insertarTarea(tarea);

                    //Añade los codigos de las tareas no insertas al resultado.
                    if (state != "Ok")
                    {
                        resultado.Add(state);
                    }
                }

                if (resultado.Count != 0)
                {
                    return resultado;
                }
                else
                {
                    resultado.Add("Ok");
                    return resultado;
                }
            }
            catch (Exception e)
            {
                resultado.Add(e.Message);
                return resultado;
            }
        }

        public string insertPassCod(string mail, int randNum)
        {

            this.conectar();

            try
            {
                string comando2 = "UPDATE Usuarios SET codpass=@num WHERE email=@email";

                SqlCommand cmo = new SqlCommand(comando2, cnn);
                cmo.Parameters.AddWithValue("@email", mail);
                cmo.Parameters.AddWithValue("@num", randNum);

                return cmo.ExecuteNonQuery().ToString();


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string login(string email, string pass)
        {
            this.conectar();

            try
            {
                string comando2 = "select tipo from dbo.Usuario where email=@email and pass=@pass";

                SqlCommand cmo = new SqlCommand(comando2, cnn);
                cmo.Parameters.AddWithValue("@email", email);
                cmo.Parameters.AddWithValue("@pass", pass);


                SqlDataReader data = cmo.ExecuteReader();

                while (data.Read())
                {
                    return data.GetString(0);
                }
                this.cerrarCon();

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void cerrarCon()
        {
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string cambiarPass(string codigo, string pass)
        {
            this.conectar();

            try
            {
                string comando2 = "UPDATE Usuarios SET pass=@pass WHERE codpass=@cod";

                SqlCommand cmo = new SqlCommand(comando2, cnn);
                cmo.Parameters.AddWithValue("@pass", pass);
                cmo.Parameters.AddWithValue("@cod", codigo);

                string result = cmo.ExecuteNonQuery().ToString();

                if (result.Equals("1"))
                {
                    string comando = "UPDATE Usuarios SET codpass=NULL WHERE codpass=@cod";

                    SqlCommand cmo2 = new SqlCommand(comando, cnn);
                    cmo2.Parameters.AddWithValue("@cod", codigo);

                    string result1 = cmo2.ExecuteNonQuery().ToString();


                }


                return result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool existUser(string email)
        {
            this.conectar();

            string comando = "select count(*) from Usuarios where email=@email";

            SqlCommand cmo = new SqlCommand(comando, cnn);

            cmo.Parameters.AddWithValue("@email", email);

            if (Convert.ToInt32(cmo.ExecuteScalar()) > 0)
            {
                this.cerrarCon();
                return true;
            }
            this.cerrarCon();
            return false;
        }

        public string confUser(string mail, int num)
        {

            string n = this.getConfNum(mail);

            this.conectar();

            if (n.Equals(num.ToString()))
            {
                try
                {
                    string comando2 = "UPDATE Usuarios SET confirmado='TRUE' WHERE email=@email";

                    SqlCommand cmo = new SqlCommand(comando2, cnn);
                    cmo.Parameters.AddWithValue("@email", mail);

                    cmo.ExecuteNonQuery();

                    return "Usuario Confirmado";
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

            while (data.Read())
            {
                return data.GetInt32(0).ToString();
            }
            this.cerrarCon();
            return "";

        }


        public Entities.Message verTareasAlumno(string email)
        {
            dataAdapter = new SqlDataAdapter();
            datatable = new DataTable();

            try
            {
                this.conectar();
                dataAdapter.SelectCommand = new SqlCommand("select codigo as Codigo, descripcion as Descripcion, codAsig as Asignatura, hEstimadas as Horas, explotacion as Explotacion, tipoTarea as TipoTarea from [dbo].[TareaGenerica] cross join(select codigoAsig from [dbo].[GrupoClase]cross join(select grupo from[dbo].[EstudianteGrupo] where email = @email) as EstGrupo where EstGrupo.grupo = [dbo].[GrupoClase].codigo) as Codigo where Codigo.codigoAsig = [dbo].[TareaGenerica].codAsig and[dbo].[TareaGenerica].explotacion = 'true' and not exists(select * from[dbo].[EstudianteTarea] where[dbo].[TareaGenerica].codigo = [dbo].[EstudianteTarea].codTarea)", cnn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email);
                SqlCommandBuilder commad = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataset, "Tareas");
                datatable = dataset.Tables["Tareas"];
                dataview = new DataView(datatable);
                message = new Entities.Message(dataview, "Ok");
                return message;
            }
            catch (Exception e)
            {
                message = new Entities.Message(null, e.Message);
                return message;
            }

        }

        public DataTable verEstudianteTarea(string correo)
        {

            this.conectar();

            dataAdapter = new SqlDataAdapter();
            datatable = new DataTable();
            dataset = new DataSet();

            dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM [dbo].[EstudianteTarea] WHERE email=@email", cnn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@email", correo);
            dataAdapter.Fill(dataset, "EstudianteTareas");
            return dataset.Tables["EstudianteTareas"];
        }


        public DataTable verAsignaturas(string correo)
        {
            dataAdapter = new SqlDataAdapter();
            datatable = new DataTable();
            dataset = new DataSet();
            this.conectar();
            try
            {

                dataAdapter = new SqlDataAdapter();
                string regExp = @"(^.{1,}@ikasle\.ehu\.es$)";
                Regex re = new Regex(regExp);


                if (re.IsMatch(correo))
                {
                    dataAdapter.SelectCommand = new SqlCommand("SELECT codigoAsig FROM EstudianteGrupo CROSS JOIN GrupoClase WHERE (EstudianteGrupo.email = @email) AND (EstudianteGrupo.grupo = GrupoClase.codigo)", cnn);
                }
                else
                {
                    dataAdapter.SelectCommand = new SqlCommand("SELECT codigoAsig FROM ProfesorGrupo CROSS JOIN GrupoClase WHERE (ProfesorGrupo.email = @email) AND (ProfesorGrupo.codigoGrupo = GrupoClase.codigo)", cnn);
                }
                dataAdapter.SelectCommand.Parameters.AddWithValue("@email", correo);
                dataAdapter.Fill(dataset, "Asig");
                datatable = dataset.Tables["Asig"];

                return datatable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /*
         * Si se inserta correctamente devuelve Ok.
         * Si la asignatura existe devuelve el código de la asignatura.
         * Si ha habido una excepción devuelve el mensaje de la excepción.
         */
        public string insertarTarea(Entities.Tarea t)
        {
            datatable = new DataTable();
            try
            {
                this.conectar();
                dataAdapter = new SqlDataAdapter("select * from TareaGenerica", cnn);
                SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataset, "TareaGenerica");
                datatable = dataset.Tables["TareaGenerica"];
                DataRow row = datatable.NewRow();
                row["codigo"] = t.Codigo;
                row["descripcion"] = t.Descripcion;
                row["codAsig"] = t.CodigoAsig;
                row["hEstimadas"] = t.HEstimadas;
                row["explotacion"] = t.Explotacion;
                row["tipoTarea"] = t.TipoTarea;
                DataRow[] exists = datatable.Select("codigo='"+t.Codigo+"'");
                if (exists != null)
                {
                    return t.Codigo;
                }
                else
                {
                    datatable.Rows.Add(row);
                    saveChanges("TareaGenerica");
                    return "Ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string saveChanges(String tabla)
        {
            try
            {
                dataAdapter.Update(dataset, tabla);
                dataset.AcceptChanges();
                return "Ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Entities.Message instanciarTarea(Entities.Instancia t)
        {
            datatable = new DataTable();
            try
            {
                this.conectar();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM [dbo].[EstudianteTarea] WHERE email=@email", cnn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@email", t.Email);
                SqlCommandBuilder command = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataset, "EstudianteTarea");
                datatable = dataset.Tables["EstudianteTarea"];
                DataRow row = datatable.NewRow();
                row["email"] = t.Email;
                row["codTarea"] = t.CodTarea;
                row["hEstimadas"] = t.HEstimadas;
                row["hReales"] = t.HReales;
                datatable.Rows.Add(row);
                dataview = new DataView(datatable);

                string estado = saveChanges("EstudianteTarea");
                message = new Entities.Message(dataview, estado);
                return message;
            }
            catch (Exception e)
            {
                message = new Entities.Message(null, e.Message);
                return message;
            }
        }
    }
}