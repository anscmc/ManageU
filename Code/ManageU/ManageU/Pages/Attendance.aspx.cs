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

                        Label eventName = new Label();
                        eventName.Text = name;
                        Label eventType = new Label();
                        eventType.Text = type;
                        Label eventStart = new Label();
                        eventStart.Text = start;
                        Label eventEnd = new Label();
                        eventEnd.Text = end;

                        HtmlGenericControl yesButton =
                        new HtmlGenericControl("button");

                        yesButton.Attributes["type"] = "button";
                        yesButton.Attributes["class"] = "btn btn-default";
                        yesButton.Attributes["runat"] = "server";
                        yesButton.InnerText = "Yes";
                        yesButton.Attributes["OnClick"] = "yesClick";

                        HtmlGenericControl noButton =
                        new HtmlGenericControl("button");

                        noButton.Attributes["type"] = "button";
                        noButton.Attributes["class"] = "btn btn-default";
                        noButton.Attributes["runat"] = "server";
                        noButton.InnerText = "No";
                        noButton.Attributes["OnClick"] = "noClick";


                        HtmlGenericControl infoDiv =
                        new HtmlGenericControl("div");

                        infoDiv.Attributes["id"] = "rosterContent";
                        infoDiv.Attributes["class"] = "col-sm-4 infoDiv";
                        infoDiv.Attributes["runat"] = "server";
                        infoDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:auto;max-width:500px;margin: 0 auto;";

                        infoDiv.Controls.Add(eventName);
                        infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        infoDiv.Controls.Add(eventType);
                        infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        infoDiv.Controls.Add(eventStart);
                        infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        infoDiv.Controls.Add(eventEnd);
                        infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        infoDiv.Controls.Add(yesButton);
                        infoDiv.Controls.Add(noButton);

                        atRecord.Controls.Add(infoDiv);
                    
                    }

                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }
        protected void yesClick(object sender, EventArgs e)
        {

        }
        protected void noClick(object sender, EventArgs e)
        {

        }
    }
}