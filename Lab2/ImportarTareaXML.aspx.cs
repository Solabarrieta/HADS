using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace Lab2
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        BusinessLogic.Logic bl = new BusinessLogic.Logic();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string asignatura = AsignaturasList

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string localizacionXml = "App_Data/XML/" + AsignaturasList.SelectedValue + ".xml";
            string localizacionXsl = "App_Data/XSL/VerTablaTareas.xsl";
            try
            {
                xmlTable.DocumentSource = Server.MapPath(localizacionXml);
                xmlTable.TransformSource = Server.MapPath(localizacionXsl);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Server.MapPath(localizacionXml));
                bl.importarDocumentoXml(xmlDoc);
            }
            catch(System.IO.FileNotFoundException) 
            {
                ControlMsg.Text = "Lo sentimos, la asignatura seleccionada no tiene ningún archivo XML para importar!";
            }

            /*if (File.Exists(Server.MapPath(localizacionXml)))
            {


            }
            else
            {
               
            }*/

        }

        protected void AsignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asignatura"] = AsignaturasList.SelectedValue;
        }
    }
}