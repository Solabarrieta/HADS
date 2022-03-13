using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tarea
    {
        private String codigo;
        private String descripcion;
        private String codigoAsig;
        private int hEstimadas;
        private bool explotacion;
        private String tipoTarea;

        public Tarea(string codigo, string descripcion, string codigoAsig, int hEstimadas, bool explotacion, string tipoTarea)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.codigoAsig = codigoAsig;
            this.hEstimadas = hEstimadas;
            this.explotacion = explotacion;
            this.tipoTarea = tipoTarea;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string CodigoAsig { get => codigoAsig; set => codigoAsig = value; }
        public int HEstimadas { get => hEstimadas; set => hEstimadas = value; }
        public bool Explotacion { get => explotacion; set => explotacion = value; }
        public string TipoTarea { get => tipoTarea; set => tipoTarea = value; }
    }
}
