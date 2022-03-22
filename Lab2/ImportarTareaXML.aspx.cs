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
            Session["correo"] = "vadillo@ehu.es";
        }

        protected void ImportarBtn_Click(object sender, EventArgs e)
        {
            string asignatura = AsignaturasList.SelectedValue;
            string localizacionXml = "App_Data/XML/" + asignatura + ".xml";
            string localizacionXsl = "App_Data/XSL/VerTablaTareas.xsl";

            if (File.Exists(Server.MapPath(localizacionXml)))
            {
                xmlTable.DocumentSource = Server.MapPath(localizacionXml);
                xmlTable.TransformSource = Server.MapPath(localizacionXsl);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Server.MapPath(localizacionXml));
                List<string> state = bl.importarDocumentoXml(xmlDoc, asignatura);
                string mensaje = "";
                
                if(state[0] == "Ok")
                {
                    ControlMsg.Text = "Las tareas se han importado correctamente!";
                }
                else
                {
                    for(int i = 0; i < state.Count; i++)
                    {
                        if(i == state.Count - 1)
                        {
                            mensaje = mensaje + " y " + state[i];
                        }
                        else
                        {
                            mensaje = mensaje + state[i];
                        }

                    }
                    ControlMsg.Text = "Lo sentimos, no se han podido importar las siguientes tareas genéricas : " + mensaje;
                }

            }
            else
            {
                ControlMsg.Text = "Lo sentimos, la asignatura seleccionada no tiene ningún archivo XML para importar!";
            }

        }

        protected void AsignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asignatura"] = AsignaturasList.SelectedValue;
        }
    }
}