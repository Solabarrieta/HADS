using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        List<string> teachers = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["correo"].Equals("vadillo@ehu.es")) {
                ImportarTareasBtn.Visible = false;
                ExportarTareasBtn.Visible = false;
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
            }
        }

        protected void VerTareasBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTareasProfesor.aspx");
        }

        protected void ImportarTareasBtn_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ImportarTareaXML.aspx");
        }

        protected void ExportarTareasBtn_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ExportarTareaXML.aspx");

        }

        protected void Prueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            teachers = (List<string>)Application["teachers"];
            teachers.Remove((string)Session["correo"]);
            Application["teachers"] = teachers;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}