using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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
                System.Web.UI.HtmlControls.HtmlGenericControl hide1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("meetings");

                hide1.Style.Add("display", "none");
                System.Web.UI.HtmlControls.HtmlGenericControl hide2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("invite");

                hide2.Style.Add("display", "none");
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                //editButton.Style.Add("display", "block");
                System.Web.UI.HtmlControls.HtmlGenericControl hide = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("mySched");
                hide.Style.Add("display", "none");
                System.Web.UI.HtmlControls.HtmlGenericControl hide3 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("att");

                hide3.Style.Add("display", "none");
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void findTimes(object sender, EventArgs e)
        {
            //start date to look through
            DateTime currDate = DateTime.Parse(date1.Value);
            if (DateTime.Now.Month == currDate.Month && DateTime.Now.Day == currDate.Day && DateTime.Now.Year == currDate.Year) {
                currDate = DateTime.Now;
            }
            //end date to look through
            DateTime toDate = DateTime.Parse(date2.Value);
            toDate = toDate.AddDays(1);

            //days between start and end dates
            int dayDifference = Int32.Parse(((toDate - currDate.Date).TotalDays).ToString());
            
            //15 min intervals needed for meeting
            int numOfIntervals = ((Int32.Parse(hours.Value) * 60) + Int32.Parse(minutes.Value))/15;

            int[,] gridArray = new int[dayDifference, 96];

            //Event info variables
            DateTime eventTime;
            TimeSpan timeSpan;
            int timeToTake;
            string militaryTime;
            string hour;
            string minute;
            int min;
            string decimalString;
            string quarterIndex = "";

            //search database for player and team events between currDate and toDate

            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            string strsql = "Select * from EventDetailsTable where (associatedID in (Select teamID from TeamTable where teamID = '" + HttpContext.Current.Session["TeamID"].ToString() + "') OR associatedID in (Select userID from PlayerTable where teamID = '" + HttpContext.Current.Session["TeamID"].ToString() + "')) AND ((eventStart >= '" + currDate + "' AND eventStart < '" + toDate.Date + "') OR (eventEnd >= '" + currDate + "' AND eventEnd < '" + toDate.Date + "')) order by eventStart";
            objCmd = new SqlCommand(strsql, objCon);
            objRS = objCmd.ExecuteReader();

            int dayCounter = 0;

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //look in the grid and place a 1 for the blocks
                    eventTime = Convert.ToDateTime(objRS["eventStart"]);
                    //If eventstart is on day before current date, make event start midnight of current day
                    if (eventTime.Date < currDate.Date)
                    {
                        eventTime = currDate.Date;
                    }
                    //make sure in minutes
                    timeSpan = Convert.ToDateTime(objRS["eventEnd"]).Subtract(eventTime);
                    timeToTake = (int)timeSpan.TotalMinutes;
                    //for each event, block the spot in the multidimensional array 
                    militaryTime = eventTime.ToString("HHmm");
                    hour = militaryTime.Substring(0, 2);
                    minute = militaryTime.Substring(2, 2);
                    min = Int32.Parse(minute);

                    //round minutes down to nearest 15th spot
                    if (min >= 0 && min < 15)
                    {
                        minute = "00";
                    }
                    else if (min >= 16 && min <= 29)
                    {
                        minute = "15";
                    }
                    else if (min >= 31 && min <= 44)
                    {
                        minute = "30";
                    }
                    else if (min >= 46 && min <= 59)
                    {
                        minute = "45";
                    }

                    //change military time to quarter decimals 
                    switch (minute)
                    {
                        case "00":
                            decimalString = ".00";
                            quarterIndex = hour + decimalString;
                            break;
                        case "15":
                            decimalString = ".25";
                            quarterIndex = hour + decimalString;
                            break;
                        case "30":
                            decimalString = ".50";
                            quarterIndex = hour + decimalString;
                            break;
                        case "45":
                            decimalString = ".75";
                            quarterIndex = hour + decimalString;
                            break;
                        default:
                            break;
                    }

                    double intervalDouble = double.Parse(quarterIndex);
                    int intervalIndex = (int)(4 * intervalDouble) + 1;
                    int interval;
                    int oldInterval = 0;
                    DateTime oldStartDate = currDate;
                    DateTime startOfEvent = Convert.ToDateTime(objRS["eventStart"]);

                    //to let the program know where to be on the "days" part of the grid
                    if (startOfEvent.Date > oldStartDate.Date)
                    {
                        dayCounter++;
                        oldStartDate = Convert.ToDateTime(objRS["eventStart"]);
                    }

                    //find number of 15 minute intervals to take up for event
                    if (timeToTake % 15 == 0)
                    {
                        timeToTake = timeToTake / 15;
                    }
                    else
                    {
                        timeToTake = (timeToTake / 15) + 1;
                    }

                    //place a 1 in eaach of the intervals the event takes up
                    for (int i = 0; i < timeToTake; i++)
                    {
                        //if the event spans into an unwanted day (11 pm - 1 am for example) do not try to block the extra blocks (blocks 12am-1am)
                        if (oldInterval == 95)
                        {

                        }
                        else
                        {
                            interval = intervalIndex + i;
                            gridArray[dayCounter, interval] = 1;
                            oldInterval = interval;
                        }

                    }
                }

            }


            objCmd = null;
            objRS.Close();
            objCon.Close();

            //search gridArray for open slots between the times given

            string searchStartHour = meetingStartHour.Value;
            string searchStartMin = meetingStartMinute.Value;
            string startAMPM = amPMstart.Value;

            if (startAMPM == "PM" && Int32.Parse(searchStartHour) < 12) {
                searchStartHour = (Int32.Parse(searchStartHour) + 12).ToString();
            }

            string searchEndHour = meetingEndHour.Value;
            string searchEndMin = meetingEndMinute.Value;
            string endAMPM = amPMend.Value;

            if (endAMPM == "PM" && Int32.Parse(searchEndHour) < 12)
            {
                searchEndHour = (Int32.Parse(searchEndHour) + 12).ToString();
            }

            string beginningTime = searchStartHour + ":" + searchStartMin + ":00";
            string endingTime = searchEndHour + ":" + searchEndMin + ":00";
            int blockCounter = 0;

            beginningTime = beginningTime.Replace(":", "");
            if (beginningTime.Length == 5)
            {
                beginningTime = beginningTime.Remove(3);
            }
            else
            {
                beginningTime = beginningTime.Remove(4);
            }
            endingTime = endingTime.Replace(":", "");
            if(endingTime.Length == 5)
            {
                endingTime = endingTime.Remove(3);
            }
            else
            {
                endingTime = endingTime.Remove(4);
            }

            string beginHour;
            string beginMinute;
            if (beginningTime.Length == 3)
            {
                beginHour = beginningTime.Substring(0, 1);
                beginMinute = beginningTime.Substring(1, 2);
            }
            else
            {
                beginHour = beginningTime.Substring(0, 2);
                beginMinute = beginningTime.Substring(2, 2);
            }


            string endHour; 
            string endMinute;
            if(endingTime.Length == 3)
            {
                endHour = endingTime.Substring(0, 1);
                endMinute = endingTime.Substring(1, 2);
            }
            else
            {
                endHour = endingTime.Substring(0, 2);
                endMinute = endingTime.Substring(2, 2);
            }
            
            int startMin = Int32.Parse(beginMinute);
            int endMin = Int32.Parse(endMinute);
            string startQuarterIndex = "";
            double startQuarterDouble;
            int startInterval = 0;
            string endQuarterIndex = "";
            double endQuarterDouble;
            int endInterval = 0;
            List<string> meetingOptions = new List<string>();
            List<string> availableTimes = new List<string>();

            //round starting time minutes down to nearest 15th spot
            if (startMin >= 0 && startMin < 15)
            {
                beginMinute = "00";
            }
            else if (startMin >= 16 && startMin <= 29)
            {
                beginMinute = "15";
            }
            else if (startMin >= 31 && startMin <= 44)
            {
                beginMinute = "30";
            }
            else if (startMin >= 46 && startMin <= 59)
            {
                beginMinute = "45";
            }

            //round ending time minutes down to nearest 15th spot

            if (endMin >= 0 && endMin < 15)
            {
                endMinute = "00";
            }
            else if (endMin >= 16 && endMin <= 29)
            {
                endMinute = "15";
            }
            else if (endMin >= 31 && endMin <= 44)
            {
                endMinute = "30";
            }
            else if (endMin >= 46 && endMin <= 59)
            {
                endMinute = "45";
            }

            //change start military time to quarter decimals 
            switch (beginMinute)
            {
                case "00":
                    decimalString = ".00";
                    startQuarterIndex = beginHour + decimalString;
                    break;
                case "15":
                    decimalString = ".25";
                    startQuarterIndex = beginHour + decimalString;
                    break;
                case "30":
                    decimalString = ".50";
                    startQuarterIndex = beginHour + decimalString;
                    break;
                case "45":
                    decimalString = ".75";
                    startQuarterIndex = beginHour + decimalString;
                    break;
                default:
                    break;
            }

            //change end military time to quarter decimals
            switch (endMinute)
            {
                case "00":
                    decimalString = ".00";
                    endQuarterIndex = endHour + decimalString;
                    break;
                case "15":
                    decimalString = ".25";
                    endQuarterIndex = endHour + decimalString;
                    break;
                case "30":
                    decimalString = ".50";
                    endQuarterIndex = endHour + decimalString;
                    break;
                case "45":
                    decimalString = ".75";
                    endQuarterIndex = endHour + decimalString;
                    break;
                default:
                    break;
            }

            startQuarterDouble = double.Parse(startQuarterIndex);
            endQuarterDouble = double.Parse(endQuarterIndex);

            startInterval = (int)((4 * startQuarterDouble) + 1);
            endInterval = (int)((4 * endQuarterDouble) + 1);

            int indexHolder = startInterval - 1;

            for (int j = 0; j < gridArray.GetLength(0); j++)
            {
                for (int k = startInterval; k < endInterval; k++)
                {
                    if(blockCounter == 0)
                    {
                        indexHolder++;
                        k = indexHolder;
                    }
                    //if a block is taken up, reset the block counter
                    if (gridArray[j, k] == 1)
                    {
                        blockCounter = 0;
                    }
                    else
                    {
                        blockCounter++;
                        //if the number of open intervals necessary for meeting are found
                        if (blockCounter == numOfIntervals)
                        {
                            //add the day and time to meeting options
                            //"day,startTime;day,endTime"
                            meetingOptions.Add(j.ToString() + "," + (indexHolder).ToString() + ";" + j.ToString() + "," + (k + 1).ToString());
                            //reset the counter
                            blockCounter = 0;
                        }
                    }
                }
            }

            //loop through available times and display them

            string option = "";
            string[] split = new string[2];
            string startDate = "";
            string startDay = "";
            string startTime = "";
            string endDate = "";
            string endDay = "";
            string timeEnd = "";
            string hrTime = "";
            string minTime = "";
            DateTime thisDate;
            double decimalTime = 0.0;
            string decString = "";
            string ampm = "AM";
            List<string> timeOptions = new List<string>();

            for (int m = 0; m < meetingOptions.Count; m++)
            {
                option = meetingOptions[m];
                split = option.Split(';');
                startDate = split[0];
                endDate = split[1];
                split = startDate.Split(',');
                startDay = split[0];
                startTime = split[1];
                split = endDate.Split(',');
                endDay = split[0];
                timeEnd = split[1];

                //find actual date of startDay

                thisDate = currDate.AddDays(Int32.Parse(startDay));
                split = thisDate.ToString().Split(' ');
                startDay = split[0];

                //find actual date of endDay

                thisDate = currDate.AddDays(Int32.Parse(endDay));
                split = thisDate.ToString().Split(' ');
                endDay = split[0];

                //convert startDate to dateTime
                decimalTime = (Convert.ToDouble(startTime) - 1) / 4;
                decString = String.Format("{0:0.00}", decimalTime);
                if(decString.Length == 4)
                {
                    hrTime = decString.Substring(0, 1);
                }
                else
                {
                    hrTime = decString.Substring(0, 2);
                }
                if(decString.Length == 4)
                {
                    minTime = decString.Substring(1, 3);
                }
                else
                {
                    minTime = decString.Substring(2, 3);
                }

                if (minTime == ".0")
                {
                    minTime = ".00";
                }
                if (minTime == ".5")
                {
                    minTime = ".50";
                }

                //convert quarter decimal to 15 min intervals
                switch (minTime)
                {
                    case ".00":
                        minTime = "00";
                        break;
                    case ".25":
                        minTime = "15";
                        break;
                    case ".50":
                        minTime = "30";
                        break;
                    case ".75":
                        minTime = "45";
                        break;
                    default:
                        break;
                }

                if (Int32.Parse(hrTime) > 12)
                {
                    hrTime = (Int32.Parse(hrTime) - 12).ToString();
                    ampm = "PM";
                }
                if (Int32.Parse(hrTime) == 12)
                {
                    ampm = "PM";
                }

                startDate = startDay + "," + hrTime + ":" + minTime + " " + ampm;

                ampm = "AM";

                //convert endDate to dateTime
                decimalTime = (Convert.ToDouble(timeEnd) - 1) / 4;
                decString = String.Format("{0:0.00}", decimalTime);
                if (decString.Length == 4)
                {
                    hrTime = decString.Substring(0, 1);
                }
                else
                {
                    hrTime = decString.Substring(0, 2);
                }
                if (decString.Length == 4)
                {
                    minTime = decString.Substring(1, 3);
                }
                else
                {
                    minTime = decString.Substring(2, 3);
                }

                if (minTime == ".0")
                {
                    minTime = ".00";
                }
                if(minTime == ".5")
                {
                    minTime = ".50";
                }

                //convert quarter decimal to 15 min intervals
                switch (minTime)
                {
                    case ".00":
                        minTime = "00";
                        break;
                    case ".25":
                        minTime = "15";
                        break;
                    case ".50":
                        minTime = "30";
                        break;
                    case ".75":
                        minTime = "45";
                        break;
                    default:
                        break;
                }

                if (Int32.Parse(hrTime) > 12)
                {
                    hrTime = (Int32.Parse(hrTime) - 12).ToString();
                    ampm = "PM";
                }
                if (Int32.Parse(hrTime) == 12)
                {
                    ampm = "PM";
                }

                endDate = endDay + "," + hrTime + ":" + minTime + " " + ampm;

                

                timeOptions.Add(startDate + ";" + endDate);

             
            }

            HttpContext.Current.Session["AvailableTimes"] = timeOptions;

            Response.Redirect("AvailableTimes.aspx");
        }
    }
}