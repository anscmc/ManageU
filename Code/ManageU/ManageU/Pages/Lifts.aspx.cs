﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class Lifts : System.Web.UI.Page
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
            loadLifts();
        }

        protected void loadLifts()
        {
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            SqlDataReader objRS;
            string strsql = "";

            strsql = "select * from LiftTable where teamID ='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            objCon.Open();

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    //show list of workout names, divs should be clickable
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }

        protected void createLiftButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLift.aspx");
        }
    }
}