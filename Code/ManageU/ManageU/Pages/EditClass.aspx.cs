using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class EditClass : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                populateClassInfo();
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        public void populateClassInfo()
        {
            //get the info at the index of the row of the class the user chose to edit
            List<string> classInfo = new List<string>();
            classInfo = (List<string>)HttpContext.Current.Session["ClassesInfo"];
            int classToEdit = Int32.Parse(HttpContext.Current.Session["ClassToEdit"].ToString());
            string infoInString = classInfo.ElementAt(classToEdit - 1);
            string[] splitInfo = infoInString.Split('-');

            string mID = splitInfo[0];
            string assocID = splitInfo[1];
            string eventName = splitInfo[2];
            string eventT = splitInfo[3];

            //have to split up into date and time
            string eventStart = splitInfo[4];

            //have to split up into date and time
            string eventEnd = splitInfo[5];

            string daysClassHeld = splitInfo[6];

            className.Text = eventName;

            if (daysClassHeld.Contains("Sun")) {
                sun.Checked = true;
            }
            if (daysClassHeld.Contains("M"))
            {
                mon.Checked = true;
            }
            if (daysClassHeld.Contains("Tue"))
            {
                tue.Checked = true;
            }
            if (daysClassHeld.Contains("W"))
            {
                wed.Checked = true;
            }
            if (daysClassHeld.Contains("Th"))
            {
                thu.Checked = true;
            }
            if (daysClassHeld.Contains("F"))
            {
                fri.Checked = true;
            }
            if (daysClassHeld.Contains("Sat"))
            {
                sat.Checked = true;
            }

        }

        protected void saveClass_Click(object sender, EventArgs e)
        {

        }
    }
}