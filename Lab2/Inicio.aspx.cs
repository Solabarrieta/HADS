using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string alert = Request.QueryString["alert"];

            if (alert != null)
            {
                if (alert.Equals("faltaconfirmar"))
                {
                    Alerta.Text = "Confirme su correo para completar el registro";
                }
            }
            else {
                Alerta.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                SqlConnect.Conectar bd = new SqlConnect.Conectar();

                bool correcto = bd.login(Email.Text, Password.Text);

                if (correcto)
                {
                    Response.Redirect("AreaUsuarios.aspx");
                }

                else {
                    Email.Text = "";
                    Alerta.Text="Usuario/Contraseña Incorrectos";
                }
            }
            
        }
    }
}