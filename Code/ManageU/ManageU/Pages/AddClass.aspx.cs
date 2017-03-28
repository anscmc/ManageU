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
    public partial class AddClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void addButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("PlayerSchedule.aspx");
        }

        protected void addClass_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string days = "";
            if (sun.Checked) {
                days = days + "Sunday";
            }
            if (mon.Checked)
            {
                days = days + "Monday";
            }
            if (tue.Checked)
            {
                days = days + "Tuesday";
            }
            if (wed.Checked)
            {
                days = days + "Wednesday";
            }
            if (thu.Checked)
            {
                days = days + "Thursday";
            }
            if (fri.Checked)
            {
                days = days + "Friday";
            }
            if (sat.Checked)
            {
                days = days + "Saturday";
            }
            string name = className.Text;
            //has to be in the format '20170305 02:01:10 PM'
            //will have to change the next two lines when know what pickers have so can convert to correct format
            int startHr;
            int endHr;
            DateTime start;
            DateTime end;
            DateTime classDateEnd;

            if (amPMstart.Value == "PM" && Int32.Parse(startHour.Value) > 12)
            {
                startHr = Int32.Parse(startHour.Value) + 12;
            }
            else {
                startHr = Int32.Parse(startHour.Value);
            }
            if (amPMend.Value == "PM")
            {
                endHr = Int32.Parse(endHour.Value) + 12;
            }
            else {
                endHr = Int32.Parse(endHour.Value);
            }

            //date the class starts
            string startDateTime = startDate.Value + " " + startHr.ToString() + ":" + startMinute.Value + ":00"; 
            //date the class ends
            string endDateTime = endDate.Value + " " + endHr.ToString() + ":" + endMinute.Value + ":00";

            start = DateTime.Parse(startDateTime);
            end = DateTime.Parse(endDateTime);

            //store class in database
            int masterIDFromTable;
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            //store event in EventMaster
            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            strsql = "insert into EventMasterTable (associatedID, eventName, eventType, eventStart, eventEnd, reoccur) OUTPUT inserted.masterID values (@player, @eName, @eType, @eStart, @eEnd, @ereoccur);";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.Parameters.AddWithValue("player", HttpContext.Current.Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("eName", name);
            objCmd.Parameters.AddWithValue("eType", "class");
            //will never have a class start on one day and end on another
            objCmd.Parameters.AddWithValue("eStart", start);
            objCmd.Parameters.AddWithValue("eEnd", end);
            objCmd.Parameters.AddWithValue("eAtt", "N");
            objCmd.Parameters.AddWithValue("ereoccur", days);

            masterIDFromTable = (int)objCmd.ExecuteScalar();

            objCmd = null;
            int i = 0;
            //store all repeating events in EventDetails
            for (DateTime classDate = start; classDate <= end; classDate = classDate.AddDays(1.0)) {
                //if the day of the week is a day the class is on, add to table
                classDateEnd = new DateTime(classDate.Year, classDate.Month, classDate.Day, end.Hour, end.Minute, end.Second);
                i++;
                if (days.Contains(classDate.DayOfWeek.ToString()))
                {
                    
                    objCmd = new SqlCommand();
                    objCmd.Connection = objCon;

                    strsql = "insert into EventDetailsTable (masterID, associatedID, eventStart, eventEnd) OUTPUT inserted.eventID values (@master, @player, @eStart, @eEnd);";
                    objCmd = new SqlCommand(strsql, objCon);

                    objCmd.Parameters.AddWithValue("master", masterIDFromTable);
                    objCmd.Parameters.AddWithValue("player", HttpContext.Current.Session["UserID"].ToString());
                    //will never have a class start on one day and end on another
                    objCmd.Parameters.AddWithValue("eStart", classDate);
                    objCmd.Parameters.AddWithValue("eEnd", classDateEnd);

                    objCmd.ExecuteNonQuery();
                }
            }

            objCon.Close();

            Response.Redirect("PlayerSchedule.aspx");
        }
    }
}