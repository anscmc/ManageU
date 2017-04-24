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
    public partial class EditClass : System.Web.UI.Page
    {
        string mID;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                List<string> classInfo = new List<string>();
                classInfo = (List<string>)HttpContext.Current.Session["ClassesInfo"];
                int classToEdit = Int32.Parse(HttpContext.Current.Session["ClassToEdit"].ToString());
                string infoInString = classInfo.ElementAt(classToEdit - 1);
                string[] splitInfo = infoInString.Split('-');

                mID = splitInfo[0];
                if (! IsPostBack)
                {
                    populateClassInfo();
                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        public void populateClassInfo()
        {
            //get the info at the index of the row of the class the user chose to edit
            List<string> classInfo = new List<string>();
            classInfo = (List<string>)HttpContext.Current.Session["ClassesInfo"];
            int classToEdit = Int32.Parse(HttpContext.Current.Session["ClassToEdit"].ToString());
            string infoInString = classInfo.ElementAt(classToEdit - 1);
            string[] splitInfo = infoInString.Split('-');

            mID = splitInfo[0];
            string assocID = splitInfo[1];
            string eventName = splitInfo[2];
            className.Text = eventName;
            string eventT = splitInfo[3];
            string[] startSplit;
            string sDate;
            string[] sDateSplit;
            string sYear;
            string sMonth;
            string sDay;
            string sTime;
            string[] sTimeSplit;
            string sHour;
            string sMinute;
            string sampm;
            string[] endSplit;
            string eDate;
            string[] eDateSplit;
            string eYear;
            string eMonth;
            string eDay;
            string eTime;
            string[] eTimeSplit;
            string eHour;
            string eMinute;
            string eampm;

            //have to split up into date and time
            string eventStart = splitInfo[4];
            startSplit = eventStart.Split(' ');
            sDate = startSplit[0];
            sTime = startSplit[1];
            sTimeSplit = sTime.Split(':');
            sHour = sTimeSplit[0];
            sMinute = sTimeSplit[1];
            sampm = startSplit[2];
            //have to split up into date and time
            string eventEnd = splitInfo[5];
            endSplit = eventEnd.Split(' ');
            eDate = endSplit[0];
            eTime = endSplit[1];
            eTimeSplit = eTime.Split(':');
            eHour = eTimeSplit[0];
            eMinute = eTimeSplit[1];
            eampm = endSplit[2];
            
            sDateSplit = sDate.Split('/');
            sMonth = sDateSplit[0];
            sDay = sDateSplit[1];
            sYear = sDateSplit[2];

            if (sMonth.Length == 1)
            {
                sMonth = "0" + sMonth;
            }
            if (sDay.Length == 1)
            {
                sDay = "0" + sDay;
            }

            sDate = sYear + "-" + sMonth + "-" + sDay;
            startDate.Value = sDate;

            eDateSplit = eDate.Split('/');
            eMonth = eDateSplit[0];
            eDay = eDateSplit[1];
            eYear = eDateSplit[2];

            if (eMonth.Length == 1)
            {
                eMonth = "0" + eMonth;
            }
            if (eDay.Length == 1)
            {
                eDay = "0" + sDay;
            }

            eDate = eYear + "-" + eMonth + "-" + eDay;
            endDate.Value = eDate;

            startHour.Value = sHour;
            startMinute.Value = sMinute;
            amPMstart.Value = sampm;

            endHour.Value = eHour;
            endMinute.Value = eMinute;
            amPMend.Value = eampm;

            string daysClassHeld = splitInfo[6];

            if (daysClassHeld.Contains("Sun")) {
                sun.Checked = true;
            }
            if (daysClassHeld.Contains("M"))
            {
                mon.Checked = true;
            }
            if (daysClassHeld.Contains("Tue"))
            {
                tue.Checked = true;
            }
            if (daysClassHeld.Contains("W"))
            {
                wed.Checked = true;
            }
            if (daysClassHeld.Contains("Th"))
            {
                thu.Checked = true;
            }
            if (daysClassHeld.Contains("F"))
            {
                fri.Checked = true;
            }
            if (daysClassHeld.Contains("Sat"))
            {
                sat.Checked = true;
            }

        }

        protected void saveClass_Click(object sender, EventArgs e)
        {

            //delete all current instances
            deleteClass();
            //save all instances
            addClass();
        }

        protected void deleteClass()
        {
            int masterID = Int32.Parse(mID);

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Delete class from database if want to delete all instances

            strsql = "delete from EventMasterTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from EventDetailsTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCon.Close();

        }

        protected void addClass()
        {
            string strsql = "";
            string days = "";
            if (sun.Checked)
            {
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
            int startHr;
            int endHr;
            DateTime start;
            DateTime end;
            DateTime classDateEnd;

            if (amPMstart.Value == "PM" && Int32.Parse(startHour.Value) < 12)
            {
                startHr = Int32.Parse(startHour.Value) + 12;
            }
            else
            {
                startHr = Int32.Parse(startHour.Value);
            }
            if (amPMend.Value == "PM" && Int32.Parse(endHour.Value) < 12)
            {
                endHr = Int32.Parse(endHour.Value) + 12;
            }
            else
            {
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
            for (DateTime classDate = start; classDate <= end; classDate = classDate.AddDays(1.0))
            {
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

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerSchedule.aspx");
        }
    }
}