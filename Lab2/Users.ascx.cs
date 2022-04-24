using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Users : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refrescar();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            refrescar();
        }

        private void refrescar()
        {
            List<string> students = (List<string>)Application["students"];
            List<string> teachers = (List<string>)Application["teachers"];
            if (students != null)
            {
                StudentsCount.Text = students.Count.ToString();
                StudentsList.DataSource = students;
                StudentsList.DataBind();
            }

            if (teachers != null)
            {
                TeachersCount.Text = teachers.Count.ToString();
                TeachersList.DataSource = teachers;
                TeachersList.DataBind();
            }
        }
    }
}