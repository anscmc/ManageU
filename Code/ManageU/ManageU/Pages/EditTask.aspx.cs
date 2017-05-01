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
    public partial class EditTask : System.Web.UI.Page
    {
        string tID;
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

                }
                else
                {
                    Response.Redirect("Landing.aspx");
                }
                List<string> taskInfo = new List<string>();
                taskInfo = (List<string>)HttpContext.Current.Session["TasksInfo"];
                int taskToEdit = Int32.Parse(HttpContext.Current.Session["TaskToEdit"].ToString());
                string infoInString = taskInfo.ElementAt(taskToEdit);
                string[] splitInfo = infoInString.Split('-');

                tID = splitInfo[0];
                if (!IsPostBack)
                {
                    
                    populateTaskInfo();
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
            int taskToEdit = Int32.Parse(HttpContext.Current.Session["TaskToEdit"].ToString());
            string infoInString = taskInfo.ElementAt(taskToEdit);
            string[] splitInfo = infoInString.Split('-');

            tID = splitInfo[0];
            string tName = splitInfo[1];
            taskName.Text = tName;
            string taskDate = splitInfo[2] + "-" + splitInfo[3] + "-" + splitInfo[4];
            dueDate2.Value = taskDate;
            string taskTime = splitInfo[5];
            string[] timeSplit = taskTime.Split(' ');
            string hr = timeSplit[0];
            string tAmPm = timeSplit[2];

            string min = timeSplit[1];

            hour.Value = hr;
            minute.Value = min;
            amPM.Value = tAmPm;

            string taskDescription = splitInfo[6];
            taskDes.Text = taskDescription;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["FromView"].ToString() == "specific")
            {
                Response.Redirect("ViewTask.aspx");
            }
            else
            {
                Response.Redirect("Tasks.aspx");
            }
        }

        protected void saveTask_Click(object sender, EventArgs e)
        {
            string tName = taskName.Text;
            string tDate = dueDate2.Value;
            string tTime;
            string hr = hour.Value;
            if (Int32.Parse(hr) == 12 && amPM.Value == "AM")
            {
                hr = (Int32.Parse(hour.Value) - 12).ToString();
            }
            else if(Int32.Parse(hr) < 12 && amPM.Value == "PM")
            {
                hr = (Int32.Parse(hr) + 12).ToString();
            }
            string min = minute.Value;

            tTime = hr + ":" + min + ":00";

            string desc = taskDes.Text;

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            strsql = "Update TaskTable set taskName='" + tName + "', dueDate='" + tDate + "', timeDue='" + tTime + "', taskDesc='" + desc + "' where taskID= '" + tID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            Response.Redirect("Tasks.aspx");
        }
    }
}