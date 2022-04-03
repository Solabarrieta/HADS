using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Private.Admin
{
    public partial class EliminarCuenta : System.Web.UI.Page
    {
        BusinessLogic.Logic bl = new BusinessLogic.Logic();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = bl.getUsuarios("admin@ehu.es");
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string email = row.Cells[1].Text;
            Response.Redirect("ConfirmarEliminar.aspx?email=" + email);
        }
    }
}