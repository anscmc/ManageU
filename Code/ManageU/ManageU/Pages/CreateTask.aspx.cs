using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace ManageU.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {

            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }
        protected void createTask(object sender, EventArgs e)
        {
            string strsql = "";
            string name = taskName.Text;
            string date = dueDate2.Value.ToString();
            DateTime taskDueDateTime;
            string time;
            int hr= Int32.Parse(hour.Value);
            string min;

            if(Int32.Parse(hour.Value) == 12 && amPM.Value == "AM")
            {
                hr = hr - 12;
            }
            else if (amPM.Value == "PM" && Int32.Parse(hour.Value) < 12)
            {
                hr = Int32.Parse(hour.Value) + 12;
            }

            time = hr + ":" + minute.Value + ":00 ";

            taskDueDateTime = DateTime.Parse(date + " " + time);

            string desc = taskDes.Text;
            string email = "";

            //get teamID

            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Store task in database

            strsql = "insert into TaskTable (taskName,teamID,dueDate,timeDue,taskDesc) OUTPUT inserted.taskID values (@task, @team, @dateDue, @timeDue, @description);";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.Parameters.AddWithValue("team", HttpContext.Current.Session["TeamID"].ToString());
            objCmd.Parameters.AddWithValue("task", name);
            objCmd.Parameters.AddWithValue("dateDue", date);
            objCmd.Parameters.AddWithValue("timeDue", time);
            objCmd.Parameters.AddWithValue("description", desc);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            //Send email to players


            //strsql = "Select * from PlayerTable where teamID = '" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            //objCmd = new SqlCommand(strsql, objCon);
            //objRS = objCmd.ExecuteReader();

            //if (objRS.HasRows)
            //{
            //    while (objRS.Read())
            //    {
            //        //send email to each player
            //        email = objRS["playerEmail"].ToString();

            //        MailMessage mail = new MailMessage();
            //        mail.To.Add(email);
            //        mail.From = new MailAddress("manageuapp@gmail.com");
            //        SmtpClient client = new SmtpClient();
            //        client.Port = 587;
            //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //        client.UseDefaultCredentials = false;
            //        client.Credentials = new System.Net.NetworkCredential("manageuapp@gmail.com", "Seniordes2017");
            //        client.Host = "smtp.gmail.com";
            //        client.EnableSsl = true;
            //        mail.Subject = "ManageU Task Completion Request";
            //        mail.Body = "A task has been added by " + HttpContext.Current.Session["Username"].ToString() + " for you to complete. ";
            //        mail.IsBodyHtml = true;
            //        client.Send(mail);
            //    }
            //}

            objCmd = null;
            //objRS.Close();
            objCon.Close();

            Response.Redirect("Tasks.aspx");
        }
    }
}