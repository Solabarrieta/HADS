using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Private.Admin
{
    public partial class ConfirmarEliminart : System.Web.UI.Page
    {
        String email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Request["email"].ToString();

            Label1.Text = "Desea eliminar la cuenta " + email + "?";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessLogic.Logic bl = new BusinessLogic.Logic();
            bl.eliminarUsuario(email);
            Label1.Text = "Cuenta eliminada";
            Button1.Visible = false;
        }
    }
}