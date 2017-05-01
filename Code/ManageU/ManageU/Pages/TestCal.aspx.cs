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
            

            int idCount = 0;
            string idString = "";

            int cycle = 1;


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

            HtmlGenericControl leftpanel =
                                new HtmlGenericControl("div");
            leftpanel.Attributes["id"] = "leftpanel";
            leftpanel.Attributes["class"] = "leftpanel";
            leftpanel.Attributes["runat"] = "server";

            HtmlGenericControl divArrow =
                                new HtmlGenericControl("div");
            divArrow.Attributes["id"] = "downArrow";
            divArrow.Attributes["onclick"] = "showLeftPanel()";
            divArrow.Attributes["style"] = "height:auto;width:100%;margin-top:0px;font-size:20px;";
            divArrow.Attributes["runat"] = "server";
            divArrow.Controls.Add(new Literal() { Text = "<i class='fa fa-chevron-down' aria-hidden='true'></i>" });

            leftpanel.Controls.Add(divArrow);

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
                        if (cycle == 1)
                        {
                            cycle = cycle + 1;
                            while (objRS2.Read())
                            {
                                eventStartString = objRS2["eventStart"].ToString();
                                eventIdString = objRS2["masterID"].ToString();
                                //eventNameString = objRS2["eventName"].ToString();
                                eventNameString = "Event Name";

                                string eventDay = eventStartString.Split('/', '/')[1];

                                Label eventMasterID = new Label();
                                eventMasterID.Text = eventIdString;

                                eventMasterID.Attributes["style"] = "display:none;";

                                Label eventStart = new Label();
                                eventStart.Text = eventStartString;
                                Label eventName = new Label();
                                eventName.Text = eventNameString;

                                HtmlGenericControl eventDiv =
                                new HtmlGenericControl("div");
                                idCount = idCount + 1;
                                idString = idCount.ToString();
                                eventDiv.Attributes["id"] = "eventBasic" + idString + "x" + eventDay + "x";
                                eventDiv.Attributes["class"] = "eventBasic";
                                eventDiv.Attributes["onclick"] = "showInfo()";
                                eventDiv.Attributes["runat"] = "server";
                                eventDiv.Attributes["style"] = "color:black;";

                                Label eventDayLabel = new Label();
                                eventDayLabel.Text = eventDay;
                                eventDayLabel.Attributes["id"] = "eventDayLabel" + idString;
                                eventDayLabel.Attributes["class"] = "daysClass";

                                eventDiv.Controls.Add(eventName);
                                eventDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                eventDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                eventDiv.Controls.Add(eventStart);
                                eventDiv.Controls.Add(eventMasterID);
                                eventDiv.Controls.Add(eventDayLabel);
                                eventDiv.Controls.Add(new Literal() { Text = "<a><i class='fa fa-chevron-right' aria-hidden='true' style='float:right;top:50%;font-size:30px;color:black;z-index:1000;'></i></a>" });
                                //eventDiv.Controls.Add(new Literal() { Text = "<br/>" });

                                leftpanel.Controls.Add(eventDiv);
                                container2.Controls.Add(leftpanel);
                            }
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