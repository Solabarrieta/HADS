using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        SqlConnect.Conectar bd = new SqlConnect.Conectar();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RandomNumber.Class1 random = new RandomNumber.Class1();
                SendEmail.Class1 sMail = new SendEmail.Class1();
                

                int randNum = random.generateRandom();

                string mail = Email.Text;

                string bdResult = bd.insertPassCod(mail, randNum);

                string body = "El código para reestablecer tu contraseña es " + randNum.ToString();

                if (bdResult.Equals("1"))
                {
                    sMail.sendMail(mail, "Código para reestablecer contraseña", body);

                    EnseñarCodigo.Text = randNum.ToString();

                    alertCod.Text = "Código Enviado!";

                }
                else
                {
                    alertCod.Text = "Usuario no encontrado";
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                string codigo = Codigo.Text;

                string pass = Pass1.Text;

                string result = bd.cambiarPass(codigo, pass);

                if (result.Equals("1"))
                {
                    Label3.Text = "Contraseña reestablecida correctamente!";
                }
                else {
                    Label3.Text = "Algo falló";
                }
            }
        }
    }
}