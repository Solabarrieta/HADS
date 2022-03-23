using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

namespace Lab2
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        BusinessLogic.Logic bl = new BusinessLogic.Logic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["correo"] = "vadillo@ehu.es";
        }

        protected void ExportarBtn_Click(object sender, EventArgs e)
        {

            string asignatura = Session["asignatura"] as string;
            XmlDocument xmlDoc = bl.exportarTareas(asignatura);
            xmlDoc.Save(Server.MapPath("App_Data/XML/" + asignatura + ".xml"));
        }

        protected void AsignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asignatura"] = AsignaturasList.SelectedValue;
        }
    }
}