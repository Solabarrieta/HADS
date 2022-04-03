using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using Entities;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class Logic
    {
        SqlConnect.Conectar sqlc = new SqlConnect.Conectar();
        public string insertarTarea(Entities.Tarea t)
        {

            return sqlc.insertarTarea(t);
             
        }

        public DataSet getUsuarios(string email)
        {
            return sqlc.getUsuarios(email);
        }

        public string eliminarUsuario(string email)
        {

            return sqlc.eliminarCuenta(email);
        }

        public Entities.Message verTareasAlumno(string email)
        {

            return sqlc.verTareasAlumno(email);
        }
        public DataTable verAsignaturas(string correo)
        {
            return sqlc.verAsignaturas(correo);
        }

        public DataSet getTareasGenericas(string asignatura)
        {
            return sqlc.getTareasGenericas(asignatura);
        }

        public DataTable verEstudianteTarea(string v)
        {
            return sqlc.verEstudianteTarea(v);
        }

        public string login(string email, string pass)
        {
            return sqlc.login(email, pass);
        }

        public Entities.Message instanciarTarea(Entities.Instancia t)
        {
            return sqlc.instanciarTarea(t);
        }

        public string insertUser(User user)
        {
            return sqlc.insertUser(user);
        }

        public List<string> importarDocumentoXml(XmlDocument xmlDoc, string asignatura)
        {
            return sqlc.importarDocumentoXml(xmlDoc, asignatura);
        }

        public string hashPass(string pass)
        {
            MD5 hash = MD5.Create();
            byte[] hashpass = hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
            pass = BitConverter.ToString(hashpass);
            pass = pass.Replace("-", "");
            pass = pass.ToLower();
            return pass;
        }
    }
}
