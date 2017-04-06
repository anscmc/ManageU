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
            string meetingInfo;
            string[] meetingSplit;
            string date;
            string dateToEnter;
            string[] dateSplit;
            string month;
            string day;
            string year;
            string start;
            string[] startSplit;
            string startTime;
            string startAmPm;
            string[] startTimeSplit;
            string startHr;
            string startMin;
            string end;
            string[] endSplit;
            string endTime;
            string endAmPm;
            string[] endTimeSplit;
            string endHr;
            string endMin;


            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                //if coming from available meeting times page fill in the fields
                if(HttpContext.Current.Session["FromFindTimes"].ToString() == "Y")
                {
                    meetingInfo = HttpContext.Current.Session["ChosenMeeting"].ToString();
                    meetingSplit = meetingInfo.Split(';');

                    date = meetingSplit[0];
                    dateSplit = date.Split('/');
                    month = dateSplit[0];
                    day = dateSplit[1];
                    year = dateSplit[2];

                    if(month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    if(day.Length == 1)
                    {
                        day = "0" + day;
                    }

                    dateToEnter = year + "-" + month + "-" + day;
                    eventStartDate.Value = dateToEnter;
                    eventEndDate.Value = dateToEnter;

                    start = meetingSplit[1];
                    end = meetingSplit[2];

                    startSplit = start.Split(' ');
                    startTime = startSplit[0];
                    startAmPm = startSplit[1];
                    startTimeSplit = startTime.Split(':');
                    startHr = startTimeSplit[0];
                    startMin = startTimeSplit[1];

                    endSplit = end.Split(' ');
                    endTime = endSplit[0];
                    endAmPm = endSplit[1];
                    endTimeSplit = endTime.Split(':');
                    endHr = endTimeSplit[0];
                    endMin = endTimeSplit[1];

                    eventType.Value = "Meeting";

                    eventStartHour.Value = startHr;
                    eventStartMinute.Value = startMin;
                    beginAmPM.Value = startAmPm;

                    eventEndHour.Value = endHr;
                    eventEndMinute.Value = endMin;
                    endingAmPm.Value = endAmPm;


                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        public void createEventButton_Click(object sender, EventArgs e) {

        }

    }
}