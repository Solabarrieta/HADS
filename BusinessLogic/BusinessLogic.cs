using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic
    {
          public string insertarTarea(Entities.Tarea t)
        {
            SqlConnect.Conectar sqlc = new SqlConnect.Conectar();
            return sqlc.insertarTarea(t);
             
        }

    }
}
