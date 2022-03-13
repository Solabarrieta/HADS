using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AddTarea_Click(object sender, EventArgs e)
        {
            BusinessLogic.Logic bl = new BusinessLogic.Logic();
            Entities.Tarea t = new Entities.Tarea(CodigoText.Text, DescripcionText.Text, AsignaturaDropDown.SelectedValue, Int32.Parse(HorasText.Text), true, TipoTareaDropDown.SelectedValue);
            if(bl.insertarTarea(t) == "Ok")
            {
                //Poner un mensaje de insertado correctamente
            }
            else
            {
                //Poner un mensaje de error
            }
        }
    }
}