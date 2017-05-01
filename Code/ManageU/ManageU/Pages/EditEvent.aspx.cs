using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class EditEvent : System.Web.UI.Page
    {
        List<string> eventsInfo = new List<string>();
        string mID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                eventsInfo = (List<string>)HttpContext.Current.Session["TeamEventInfo"];
                int eventToView = Int32.Parse(HttpContext.Current.Session["TeamEventRowToView"].ToString());
                string[] infoSplit = eventsInfo.ElementAt(eventToView).Split(';');
                mID = infoSplit[0];
                if (!IsPostBack)
                {
                    
                    mID = infoSplit[0];
                    string[] startSplit = infoSplit[3].Split(' ');
                    string[] sDate = startSplit[0].Split('/');
                    if (sDate[0].Length == 1)
                    {
                        sDate[0] = "0" + sDate[0];
                    }
                    if (sDate[1].Length == 1)
                    {
                        sDate[1] = "0" + sDate[1];
                    }
                    string startD = sDate[2] + "-" + sDate[0] + "-" + sDate[1];
                    string[] endSplit = infoSplit[4].Split(' ');
                    string[] eDate = endSplit[0].Split('/');
                    if (eDate[0].Length == 1)
                    {
                        eDate[0] = "0" + eDate[0];
                    }
                    if (eDate[1].Length == 1)
                    {
                        eDate[1] = "0" + eDate[1];
                    }
                    string endD = eDate[2] + "-" + eDate[0] + "-" + eDate[1];
                    eventStartDate.Value = startD;
                    eventEndDate.Value = endD;
                    string[] sTimeSplit = startSplit[1].Split(' ');
                    string sTimeS = sTimeSplit[0];
                    string[] sTimeSSplit = sTimeS.Split(':');
                    string sTimeAmPm = startSplit[2];
                    string hrS = sTimeSSplit[0];
                    string minS = sTimeSSplit[1];
                    string amPmS = startSplit[2];
                    string[] eTimeSplit = endSplit[1].Split(' ');
                    string eTimeE = eTimeSplit[0];
                    string[] eTimeSSplit = eTimeE.Split(':');
                    string hrE = eTimeSSplit[0];
                    string minE = eTimeSSplit[1];
                    string amPmE = endSplit[2];

                    eventStartHour.Value = hrS;
                    eventStartMinute.Value = minS;
                    beginAmPM.Value = amPmS;

                    eventEndHour.Value = hrE;
                    eventEndMinute.Value = minE;
                    endingAmPm.Value = amPmE;

                    mID = infoSplit[0];
                    eventName.Text = infoSplit[1];
                    eventType.Value = infoSplit[2];
                    eventStartDate.Value = startD;
                    eventEndDate.Value = endD;
                    repeatPicker.Value = infoSplit[7];
                    if (infoSplit[8] == "Y")
                    {
                        required.Checked = true;
                    }
                    eventDes.Text = infoSplit[9];
                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewEvent.aspx");
        }

        protected void editEventButton_Click(object sender, EventArgs e)
        {
            deleteEvent();
            createEvent();
            Response.Redirect("TestCal.aspx");
        }

        protected void deleteEvent()
        {
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Delete class from database if want to delete all instances

            strsql = "delete from EventMasterTable where masterID='" + mID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from EventDetailsTable where masterID='" + mID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCon.Close();
        }

        public void createEvent()
        {
            string strsql = "";
            string name = eventName.Text;
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

            if (beginAmPM.Value == "AM" && Int32.Parse(eventStartHour.Value) == 12)
            {
                startHr = Int32.Parse(eventStartHour.Value) - 12;
            }
            else if (beginAmPM.Value == "PM" && Int32.Parse(eventStartHour.Value) < 12)
            {
                startHr = Int32.Parse(eventStartHour.Value) + 12;
            }
            else
            {
                startHr = Int32.Parse(eventStartHour.Value);
            }


            if (endingAmPm.Value == "AM" && Int32.Parse(eventEndHour.Value) == 12)
            {
                endHr = Int32.Parse(eventEndHour.Value) - 12;
            }
            if (endingAmPm.Value == "PM" && Int32.Parse(eventEndHour.Value) < 12)
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
            until = end;
            if (repeatPicker.Value != "Never")
            {
                until = DateTime.Parse(repeatUntilDate.Value);
            }

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



                    strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @team, @eStart, @eEnd);";
                    objCmd = new SqlCommand(strsql, objCon);

                    objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                    objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
                    objCmd.Parameters.AddWithValue("eStart", eventDate);
                    objCmd.Parameters.AddWithValue("eEnd", end);

                    objCmd.ExecuteNonQuery();
                    end = end.AddDays(7.0);
                }
            }
            else if (repeatPicker.Value == "Daily")
            {
                for (DateTime eventDate = start; eventDate <= until; eventDate = eventDate.AddDays(1.0))
                {
                    objCmd = new SqlCommand();
                    objCmd.Connection = objCon;



                    strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @team, @eStart, @eEnd);";
                    objCmd = new SqlCommand(strsql, objCon);

                    objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                    objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
                    objCmd.Parameters.AddWithValue("eStart", eventDate);
                    objCmd.Parameters.AddWithValue("eEnd", end);

                    objCmd.ExecuteNonQuery();
                    end = end.AddDays(1.0);
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
                    mail.Subject = "ManageU Team Event Updated";
                    if (attendanceReq == "Y")
                    {
                        mail.Body = "A " + eventType.Value + " has been edited. Your coach is requiring attendance for this event.";
                    }
                    else
                    {
                        mail.Body = "A " + eventType.Value + " has been edited.";
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