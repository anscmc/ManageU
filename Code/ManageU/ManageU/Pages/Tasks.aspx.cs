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
    public partial class Tasks : System.Web.UI.Page
    {
        List<string> taskInfo = new List<string>();
        List<string> taskIDs = new List<string>();
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

                    createButtton.Style.Add("display", "none");
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
                loadTasks();
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            
        }


    private void loadTasks()
    {
        string taskName = "";
        int idNum = 0;
            string taskID;
            string dueDate;
            string dueTime;
            string description;
            string playersCompleted;
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

           tasksDiv.InnerHtml = "";

            strsql = "select * from TaskTable where teamID='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
        objCmd = new SqlCommand(strsql, objCon);

        objRS = objCmd.ExecuteReader();

        if (objRS.HasRows)
        {
            while (objRS.Read())
            {
                   
                    //if the player has already completed the task, do not show it
                    if (objRS["completed"].ToString().Contains(HttpContext.Current.Session["Username"].ToString()))
                    {

                    }
                    //if the player did not complete the task yet, show it
                    else {
                        idNum++;
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
                        taskID = objRS["taskID"].ToString();
                        dueDate = objRS["dueDate"].ToString();
                        dueTime = objRS["timeDue"].ToString();
                        description = objRS["taskDesc"].ToString();
                        playersCompleted = objRS["completed"].ToString();
                        string[] timeSplit = dueTime.Split(':');
                        string dueHour = timeSplit[0];
                        string dueampm = "AM";
                        if(dueHour == "0")
                        {
                            dueHour = (Int32.Parse(dueHour) + 12).ToString();
                        }
                        else if(Int32.Parse(dueHour) == 12)
                        {
                            dueampm = "PM";
                        }
                        else if(Int32.Parse(dueHour) > 12)
                        {
                            dueHour = (Int32.Parse(dueHour) - 12).ToString();
                            dueampm = "PM";
                        }
                        string dueMinute = timeSplit[1];

                        dueTime = dueHour + " " + dueMinute + " " + dueampm;

                        taskInfo.Add(taskID + "-" + taskName + "-" + dueDate + "-" + dueTime + "-" + description + "-" + playersCompleted);
                        HttpContext.Current.Session["TasksInfo"] = taskInfo;
                        taskIDs.Add(taskID);

                        Label taskLabel = new Label();
                        taskLabel.Text = taskName;

                        Label dueDateLabel = new Label();
                        dueDateLabel.Text = "Due: " + dueDate + " at " + dueTime;

                        /*taskLabel.Attributes["style"] = "vertical-align:center;text-align:center;display:table-cell;"*/
                        


                        HtmlGenericControl taskDiv =
                                new HtmlGenericControl("div");

                        taskDiv.Attributes["id"] = "taskContent";
                        taskDiv.Attributes["class"] = "col-sm-4 taskDiv";
                        taskDiv.Attributes["runat"] = "server";
                        taskDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:100px;max-width:500px;margin: 0 auto;margin-bottom:3px";

                        if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                        {

                            taskDiv.Controls.Add(new Literal() { Text = "<a style='z-index:1000;' onclick='return deleteTask(" + idNum.ToString() + ")'><i class='fa fa-minus-circle fontA' aria-hidden='true' style='font-size:30px;color:#ba0047;float:left;top:10%;'></i></a>" });
                            taskDiv.Controls.Add(new Literal() { Text = "<a style='z-index:1000;' onclick='return editTask(" + idNum.ToString() + ")'><i class='fa fa-pencil-square-o fontA' aria-hidden='true' style='font-size:30px;color:black;float:right;bottom:10%;'></i></a>" });
                            taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        }

                        //taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(taskLabel);
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(dueDateLabel);
                        taskDiv.Controls.Add(new Literal() { Text = "<a id='taskDivA' style='z-index:1000;float:right;margin-right:7px;' onclick='return taskDetails(" + idNum.ToString() + ")'><i id='chev' class='fa fa-chevron-right fontA' aria-hidden='true' style='display:inline;position:absolute;float:right;font-size:30px;color:black;'></i></a>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });
                        taskDiv.Controls.Add(new Literal() { Text = "<br/>" });



                        if (HttpContext.Current.Session["UserType"].ToString() == "player")
                        {
                            CheckBox completeCheck = new CheckBox();
                            completeCheck.ID = "check" + idNum.ToString();
                            completeCheck.InputAttributes.Add("class", "rosterCheck");
                            completeCheck.Attributes["Style"] = "margin-bottom:5px;bottom:5px;";
                            completeCheck.Text = "I completed this task";
                            completeCheck.Attributes.Add("onclick", "completeTask(" + idNum.ToString() + ")");
                            taskDiv.Controls.Add(completeCheck);
                        }

                        
                        
                        //taskDiv.Attributes["onclick"] = "return taskDetails(" + idNum.ToString() + ")";
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

        protected void detailsT(object sender, EventArgs e)
        {
            HttpContext.Current.Session["TaskToView"] = Int32.Parse(detailsHiddenField.Value) - 1;
            Response.Redirect("ViewTask.aspx");
        }

        protected void deleteT(object sender, EventArgs e)
        {
            //have to keep changing this for testing purposes
            string taskID = taskIDs.ElementAt(Int32.Parse(deleteHiddenField.Value) - 1);
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

            loadTasks();
        }

        protected void editT(object sender, EventArgs e)
        {
            HttpContext.Current.Session["FromView"] = "all";
            HttpContext.Current.Session["TaskToEdit"] = Int32.Parse(editHiddenField.Value) - 1;
            Response.Redirect("EditTask.aspx");
        }

    protected void completeT(object sender, EventArgs e)
        {
            //add user ID to completed
            string row = completeHiddenField.Value;
            string id = taskIDs.ElementAt(Int32.Parse(row) - 1);
            string completeIds = "";
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            strsql = "Select * from TaskTable where taskID='" + id + "';";
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    completeIds = objRS["completed"].ToString();
                    
                }
                objCmd = null;
                strsql = "Update TaskTable set completed='" + completeIds +  HttpContext.Current.Session["Username"].ToString() + "," + "' where taskID='" + id + "'";
                objRS.Close();
                objCmd = new SqlCommand(strsql, objCon);
                objCmd.ExecuteNonQuery();
            }

           
            objCmd = null;
            objCon.Close();
                    loadTasks();
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
                    strsql2 = "update TaskTable set completed='" + objRS["completed"].ToString() + ";" + HttpContext.Current.Session["Username"] + "'";
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