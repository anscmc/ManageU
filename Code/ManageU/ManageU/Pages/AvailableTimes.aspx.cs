using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class AvailableTimes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                List<string> times = new List<string>();
                times = (List<string>)HttpContext.Current.Session["AvailableTimes"];
                string[] startEnd;
                string start;
                string end;
                string[] startSplit;
                string startDate;
                string startTime;
                string[] endSplit;
                string endDate;
                string endTime;
                for (int i = 0; i < times.Count; i++) {
                    //loop through to display options
                    startEnd = times.ElementAt(i).Split(';');
                    start = startEnd.ElementAt(0);
                    end = startEnd.ElementAt(1);

                    startSplit = start.Split(' ');
                    startDate = startSplit.ElementAt(0);
                    startTime = startSplit.ElementAt(1);
                    endSplit = end.Split(' ');
                    endDate = endSplit.ElementAt(0);
                    endTime = endSplit.ElementAt(1);
                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void customButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateMeeting.aspx");
        }
}
}