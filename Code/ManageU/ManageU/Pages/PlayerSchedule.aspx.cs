﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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
    }
}