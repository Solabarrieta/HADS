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
            string asignatura;
            if (!Page.IsPostBack)
            {
                string correo = Session["correo"] as string;
                AsignaturasList.DataSource = bl.verAsignaturas(correo);
                AsignaturasList.DataTextField = "codigoAsig";
                AsignaturasList.DataBind();
                Session["asignatura"] = AsignaturasList.SelectedValue;
                asignatura = Session["asignatura"] as string;
                TareasExportadas.DataSource = bl.getTareasGenericas(asignatura);
                TareasExportadas.DataBind();
            }
            else
            {
                Session["asignatura"] = AsignaturasList.SelectedValue;
                asignatura = Session["asignatura"] as string;
                TareasExportadas.DataSource = bl.getTareasGenericas(asignatura);
                TareasExportadas.DataBind();
            }
        }

        protected void ExportarBtn_Click(object sender, EventArgs e)
        {
            string asignatura = Session["asignatura"] as string;
            DataSet dataSet = bl.getTareasGenericas(asignatura);
            if (dataSet != null)
            {
                DataTable dataTable = dataSet.Tables[0];
                TareasExportadas.DataSource = dataTable;
                TareasExportadas.DataBind();
                dataSet.Tables[0].Columns["codigo"].ColumnMapping = MappingType.Attribute;
                dataSet.Namespace = "http://ji.ehu.es/has";
                dataSet.Prefix= "has";
                dataSet.WriteXml(Server.MapPath("App_Data/XML/" + asignatura + ".xml"));
            }
            else
            {

            }

        }

        protected void AsignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asignatura"] = AsignaturasList.SelectedValue;
        }
    }
}