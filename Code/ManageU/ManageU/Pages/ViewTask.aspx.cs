using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class viewTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                
                if (!IsPostBack)
                {
                    populateTaskInfo();
                }
                if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                {
                    //show the delete and edit buttons
                }
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void populateTaskInfo()
        {
            List<string> taskInfo = new List<string>();
            taskInfo = (List<string>)HttpContext.Current.Session["TasksInfo"];
            int taskToView = Int32.Parse(HttpContext.Current.Session["TaskToView"].ToString());
            string infoInString = taskInfo.ElementAt(taskToView);
            string[] splitInfo = infoInString.Split('-');

            string taskName = splitInfo[0];
            string taskDate = splitInfo[2] + "/" + splitInfo[3] + "/" + splitInfo[1];
            string taskTime = splitInfo[4];
            string[] timeSplit = taskTime.Split(':');
            string hour = timeSplit[0];
            string ampm = "AM";
            if(Int32.Parse(hour) > 12)
            {
                hour = (Int32.Parse(hour) - 12).ToString();
                ampm = "PM";
            }
            string minute = timeSplit[1];
            
            string taskDescription = splitInfo[5];

            name.InnerText = taskName;
            duedate.InnerText = taskDate;
            duetime.InnerText = hour + ":" + minute + " " + ampm;
            desc.InnerText = taskDescription;
        }
    }
}