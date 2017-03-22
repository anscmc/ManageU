using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class CreateMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["startHour"] = "";
            HttpContext.Current.Session["startMinute"] = "";
            HttpContext.Current.Session["amOrPM"] = "";

            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {
                
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void createMeeting(object sender, EventArgs e)
        {

        }

        protected void findTime(object sender, EventArgs e)
        {
            Response.Redirect("FindTime.aspx");
        }
    }
}