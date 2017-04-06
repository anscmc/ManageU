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
        Label startDateLabel;
        Label startTimeLabel;
        Label endTimeLabel;
        List<Label> startDateList = new List<Label>();
        List<Label> startTimeList = new List<Label>();
        List<Label> endTimeList = new List<Label>();

        protected void Page_Init(object sender, EventArgs e)
        {
            loadAvailableTimes();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }
        

        protected void loadAvailableTimes() {
            int idInt = 0;
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
            for (int i = 0; i < times.Count; i++)
            {
                //loop through to display options

                idCount = idCount + 1;
                startEnd = times.ElementAt(i).Split(';');
                start = startEnd.ElementAt(0);
                end = startEnd.ElementAt(1);

                startSplit = start.Split(',');
                startDate = startSplit.ElementAt(0);
                startTime = startSplit.ElementAt(1);
                endSplit = end.Split(',');
                endDate = endSplit.ElementAt(0);
                endTime = endSplit.ElementAt(1);

                HtmlGenericControl availableTime =
                new HtmlGenericControl("div");
                availableTime.Attributes["id"] = "availableTime" + idCount.ToString();
                availableTime.Attributes["runat"] = "server";
                availableTime.Attributes["class"] = "availableTimeDiv";
                availableTime.Attributes.Add("onclick", "javascript:divClick(" + idCount.ToString() + "); return true;");

                startDateLabel = new Label();
                startDateLabel.Text = startDate;
                startDateLabel.Attributes["id"] = "startDateLabel" + idCount.ToString();
                startDateLabel.Attributes["runat"] = "server";
                startDateList.Add(startDateLabel);
                startTimeLabel = new Label();
                startTimeLabel.Attributes["id"] = "startTimeLabel" + idCount.ToString();
                startTimeLabel.Attributes["runat"] = "server";
                startTimeLabel.Text = startTime;
                startTimeList.Add(startTimeLabel);
                endTimeLabel = new Label();
                endTimeLabel.Attributes["id"] = "endTimeLabel" + idCount.ToString();
                endTimeLabel.Attributes["runat"] = "server";
                endTimeLabel.Text = endTime;
                endTimeList.Add(endTimeLabel);

                availableTime.Controls.Add(startDateLabel);
                availableTime.Controls.Add(new Literal() { Text = "<br/>" });
                availableTime.Controls.Add(startTimeLabel);
                availableTime.Controls.Add(new Literal() { Text = "<br/>" });
                availableTime.Controls.Add(endTimeLabel);

                displayTimesDiv.Controls.Add(availableTime);

            }
        }

        protected void divButton_Click(object sender, EventArgs e)
        {
            string row = hidden.Value;
            string date = "startDateLabel" + row;
            string start = "startTimeLabel" + row;
            string end = "endTimeLabel" + row;
            string divID = "availableTime" + row;
            int startcount = startDateList.Count();
            int startTimecount = startTimeList.Count();
            int endTimeCount = endTimeList.Count();
            //HtmlGenericControl div = this.Master.FindControl("MainContent").FindControl("displayTimesDiv") as HtmlGenericControl;
            //Label test = this.Master.FindControl("MainContent").FindControl("displayTimesDiv").FindControl("myLabel") as Label;
            //HtmlControl div2 = this.Master.FindControl("MainContent").FindControl("displayTimesDiv").FindControl("availableTime1") as HtmlControl;
            //Label dateLabel = this.Master.FindControl("MainContent").FindControl("displayTimesDiv").FindControl(divID).FindControl(date) as Label;
            //Label startLabel = (Label)displayTimesDiv.FindControl(start);
            //Label endLabel = (Label)displayTimesDiv.FindControl(end);
            string dateText = startDateList.ElementAt(Int32.Parse(row) - 1).Text;
            string startText = startTimeList.ElementAt(Int32.Parse(row) - 1).Text;
            string endText = endTimeList.ElementAt(Int32.Parse(row) - 1).Text;
            HttpContext.Current.Session["ChosenMeeting"] = dateText + ";" + startText + ";" + endText;
            HttpContext.Current.Session["FromFindTimes"] = "Y";
            Response.Redirect("CreateMeeting.aspx");
        }

        protected void customButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateEvent.aspx");
        }

    }
}