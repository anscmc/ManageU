using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

namespace ManageU.Pages
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAttendanceEvents();
        }

        public void loadAttendanceEvents() {
            string name;
            string type;
            string start;
            string end;

            //find events in master table with teamID and attendance required = Y 
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Store task in database

            strsql = "select * from EventMasterTable where associatedID='" + HttpContext.Current.Session["TeamID"].ToString() + "' and attreq='Y'";
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //if the player has already responded to the attendance, do not show it
                    if (objRS["attendees"].ToString().Contains(HttpContext.Current.Session["UserID"].ToString()))
                    {

                    }
                    else if (objRS["notattending"].ToString().Contains(HttpContext.Current.Session["UserID"].ToString())) {

                    }
                    //if the player did not respond to the attendance yet, show it
                    else
                    {
                        //here is where to display divs so player can respond
                        name = objRS["eventName"].ToString();
                        type = objRS["eventType"].ToString();
                        start = objRS["eventStart"].ToString();
                        end = objRS["eventEnd"].ToString();
                        //you will have to split up the event start and event end to be a date and start and end times (the start date and end date should be the same so you only need one date)

                    }

                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }
    }
}