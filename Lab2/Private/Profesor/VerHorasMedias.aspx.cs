using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2.Private.Profesor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            net.azurewebsites.apihads05.WebService1 media = new net.azurewebsites.apihads05.WebService1();
            Horas.Text = Convert.ToString(media.mediaHoras(DropDownList1.SelectedValue));
        }
    }
}