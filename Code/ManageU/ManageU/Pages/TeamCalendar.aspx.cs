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
                    HttpContext.Current.Session["first"] = "first";

                    if (HttpContext.Current.Session["first"].ToString() == "first")
                    {


                        DateTime localDate = DateTime.Now;
                        HttpContext.Current.Session["monthNum"] = localDate.Month.ToString();

                        int monthInt = localDate.Month;

                        switch (monthInt)
                        {
                            case 1:
                                monthLabel.InnerText = "January";
                                break;
                            case 2:
                                monthLabel.InnerText = "February";
                                break;
                            case 3:
                                monthLabel.InnerText = "March";
                                break;
                            case 4:
                                monthLabel.InnerText = "April";
                                break;
                            case 5:
                                monthLabel.InnerText = "May";
                                break;
                            case 6:
                                monthLabel.InnerText = "June";
                                break;
                            case 7:
                                monthLabel.InnerText = "July";
                                break;
                            case 8:
                                monthLabel.InnerText = "August";
                                break;
                            case 9:
                                monthLabel.InnerText = "September";
                                break;
                            case 10:
                                monthLabel.InnerText = "October";
                                break;
                            case 11:
                                monthLabel.InnerText = "November";
                                break;
                            case 12:
                                monthLabel.InnerText = "December";
                                break;
                        }
                    }
                    
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
            HttpContext.Current.Session["first"] = "notfirst";
            string monthString = HttpContext.Current.Session["monthNum"].ToString();
            switch (monthString)
            {
                case "12":
                    monthLabel.InnerText = "January";
                    HttpContext.Current.Session["monthNum"] = "1";
                    break;
                case "1":
                    monthLabel.InnerText = "February";
                    HttpContext.Current.Session["monthNum"] = "2";
                    break;
                case "2":
                    monthLabel.InnerText = "March";
                    HttpContext.Current.Session["monthNum"] = "3";
                    break;
                case "3":
                    monthLabel.InnerText = "April";
                    HttpContext.Current.Session["monthNum"] = "4";
                    break;
                case "4":
                    monthLabel.InnerText = "May";
                    HttpContext.Current.Session["monthNum"] = "5";
                    break;
                case "5":
                    monthLabel.InnerText = "June";
                    HttpContext.Current.Session["monthNum"] = "6";
                    break;
                case "6":
                    monthLabel.InnerText = "July";
                    HttpContext.Current.Session["monthNum"] = "7";
                    break;
                case "7":
                    monthLabel.InnerText = "August";
                    HttpContext.Current.Session["monthNum"] = "8";
                    break;
                case "8":
                    monthLabel.InnerText = "September";
                    HttpContext.Current.Session["monthNum"] = "9";
                    break;
                case "9":
                    monthLabel.InnerText = "October";
                    HttpContext.Current.Session["monthNum"] = "10";
                    break;
                case "10":
                    monthLabel.InnerText = "November";
                    HttpContext.Current.Session["monthNum"] = "11";
                    break;
                case "11":
                    monthLabel.InnerText = "December";
                    HttpContext.Current.Session["monthNum"] = "12";
                    break;
            }



        }
        protected void lastMonth(object sender, EventArgs e)
        {
            
            string monthString = HttpContext.Current.Session["monthNum"].ToString();
            switch (monthString)
            {
                case "2":
                    monthLabel.InnerText = "January";
                    HttpContext.Current.Session["monthNum"] = "1";
                    break;
                case "3":
                    monthLabel.InnerText = "February";
                    HttpContext.Current.Session["monthNum"] = "2";
                    break;
                case "4":
                    monthLabel.InnerText = "March";
                    HttpContext.Current.Session["monthNum"] = "3";
                    break;
                case "5":
                    monthLabel.InnerText = "April";
                    HttpContext.Current.Session["monthNum"] = "4";
                    break;
                case "6":
                    monthLabel.InnerText = "May";
                    HttpContext.Current.Session["monthNum"] = "5";
                    break;
                case "7":
                    monthLabel.InnerText = "June";
                    HttpContext.Current.Session["monthNum"] = "6";
                    break;
                case "8":
                    monthLabel.InnerText = "July";
                    HttpContext.Current.Session["monthNum"] = "7";
                    break;
                case "9":
                    monthLabel.InnerText = "August";
                    HttpContext.Current.Session["monthNum"] = "8";
                    break;
                case "10":
                    monthLabel.InnerText = "September";
                    HttpContext.Current.Session["monthNum"] = "9";
                    break;
                case "11":
                    monthLabel.InnerText = "October";
                    HttpContext.Current.Session["monthNum"] = "10";
                    break;
                case "12":
                    monthLabel.InnerText = "November";
                    HttpContext.Current.Session["monthNum"] = "11";
                    break;
                case "1":
                    monthLabel.InnerText = "December";
                    HttpContext.Current.Session["monthNum"] = "12";
                    break;
            }
        }

    }
}