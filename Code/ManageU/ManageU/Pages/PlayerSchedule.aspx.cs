﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace ManageU.Pages
{
    public partial class PlayerSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                loadCalendar();
            }
          
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        private void loadCalendar()
        {
            String eventName = "";
            String eventStart = "";
            String eventEnd = "";

            int idCount = 0;

            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            SqlDataReader objRS;
            string strsql = "";


            strsql = "select * from EventMasterTable where associatedID ='" + HttpContext.Current.Session["UserID"].ToString() + "'";
            objCon.Open();

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    idCount = idCount + 1;
                    eventName = objRS["eventName"].ToString();
                    eventStart = objRS["eventStart"].ToString();
                    eventEnd = objRS["eventEnd"].ToString();

                    HtmlGenericControl singleClassDiv =
                    new HtmlGenericControl("div");
                    singleClassDiv.Attributes["id"] = "class" + idCount.ToString();
                    singleClassDiv.Attributes["class"] = "classDiv";
                    singleClassDiv.Attributes["runat"] = "server";
                    classDiv.Controls.Add(singleClassDiv);


                    HtmlGenericControl classTimes =
                    new HtmlGenericControl("div");
                    classTimes.Attributes["id"] = "classTimes" + idCount.ToString();
                    classTimes.Attributes["class"] = "classTimes";
                    classTimes.Attributes["runat"] = "server";

                    Label startTimeLabel = new Label();
                    startTimeLabel.Text = eventStart;
                    Label endTimeLabel = new Label();
                    endTimeLabel.Text = eventEnd;
                    classTimes.Controls.Add(startTimeLabel);
                    classTimes.Controls.Add(new Literal() { Text = "<br/>" });
                    classTimes.Controls.Add(endTimeLabel);
                    

                    HtmlGenericControl classDetails =
                    new HtmlGenericControl("div");
                    classDetails.Attributes["id"] = "classDetails" + idCount.ToString();
                    classDetails.Attributes["class"] = "classDets";
                    classDetails.Attributes["runat"] = "server";

                    Label classNameLabel = new Label();
                    classNameLabel.Text = eventName;
                    Label classDaysLabel = new Label();
                    classDaysLabel.Text = "M W F";
                    classDetails.Controls.Add(classNameLabel);
                    classDetails.Controls.Add(new Literal() { Text = "<br/>" });
                    classDetails.Controls.Add(classDaysLabel);


                    HtmlGenericControl classDates =
                    new HtmlGenericControl("div");
                    classDates.Attributes["id"] = "classDates" + idCount.ToString();
                    classDates.Attributes["class"] = "classDates";
                    classDates.Attributes["runat"] = "server";

                    Label startDateLabel = new Label();
                    startDateLabel.Text = "1/1/2017";
                    Label endDateLabel = new Label();
                    endDateLabel.Text = "5/5/2017";
                    classTimes.Controls.Add(startDateLabel);
                    classTimes.Controls.Add(new Literal() { Text = "<br/>" });
                    classTimes.Controls.Add(endDateLabel);

                    singleClassDiv.Controls.Add(classTimes);
                    singleClassDiv.Controls.Add(classDetails);
                    singleClassDiv.Controls.Add(classDates);


                    //show the classes
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }


        protected void newClass(object sender, EventArgs e)
        {
            Response.Redirect("AddClass.aspx");
        }
        protected void deleteClass(object sender, EventArgs e) {
            //need to change these vars to grab from hidden fields
            int classID = 3;
            int masterID = 6;

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Delete class from database if want to delete all instances

            strsql = "delete from EventMasterTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from EventDetailsTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCon.Close();

        }

        protected void editClass(object sender, EventArgs e) {
            Response.Redirect("EditClass.aspx");
        }
    }
}