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
            Session["correo"] = "blanco@ehu.es";
        }

        protected void ExportarBtn_Click(object sender, EventArgs e)
        {
                string asignatura = Session["asignatura"] as string;
                DataSet dataSet = bl.exportarTareas(asignatura);
                DataTable dataTable = dataSet.Tables[0];
                TareasExportadas.DataSource = dataTable;
                TareasExportadas.DataBind();
                dataSet.Tables[0].Columns["codigo"].ColumnMapping = MappingType.Attribute;
                dataSet.WriteXml(Server.MapPath("App_Data/XML/" + asignatura + ".xml"));
        }

        protected void AsignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Session["asignatura"] = AsignaturasList.SelectedValue;

        }
    }
}