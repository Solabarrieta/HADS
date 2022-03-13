using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Instancia
    {
        private String email;
        private String codTarea;
        private int hEstimadas;
        private int hReales;


        public Instancia(string email, string codTarea, int hEstimadas, int hReales)
        {
            this.email = email;
            this.codTarea = codTarea;
            this.hEstimadas = hEstimadas;
            this.hReales = hReales;
        }

        public string Email { get => email; set => email = value; }
        public string CodTarea { get => codTarea; set => codTarea = value; }
        public int HEstimadas { get => hEstimadas; set => hEstimadas = value; }
        public int HReales { get => hReales; set => hReales = value; }
    }
}