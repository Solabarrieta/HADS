using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            int num = Convert.ToInt32(Request.QueryString["numconf"]);

            SqlConnect.Conectar bd = new SqlConnect.Conectar();

            string correcto = bd.confUser(email, num);
        }
    }
}