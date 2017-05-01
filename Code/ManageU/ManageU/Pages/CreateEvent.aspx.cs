using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;

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
                if (HttpContext.Current.Session["FromFindTimes"] == null) {

                }
                else if (HttpContext.Current.Session["FromFindTimes"].ToString() == "Y")
                {
                    meetingInfo = HttpContext.Current.Session["ChosenMeeting"].ToString();
                    meetingSplit = meetingInfo.Split(';');

                    date = meetingSplit[0];
                    dateSplit = date.Split('/');
                    month = dateSplit[0];
                    day = dateSplit[1];
                    year = dateSplit[2];

                    if (month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    if (day.Length == 1)
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
            string strsql = "";
            string name = EventName.Text;
            string type = eventType.Value;
            //has to be in the format '20170305 02:01:10 PM'
            //will have to change the next two lines when know what pickers have so can convert to correct format
            string startDateTime;
            string endDateTime;
            int startHr;
            int endHr;
            string notes = eventDes.Text;
            string attendanceReq;
            string email = "";
            DateTime start;
            DateTime end;
            DateTime until;
            int masterIDFromTable;

            if (required.Checked)
            {
                attendanceReq = "Y";
            }
            else
            {
                attendanceReq = "N";
            }

            if (beginAmPM.Value == "PM" && Int32.Parse(eventStartHour.Value) > 12)
            {
                startHr = Int32.Parse(eventStartHour.Value) + 12;
            }
            else
            {
                startHr = Int32.Parse(eventStartHour.Value);
            }
            if (endingAmPm.Value == "PM" && Int32.Parse(eventStartHour.Value) > 12)
            {
                endHr = Int32.Parse(eventEndHour.Value) + 12;
            }
            else
            {
                endHr = Int32.Parse(eventEndHour.Value);
            }

            //date the event starts
            startDateTime = eventStartDate.Value + " " + startHr.ToString() + ":" + eventStartMinute.Value + ":00";
            //date the event ends
            endDateTime = eventEndDate.Value + " " + endHr.ToString() + ":" + eventEndMinute.Value + ":00";

            start = DateTime.Parse(startDateTime);
            end = DateTime.Parse(endDateTime);
            until = DateTime.Parse(repeatUntilDate.Value);

            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Store event in EventMasterTable
            strsql = "insert into EventMasterTable (associatedID, eventName, eventType, eventStart, eventEnd, eventNotes, attReq, reoccur) OUTPUT inserted.masterID values (@team, @eName, @eType, @eStart, @eEnd, @eNotes, @eAttReq, @ereoccur);";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
            objCmd.Parameters.AddWithValue("eName", name);
            objCmd.Parameters.AddWithValue("eType", type);
            objCmd.Parameters.AddWithValue("eStart", startDateTime);
            objCmd.Parameters.AddWithValue("eEnd", endDateTime);
            objCmd.Parameters.AddWithValue("eNotes", notes);
            objCmd.Parameters.AddWithValue("eAttReq", attendanceReq);
            objCmd.Parameters.AddWithValue("ereoccur", repeatPicker.Value);

            masterIDFromTable = (int)objCmd.ExecuteScalar();

            objCmd = null;

            //store event in EventDetailsTable

            if (repeatPicker.Value == "Weekly")
            {
                for (DateTime eventDate = start; eventDate <= until; eventDate = eventDate.AddDays(7.0))
                {
                    objCmd = new SqlCommand();
                    objCmd.Connection = objCon;

                    end = end.AddDays(7.0);

                    strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @team, @eStart, @eEnd);";
                    objCmd = new SqlCommand(strsql, objCon);

                    objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                    objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
                    objCmd.Parameters.AddWithValue("eStart", eventDate);
                    objCmd.Parameters.AddWithValue("eEnd", end);

                    objCmd.ExecuteNonQuery();
                }
            }
            else if(repeatPicker.Value == "Daily")
            {
                for (DateTime eventDate = start; eventDate <= until; eventDate = eventDate.AddDays(1.0))
                {
                    objCmd = new SqlCommand();
                    objCmd.Connection = objCon;

                    end = end.AddDays(1.0);

                    strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @team, @eStart, @eEnd);";
                    objCmd = new SqlCommand(strsql, objCon);

                    objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                    objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
                    objCmd.Parameters.AddWithValue("eStart", eventDate);
                    objCmd.Parameters.AddWithValue("eEnd", end);

                    objCmd.ExecuteNonQuery();
                }
            }
            else
            {
                //just add one entry to EventDetailsTable
                objCmd = new SqlCommand();
                objCmd.Connection = objCon;

                strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @team, @eStart, @eEnd);";
                objCmd = new SqlCommand(strsql, objCon);

                objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
                objCmd.Parameters.AddWithValue("eStart", start);
                objCmd.Parameters.AddWithValue("eEnd", end);

                objCmd.ExecuteNonQuery();
            }

            objCmd = null;

            //Send email to players
            strsql = "Select * from PlayerTable where teamID = '" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            objCmd = new SqlCommand(strsql, objCon);
            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //send email to each player
                    email = objRS["playerEmail"].ToString();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("manageuapp@gmail.com");
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("manageuapp@gmail.com", "Seniordes2017");
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    mail.Subject = "ManageU Team Event Added";
                    if (attendanceReq == "Y")
                    {
                        mail.Body = "A " + eventType.Value + " has been added to your team calendar. Your coach is requiring attendance for this event.";
                    }
                    else
                    {
                        mail.Body = "A " + eventType.Value + " has been added to your team calendar";
                    }

                    mail.IsBodyHtml = true;
                    client.Send(mail);
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();

            Response.Redirect("TestCal.aspx");
        }

    }
}