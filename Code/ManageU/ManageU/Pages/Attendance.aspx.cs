﻿using System;
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
        List<string> ids = new List<string>();
        List<string> attending = new List<string>();
        List<string> notatt = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {
                System.Web.UI.HtmlControls.HtmlGenericControl hide1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("meetings");

                hide1.Style.Add("display", "none");
                System.Web.UI.HtmlControls.HtmlGenericControl hide2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("invite");

                hide2.Style.Add("display", "none");
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                //editButton.Style.Add("display", "block");
                System.Web.UI.HtmlControls.HtmlGenericControl hide = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("mySched");
                hide.Style.Add("display", "none");

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
            loadAttendanceEvents();
        }

        public void loadAttendanceEvents() {
            string name;
            string type;
            string start;
            string end;
            int count = 0;
            //find events in master table with teamID and attendance required = Y 
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlCommand objCmd2 = default(SqlCommand);
            SqlDataReader objRS;
            SqlDataReader objRS2;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCon2 = new SqlConnection();
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            atRecord.InnerHtml = "";

            strsql = "select * from EventMasterTable where associatedID='" + HttpContext.Current.Session["TeamID"].ToString() + "' and attreq='Y'";

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                objCon2.Open();
                while (objRS.Read())
                {
                    strsql = "select * from EventDetailsTable where associatedID='" + HttpContext.Current.Session["TeamID"].ToString() + "' and attreq='Y'";
                    objCmd2 = new SqlCommand(strsql, objCon2);

                    objRS2 = objCmd2.ExecuteReader();

                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            
                            //if the player has already responded to the attendance, do not show it
                            if (objRS2["attendees"].ToString().Contains(HttpContext.Current.Session["Username"].ToString()))
                            {

                            }
                            else if (objRS2["notattending"].ToString().Contains(HttpContext.Current.Session["Username"].ToString()))
                            {

                            }
                            //if the player did not respond to the attendance yet, show it
                            else
                            {
                                count = count + 1;
                                //here is where to display divs so player can respond
                                name = objRS["eventName"].ToString();
                                type = objRS["eventType"].ToString();
                                start = objRS2["eventStart"].ToString();
                                end = objRS2["eventEnd"].ToString();

                                ids.Add(objRS2["eventID"].ToString());
                                attending.Add(objRS2["attendees"].ToString());
                                notatt.Add(objRS2["notattending"].ToString());

                                Label eventName = new Label();
                                eventName.Text = name;
                                Label eventType = new Label();
                                eventType.Text = type;
                                eventType.Attributes["style"] = "color:#ba9800;";
                                Label eventStart = new Label();
                                eventStart.Text = start + " to";
                                Label eventEnd = new Label();
                                eventEnd.Text = end;

                                Label toLabel = new Label();
                                toLabel.Text = "to";

                                Label attend = new Label();
                                attend.Text = "Can you attend this event?";
                                attend.Attributes["style"] = "color:#ba9800;";


                                Button yesButton =
                                new Button();
                                
                                yesButton.ID = "yes" + count;
                                yesButton.Attributes["class"] = "btn btn-default";
                                yesButton.Attributes["style"] = "display:inline;";
                                yesButton.Attributes["runat"] = "server";
                                yesButton.Text = "Yes";
                                yesButton.Click += yes;

                                Button noButton =
                                new Button();

                                noButton.ID = "no" + count;
                                noButton.Attributes["class"] = "btn btn-default";
                                noButton.Attributes["style"] = "display:inline;";
                                noButton.Attributes["runat"] = "server";
                                noButton.Text = "No";
                                noButton.Click += no;


                                HtmlGenericControl infoDiv =
                                new HtmlGenericControl("div");

                                infoDiv.Attributes["id"] = "rosterContent";
                                infoDiv.Attributes["class"] = "infoDiv2";
                                infoDiv.Attributes["runat"] = "server";
                                infoDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:auto;max-width:500px;margin: 0 auto;";

                                infoDiv.Controls.Add(eventType);
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(eventName);
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(eventStart);
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                //infoDiv.Controls.Add(toLabel);
                                //infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(eventEnd);
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(attend);
                                infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                                infoDiv.Controls.Add(yesButton);
                                infoDiv.Controls.Add(noButton);

                                atRecord.Controls.Add(infoDiv);

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
        }
        protected void yes(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            string row = senderButton.ID.Replace("yes", "");
            string id = ids.ElementAt(Int32.Parse(row) - 1);
            string att = attending.ElementAt(Int32.Parse(row) - 1);
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            if(att == "")
            {
                strsql = "Update EventDetailsTable set attendees ='" + HttpContext.Current.Session["Username"].ToString() + "' where eventID='" + id + "'";
            }
            else
            {
                strsql = "Update EventDetailsTable set attendees ='" + att + "," + HttpContext.Current.Session["Username"].ToString() + "' where eventID='" + id + "'";
            }

            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;
            objCon.Close();

            loadAttendanceEvents();
        }
        protected void no(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            string row = senderButton.ID.Replace("no", "");
            string id = ids.ElementAt(Int32.Parse(row) - 1);
            string not = notatt.ElementAt(Int32.Parse(row) - 1);
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            if (not == "")
            {
                strsql = "Update EventDetailsTable set notattending ='" + HttpContext.Current.Session["Username"].ToString() + "' where eventID='" + id + "'";
            }
            else
            {
                strsql = "Update EventDetailsTable set notattending ='" + not + "," + HttpContext.Current.Session["Username"].ToString() + "' where eventID='" + id + "'";
            }

            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;
            objCon.Close();

            loadAttendanceEvents();

        }
    }
}