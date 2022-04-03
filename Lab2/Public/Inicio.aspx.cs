using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BusinessLogic.Logic bl = new BusinessLogic.Logic();
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
  
                string email = Email.Text;
                string pass = Password.Text;
                pass = bl.hashPass(pass);

                string result = bl.login(email, pass);

                if (result == "pass")
                {
                    Alerta.Text = "Contraseña incorrecta";

                }else if (result=="user")
                {
                    Alerta.Text = "Usuario no encontrado";

                }else if(result == "Profesor")
                {
                    FormsAuthentication.SetAuthCookie("Profesor", false);
                    //Roles.AddUserToRole(email, "Profesor");
                    Session["correo"] = Email.Text;
                    Session["rol"] = "Profesor";
                    Response.Redirect("../Private/Profesor/Profesor.aspx");

                }else if(result == "Alumno")
                {
                    FormsAuthentication.SetAuthCookie("Alumno", false);
                    //Roles.AddUserToRole(email, "Alumno");
                    Session["correo"] = Email.Text;
                    Session["rol"] = "Alumno";
                    Response.Redirect("../Private/Alumno/Alumno.aspx");
                }
                else if (result == "Admin")
                {
                    FormsAuthentication.SetAuthCookie("Admin", false);
                    
                    Session["correo"] = Email.Text;
                    Session["rol"] = "Admin";
                    Response.Redirect("../Private/Admin/Administrador.aspx");
                }
            }
            
        }
    }
}