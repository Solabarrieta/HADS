using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        List<string> students = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            students = (List<string>)Application["students"];
            students.Remove((string)Session["correo"]);
            Application["students"] = students;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

        }
    }
}