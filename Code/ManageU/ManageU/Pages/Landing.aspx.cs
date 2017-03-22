using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ManageU.Pages
{
    public partial class Landing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserType"] = "";
            HttpContext.Current.Session["Username"] = "";
            HttpContext.Current.Session["TeamID"] = "";
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //STOPPED HERE************************
            strsql = "Select * from UserTable where userEmail='" + Email.Text + "' and userPassword='" + Password.Text + "'";

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if(objRS.HasRows)
            {
                while (objRS.Read())
                {
                    if (objRS["userType"].ToString() == "player")
                    {
                        HttpContext.Current.Session["Username"] = Email.Text;
                        HttpContext.Current.Session["UserType"] = objRS["userType"].ToString();
                        Response.Redirect("TeamProfile.aspx");
                    }
                    else if (objRS["userType"].ToString() == "coach")
                    {
                        HttpContext.Current.Session["Username"] = Email.Text;
                        HttpContext.Current.Session["UserType"] = objRS["userType"].ToString();
                        Response.Redirect("TeamProfile.aspx");
                    }

                }


            }
            else
            {
                //call javascript function to show incorrect username or password

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:loginError(); ", true);
            }

            objRS.Close();
            objCon.Close();
        }
    }
}
