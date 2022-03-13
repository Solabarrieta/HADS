using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection conClsf = new SqlConnection("Server = tcp:hads2205b.database.windows.net,1433; Initial Catalog=HADS22-05B; Persist Security Info = False; User ID = oier; Password =CrClONHEs25; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        SqlDataAdapter dapTar;
        SqlDataAdapter dapAsig;
        DataSet dstAsig = new DataSet();
        DataSet dstAlum = new DataSet();
        DataTable tblAlum;
        DataTable tblAsig;
        DataRow rowAlum;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLogic.Logic bl = new BusinessLogic.Logic();
            string correo = Session["correo"] as string;

            if (Page.IsPostBack)
            {
                Session["asignatura"] = DropDownList1.SelectedValue;
                string asig = Session["asignatura"] as string;
                gridAlum.DataSource = bl.verTareasAlumno(asig, correo);
                gridAlum.DataBind();
            }
            else
            {
                DropDownList1.DataSource = bl.verAsignaturas(correo);
                DropDownList1.DataTextField = "codigoAsig";
                DropDownList1.DataBind();
                Session["asignatura"] = DropDownList1.SelectedValue;
                string asig = Session["asignatura"] as string;

                gridAlum.DataSource = bl.verTareasAlumno(asig, correo);
                gridAlum.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asignatura"] = DropDownList1.SelectedValue;
        }

        protected void gridAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridAlum.SelectedRow;
            string codigo = row.Cells[1].Text;
            string horas = row.Cells[3].Text;
            Response.Redirect("InstanciarTarea.aspx?codigo="+codigo+"&horas="+horas);
        }
    }
}