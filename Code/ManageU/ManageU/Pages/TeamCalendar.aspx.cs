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
    public partial class TeamCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                if (!IsPostBack)
                {
                    DateTime localDate = DateTime.Now;
                    monthLabel.InnerText = localDate.Month.ToString();
                } 
                    loadCalendar();
                
            }
          
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        private void loadCalendar()
        {
            
            

            SqlConnection objCon = default(SqlConnection);
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlCommand objCmd2 = default(SqlCommand);
            objCon = new SqlConnection();
            objCon2 = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd2 = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd2.Connection = objCon2;
            SqlDataReader objRS;
            SqlDataReader objRS2;
            string strsql = "";
            string strsql2 = "";

            //get all the event info first
            strsql = "select * from EventMasterTable where associatedID ='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            objCon.Open();
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //get all dates of the event
                    strsql2 = "select * from EventDetailsTable where associatedID ='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
                    objCon2.Open();

                    objCmd2 = new SqlCommand(strsql2, objCon2);

                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            //show the events (using what is in objRS (event details) AND objRS2 (event dates))
                        }
                    }

                    objCmd2 = null;
                    objRS2.Close();
                    objCon2.Close();
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }

        protected void createEvent(object sender, EventArgs e)
        {
            Response.Redirect("FindTime.aspx");
        }

        protected void teamEventDetailsButton_Click(object sender, EventArgs e)
        {
            //will have to get this from the one that is clicked (sender)
            HttpContext.Current.Session["eventID"] = 2;
            Response.Redirect("ViewTeamEvent.aspx");
        }

        protected void nextMonth(object sender, EventArgs e)
        {
            // Not todays date, label date
            DateTime localDate = DateTime.Now;
            monthLabel.InnerText = (localDate.Month + 1).ToString();
        }
        protected void lastMonth(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            monthLabel.InnerText = (localDate.Month - 1).ToString();
            //Response.Redirect("TeamCalendar.aspx");
        }

    }
}