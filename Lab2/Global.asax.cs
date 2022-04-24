using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab2
{
    public class Global : System.Web.HttpApplication
    {

            List<string> teachers = new List<string>();
            List<string> students = new List<string>();
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application.Contents["teachers"] = teachers;
            Application["students"] = students;
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application.Contents.RemoveAll();
            Application.UnLock();
        }
    }
}