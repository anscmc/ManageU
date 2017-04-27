using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class viewTask : System.Web.UI.Page
    {
        string tID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                List<string> taskInfo = new List<string>();
                taskInfo = (List<string>)HttpContext.Current.Session["TasksInfo"];
                int taskToView = Int32.Parse(HttpContext.Current.Session["TaskToView"].ToString());
                string infoInString = taskInfo.ElementAt(taskToView);
                string[] splitInfo = infoInString.Split('-');

                tID = splitInfo[0];

                if (HttpContext.Current.Session["UserType"].ToString() == "player")
                {
                    deleteTask.Style.Add("display", "none");
                    editTask.Style.Add("display", "none");
                }

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
            int taskToView = Int32.Parse(HttpContext.Current.Session["TaskToView"].ToString());
            string infoInString = taskInfo.ElementAt(taskToView);
            string[] splitInfo = infoInString.Split('-');

            tID = splitInfo[0];
            string taskName = splitInfo[1];
            string taskDate = splitInfo[3] + "/" + splitInfo[4] + "/" + splitInfo[2];
            string taskTime = splitInfo[5];
            string[] timeSplit = taskTime.Split(':');
            string hour = timeSplit[0];
            string ampm = "AM";
            if(Int32.Parse(hour) > 12)
            {
                hour = (Int32.Parse(hour) - 12).ToString();
                ampm = "PM";
            }
            string minute = timeSplit[1];
            
            string taskDescription = splitInfo[6];

            name.InnerText = taskName;
            duedate.InnerText = taskDate;
            duetime.InnerText = hour + ":" + minute + " " + ampm;
            desc.InnerText = taskDescription;
        }

        protected void deleteTask_Click(object sender, EventArgs e)
        {
            //have to keep changing this for testing purposes
            string taskID = tID;
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

            strsql = "delete from TaskTable where taskID='" + taskID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            //send email to players
            string email = "";
            strsql = "Select * from PlayerTable where teamID = '" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            objCmd = new SqlCommand(strsql, objCon);
            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //send email to each player
                    email = objRS["playerEmail"].ToString();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("manageuapp@gmail.com");
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("manageuapp@gmail.com", "Seniordes2017");
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    mail.Subject = "ManageU Task Deleted";
                    mail.Body = "A task has been deleted by " + HttpContext.Current.Session["Username"].ToString();
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();

            Response.Redirect("Tasks.aspx");
        }

        protected void editTask_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["FromView"] = "specific";
            HttpContext.Current.Session["TaskToEdit"] = HttpContext.Current.Session["TaskToView"].ToString();
            Response.Redirect("EditTask.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tasks.aspx");
        }
    }
}