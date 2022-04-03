using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        private string email;
        private string name;
        private string lastName;
        private string pass;
        private string rol;
        private int numconf;
        private int codpass;

        public User(string email, string name, string lastName, string pass, string rol, int numconf)
        {
            this.email = email;
            this.name = name;
            this.lastName = lastName;
            this.pass = pass;
            this.rol = rol;
            this.numconf = numconf;
            this.codpass = 0;
        }

        public User()
        {

        }

        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Numconf { get => numconf; set => numconf = value; }
        public int Codpass { get => codpass; set => codpass = value; }
    }
}
