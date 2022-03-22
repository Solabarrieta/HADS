using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace BusinessLogic
{
    public class Logic
    {
        SqlConnect.Conectar sqlc = new SqlConnect.Conectar();
        public string insertarTarea(Entities.Tarea t)
        {

            return sqlc.insertarTarea(t);
             
        }

        public Entities.Message verTareasAlumno(string email)
        {

            return sqlc.verTareasAlumno(email);
        }

        public DataTable verAsignaturas(string correo)
        {
            return sqlc.verAsignaturas(correo);
        }

        public DataTable verEstudianteTarea(string v)
        {
            return sqlc.verEstudianteTarea(v);
        }

        public Entities.Message instanciarTarea(Entities.Instancia t)
        {
            return sqlc.instanciarTarea(t);
        }

        public String importarDocumentoXml(XmlDocument xmlDoc, string asignatura)
        {
            return sqlc.importarDocumentoXml(xmlDoc, asignatura);
        }
    }
}
