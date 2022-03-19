using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entities
{
    public class Message
    {
        private DataView dv;
        private String msg;

        public Message(DataView dv, string msg)
        {
            this.dv = dv;
            this.msg = msg;
        }

        public DataView Dv { get => dv; set => dv = value; }
        public string Msg { get => msg; set => msg = value; }
    }
}
