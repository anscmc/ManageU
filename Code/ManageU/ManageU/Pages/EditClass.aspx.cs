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
                populateClassInfo();
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
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

        }
    }
}