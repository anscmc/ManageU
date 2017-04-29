using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace ManageU.Pages
{
    public partial class TestCal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                if (!IsPostBack)
                {
                    Calendar2.ShowNextPrevMonth = false;
                    Calendar2.SelectedDate = DateTime.Now;
                    Calendar2.VisibleDate = Calendar2.SelectedDate;
                    DateTime curMonth = Calendar2.SelectedDate;
                    //monthLabel.InnerText = curMonth.Month.ToString();

                    int monthInt = curMonth.Month;

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
                loadCalendar();
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        private void loadCalendar()
        {
            string eventIdString = "";
            string eventNameString = "";
            string eventStartString = "";
            string eventEndString = "";


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
                            eventStartString = objRS2["eventStart"].ToString();
                            eventIdString = objRS2["masterID"].ToString();

                            Label eventMasterID = new Label();
                            eventMasterID.Text = eventIdString;

                            eventMasterID.Attributes["style"] = "display:none;";

                            Label eventStart = new Label();
                            eventStart.Text = eventStartString;

                            HtmlGenericControl eventDiv =
                            new HtmlGenericControl("div");

                            eventDiv.Attributes["id"] = "eventDiv";
                            eventDiv.Attributes["class"] = "eventBasic";
                            eventDiv.Attributes["onclick"] = "showInfo()";
                            eventDiv.Attributes["runat"] = "server";
                            eventDiv.Attributes["style"] = "color:black;";

                            eventDiv.Controls.Add(eventStart);
                            eventDiv.Controls.Add(eventMasterID);
                            //eventDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            leftpanel.Controls.Add(eventDiv);
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



            //Label eventStart = new Label();
            //eventStart.Text = "01/01/2018 12:00:00 AM";

            //HtmlGenericControl eventDiv =
            //new HtmlGenericControl("div");

            //eventDiv.Attributes["id"] = "eventDiv";
            //eventDiv.Attributes["class"] = "col-sm-4 infoDiv";
            //eventDiv.Attributes["runat"] = "server";
            //eventDiv.Attributes["style"] = "width:100%;height:100px;background-color:white;color:white;border: 2px solid #ba9800;margin-top:10px;";
            //eventDiv.Attributes["onclick"] = "showRightPanel()";

            //eventDiv.Controls.Add(eventStart);
            //eventDiv.Controls.Add(new Literal() { Text = "<br/>" });
            //leftpanel.Controls.Add(eventDiv);
        }

        protected void createEvent(object sender, EventArgs e)
        {
            Response.Redirect("CreateEvent.aspx");
        }

        protected void nextMonth(object sender, EventArgs e)
        {
            

            //Calendar2.VisibleDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.SelectedDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.VisibleDate = Calendar2.SelectedDate;
            DateTime curMonth = Calendar2.SelectedDate;
            //monthLabel.InnerText = curMonth.Month.ToString();

            int monthInt = curMonth.Month;

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
        protected void lastMonth(object sender, EventArgs e)
        {
            //Calendar2.VisibleDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.SelectedDate = Calendar2.SelectedDate.AddMonths(-1);
            Calendar2.VisibleDate = Calendar2.SelectedDate;
            DateTime curMonth = Calendar2.SelectedDate;
            //monthLabel.InnerText = curMonth.Month.ToString();

            int monthInt = curMonth.Month;

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
}