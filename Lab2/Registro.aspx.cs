using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SendEmail.Class1 mail = new SendEmail.Class1();
                RandomNumber.Class1 random = new RandomNumber.Class1();
                SqlConnect.Conectar bd = new SqlConnect.Conectar();

                int numconf = random.generateRandom();
                string email = Email.Text;
                string nombre = Nombre.Text;
                string apellidos = Apellidos.Text;
                string pass = Pass1.Text;
                string rol = RadioButtonList1.SelectedValue;

                bool select = bd.existUser(email);

                if (select)
                {
                    Label1.Text = "Ya existe un usuario registrado con ese correo";
                }
                else
                {
                    string bdRes = bd.insertUser(email, nombre, apellidos, numconf, rol, pass);

                    Label1.Text = bdRes;

                    if (bdRes.Equals("OK"))
                    {
                        string body = "http://hads22-05a.azurewebsites.net//Confirmar.aspx?email=" + email+"&numconf="+numconf.ToString();

                        mail.sendMail(Email.Text, "prueba", body);
                        Response.Redirect("Inicio.aspx?alert=faltaconfirmar");
                    }

                }

            }
        }
    }
}