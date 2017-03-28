using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class FindTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //comment to commit
            //new comment
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

        protected void findTimes(object sender, EventArgs e)
        {
            Response.Redirect("AvailableTimes.aspx");
        }
    }
}