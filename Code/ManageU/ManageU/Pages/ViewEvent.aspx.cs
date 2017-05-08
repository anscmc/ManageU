using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class ViewMeeting : System.Web.UI.Page
    {
        List<string> eventsInfo = new List<string>();
        string mID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
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
                    System.Web.UI.HtmlControls.HtmlGenericControl hide3 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("att");

                    hide3.Style.Add("display", "none");
                }
                else
                {
                    Response.Redirect("Landing.aspx");
                }

                eventsInfo = (List<string>)HttpContext.Current.Session["TeamEventInfo"];
                int eventToView = Int32.Parse(HttpContext.Current.Session["TeamEventRowToView"].ToString());
                string[] infoSplit = eventsInfo.ElementAt(eventToView).Split(';');
                mID = infoSplit[0];
                eventName.InnerText = infoSplit[1];
                eventType.InnerText = infoSplit[2];
                eventStart.InnerText = infoSplit[3];
                eventEnd.InnerText = infoSplit[4];
                attendingDiv.InnerHtml = infoSplit[5];
                notAttendingDiv.InnerHtml = infoSplit[6];
                eventReoccur.InnerText = infoSplit[7];
                attendanceRequired.InnerText = infoSplit[8];
                if(attendanceRequired.InnerText.ToString() == "Y")
                {
                    attendanceRequired.InnerText = "Yes";
                }
                else
                {
                    attendanceRequired.InnerText = "No";
                }
                des.InnerText = infoSplit[9];
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestCal.aspx");
        }

        protected void deleteEvent_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Delete class from database if want to delete all instances

            strsql = "delete from EventMasterTable where masterID='" + mID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from EventDetailsTable where masterID='" + mID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCon.Close();

            Response.Redirect("TestCal.aspx");
        }

        protected void editEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditEvent.aspx");
        }
    }
}