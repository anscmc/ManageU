using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class AvailableTimes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idInt = 0;
            

            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                idInt = idInt + 1;

                String id = idInt.ToString();

                Button divButton = new Button();
                divButton.Attributes["style"] = "display:none;";
                divButton.ID = "divBtn_" + id;
                divButton.Text = id;
                divButton.Click += divButton_Click;

                int idCount = 0;
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

                    idCount = idCount + 1;
                    startEnd = times.ElementAt(i).Split(';');
                    start = startEnd.ElementAt(0);
                    end = startEnd.ElementAt(1);

                    startSplit = start.Split(' ');
                    startDate = startSplit.ElementAt(0);
                    startTime = startSplit.ElementAt(1);
                    endSplit = end.Split(' ');
                    endDate = endSplit.ElementAt(0);
                    endTime = endSplit.ElementAt(1);

                    HtmlGenericControl availableTime =
                    new HtmlGenericControl("div");
                    availableTime.Attributes["id"] = "availableTime" + idCount.ToString();
                    availableTime.Attributes["runat"] = "server";
                    availableTime.Attributes["class"] = "availableTimeDiv";
                    availableTime.Attributes.Add("onclick", "javascript:divClick(); return true;");

                    Label startDateLabel = new Label();
                    startDateLabel.Text = startDate;
                    Label startTimeLabel = new Label();
                    startTimeLabel.Text = startTime;
                    Label endTimeLabel = new Label();
                    endTimeLabel.Text = endTime;


                    availableTime.Controls.Add(startDateLabel);
                    availableTime.Controls.Add(new Literal() { Text = "<br/>" });
                    availableTime.Controls.Add(startTimeLabel);
                    availableTime.Controls.Add(new Literal() { Text = "<br/>" });
                    availableTime.Controls.Add(endTimeLabel);

                    displayTimesDiv.Controls.Add(availableTime);




                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void divButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMeeting.aspx");
        }

        protected void customButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateMeeting.aspx");
        }

    }
}