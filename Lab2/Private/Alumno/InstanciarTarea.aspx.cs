using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Lab2
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        BusinessLogic.Logic bl = new BusinessLogic.Logic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario.Text = Session["correo"].ToString();
            Tarea.Text = Request["codigo"].ToString();
            horasEst.Text = Request["horas"].ToString();

            string correo = Session["correo"] as string;
            gridTareas.DataSource=bl.verEstudianteTarea(correo);
            gridTareas.DataBind();
        }

        protected void instanciarTarea_Click(object sender, EventArgs e)
        {
            Entities.Instancia tarea =new Entities.Instancia(Session["correo"].ToString(), Tarea.Text, Int32.Parse(horasEst.Text), Int32.Parse(horasReales.Text));
            DataView tblTarea = bl.instanciarTarea(tarea).Dv;

            
            gridTareas.DataSource = tblTarea;
            gridTareas.DataBind();
            Tarea.Text = "";
            horasEst.Text = "";
            horasReales.Text = "";
        }
    }
}