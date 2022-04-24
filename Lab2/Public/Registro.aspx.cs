using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace Lab2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            matriculas.Matriculas matricula = new matriculas.Matriculas();

            if (Page.IsValid)
            {
                
                if (matricula.comprobar(Email.Text) == "SI")
                {
                    Email.SendEmail sendEmail = new Email.SendEmail();
                    RandomNumber.Class1 random = new RandomNumber.Class1();
                    BusinessLogic.Logic bl = new BusinessLogic.Logic();
                    SqlConnect.Conectar bd = new SqlConnect.Conectar();

                    int numconf = random.generateRandom();
                    string email = Email.Text;
                    string name = Nombre.Text;
                    string lastName = Apellidos.Text;
                    string pass = Pass1.Text;
                    string rol = RadioButtonList1.SelectedValue;

                    Entities.User user = new Entities.User(email, name, lastName, bl.hashPass(pass), rol, numconf);

                    string result = bl.insertUser(user);

                    if (result != "Ok")
                    {
                        Label1.Text = result;
                    }
                    else
                    {

                        Label1.Text = "Te has registrado correctamente, revisa tu correo para confirmar tu registro!";
                        string body = "http://hads22-05a.azurewebsites.net//Confirmar.aspx?email=" + email + "&numconf=" + numconf.ToString();

                        sendEmail.sendMail(Email.Text, "prueba", body);
                        Response.Redirect("Public/Inicio.aspx?alert=faltaconfirmar");
                    }
                }
                else
                {
                    Label1.Text = "Lo sentimos, los usuarios no matriculados en la asignatura HADS no se pueden registrar";
                }


            }
        }

        protected void Email_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            matriculas.Matriculas matricula = new matriculas.Matriculas();
            if (matricula.comprobar(Email.Text) == "SI")
            {
                No.Visible = false;
                Si.Visible = true;
            }
            else
            {
                No.Visible = true;
                Si.Visible = false;
            }
        }
    }
}