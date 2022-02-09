using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendEmail.Class1 mail = new SendEmail.Class1();
            RandomNumber.Class1 random = new RandomNumber.Class1();

            mail.sendMail(Email.Text, "prueba", random.generateRandom().ToString());
        }
    }
}