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
            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {
                //deleteTaskButton.Style.Add("display", "none");
                //addTaskButton.Style.Add("display", "none");
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

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
                    //display tasks

                    HtmlGenericControl yButton =
                    new HtmlGenericControl("button");

                    yButton.Attributes["type"] = "button";
                    yButton.Attributes["ID"] = "yButton" + idNum.ToString() + ";";
                    yButton.Attributes["class"] = "yButtonCSS";
                    yButton.Attributes["runat"] = "server";
                    yButton.InnerText = "";
                    yButton.Attributes["OnClientClick"] = "return false";
                    yButton.Attributes["OnServerClick"] = "xButtonClick";

                    taskName = objRS["taskName"].ToString();

                    Label taskLabel = new Label();
                    taskLabel.Text = taskName;

                    /*taskLabel.Attributes["style"] = "vertical-align:center;text-align:center;display:table-cell;"*/;


                    HtmlGenericControl detailsButton = new HtmlGenericControl("button");

                    detailsButton.Attributes["type"] = "button";
                    detailsButton.Attributes["ID"] = "detailsButton" + idNum.ToString() + ";";
                    detailsButton.Attributes["class"] = "btn btn-default";
                    detailsButton.Attributes["style"] = "border: 2px solid #008CBA;margin-right:1px;";
                    detailsButton.Attributes["OnClientClick"] = "detailsButtonClick";
                    detailsButton.InnerText = "Details";

                    HtmlGenericControl taskDiv =
                            new HtmlGenericControl("div");

                    taskDiv.Attributes["id"] = "taskContent" ;
                    taskDiv.Attributes["class"] = "col-sm-4 infoDiv";
                    taskDiv.Attributes["runat"] = "server";
                    taskDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:100px;max-width:500px;margin: 0 auto;";
                    taskDiv.Controls.Add(yButton);
                    taskDiv.Controls.Add(taskLabel);
                    taskDiv.Controls.Add(detailsButton);
                    tasksDiv.Controls.Add(taskDiv);

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

    protected void createTask(object sender, EventArgs e)
        {
            Response.Redirect("CreateTask.aspx");
        }
    }
}