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
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                //deleteTaskButton.Style.Add("display", "none");
                //addTaskButton.Style.Add("display", "none");
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            loadTasks();
        }


    private void loadTasks()
    {
        string taskName = "";
        string idNum = "0";

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

        strsql = "select * from TaskTable where teamID='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
        objCmd = new SqlCommand(strsql, objCon);

        objRS = objCmd.ExecuteReader();

        if (objRS.HasRows)
        {
            while (objRS.Read())
            {
                    //if the player has already completed the task, do not show it
                    if (objRS["completed"].ToString().Contains(HttpContext.Current.Session["UserID"].ToString()))
                    {

                    }
                    //if the player did not complete the task yet, show it
                    else {
                        HtmlGenericControl yButton =
                        new HtmlGenericControl("button");

                        yButton.Attributes["type"] = "button";
                        //yButton.Attributes["ID"] = "yButton" + idNum.ToString() + ";";
                        yButton.Attributes["ID"] = "yButton" + idNum.ToString() ;
                        yButton.Attributes["class"] = "yButtonCSS";
                        yButton.Attributes["runat"] = "server";
                        yButton.InnerText = "";
                        yButton.Attributes["OnClientClick"] = "return false";
                        yButton.Attributes["OnServerClick"] = "xButtonClick";

                        taskName = objRS["taskName"].ToString();

                        Label taskLabel = new Label();
                        taskLabel.Text = taskName;

                        /*taskLabel.Attributes["style"] = "vertical-align:center;text-align:center;display:table-cell;"*/
                        ;


                        HtmlGenericControl detailsButton = new HtmlGenericControl("button");

                        detailsButton.Attributes["type"] = "button";
                        detailsButton.Attributes["ID"] = "detailsButton" + idNum.ToString() + ";";
                        detailsButton.Attributes["class"] = "btn btn-default";
                        detailsButton.Attributes["style"] = "display:none;border: 2px solid #008CBA;margin-right:1px;";
                        detailsButton.Attributes["OnClientClick"] = "detailsButtonClick";
                        detailsButton.InnerText = "Details";

                        CheckBox completeCheck = new CheckBox();
                        completeCheck.ID = "check" + idNum.ToString();
                        completeCheck.InputAttributes.Add("class", "rosterCheck");
                        completeCheck.Attributes["Style"] = "margin-bottom:5px;bottom:5px;";
                        completeCheck.Text = "I completed this task";

                        HtmlGenericControl taskDiv =
                                new HtmlGenericControl("div");

                        taskDiv.Attributes["id"] = "taskContent";
                        taskDiv.Attributes["class"] = "col-sm-4 infoDiv";
                        taskDiv.Attributes["runat"] = "server";
                        taskDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:100px;max-width:500px;margin: 0 auto;";

                        taskDiv.Controls.Add(taskLabel);
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(completeCheck);
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<a onclick='return deleteTask()'><i class='fa fa-minus-circle' aria-hidden='true' style='display:inline;font-size:30px;color:#ba0047;'></i></a>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<a onclick='return editTask()'><i class='fa fa-pencil-square-o' aria-hidden='true' style='display:inline;font-size:30px;color:black;'></i></a>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<a onclick='return taskDetails()'><i class='fa fa-chevron-right' aria-hidden='true' style='float:right;top:50%;font-size:30px;color:black;'></i></a>" });
                        //taskDiv.Controls.Add(detailsButton);
                        tasksDiv.Controls.Add(taskDiv);
                    }

                }
        }

        objCmd = null;
        objRS.Close();
        objCon.Close();
    }

    //protected void addTaskButton_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("CreateTasks.aspx");
    //}

    protected void viewTaskButton_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["taskID"] = 1;
        Response.Redirect("ViewTask.aspx");
    }

    protected void deleteTaskButton_Click(object sender, EventArgs e)
    {
        //have to keep changing this for testing purposes
        string taskID = "4";
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

    }

    protected void completeTaskButton_Click(object sender, EventArgs e)
    {
            int taskIDFromVar = 1;
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

            //make sure task exists 
            strsql = "select * from TaskTable where taskID ='" + taskIDFromVar + "'";
            objCon.Open();
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //show player completed task in table (separated by semi colons)
                    strsql2 = "update TaskTable set completed='" + objRS["completed"].ToString() + ";" + HttpContext.Current.Session["UserID"] + "'";
                    objCon2.Open();

                    objCmd2 = new SqlCommand(strsql2, objCon2);
                    objCmd2.ExecuteNonQuery();

                    objCmd2 = null;
                    objCon2.Close();
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }

            protected void createTask(object sender, EventArgs e)
        {
            Response.Redirect("CreateTask.aspx");
        }
    }
}