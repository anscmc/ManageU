using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class Lifts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createLiftButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLift.aspx");
        }
    }
}