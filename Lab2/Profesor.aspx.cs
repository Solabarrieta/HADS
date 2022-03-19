using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}