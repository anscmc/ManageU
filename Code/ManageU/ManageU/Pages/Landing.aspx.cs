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
            string strsql2 = "";
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd2 = default(SqlCommand);
            SqlDataReader objRS2;
            objCon2 = new SqlConnection();
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //STOPPED HERE************************
            strsql = "Select * from UserTable where userEmail='" + Email.Text + "' and userPassword='" + Password.Text + "'";

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {

                while (objRS.Read())
                {
                    if (objRS["userType"].ToString() == "player")
                    {
                        //get teamID from table to store in session
                        objCon2.Open();
                        objCmd2 = new SqlCommand();
                        objCmd2.Connection = objCon2;
                        strsql2 = "Select p.teamID from UserTable u join PlayerTable p on p.userID = u.userID";

                        objCmd2 = new SqlCommand(strsql2, objCon2);

                        objRS2 = objCmd2.ExecuteReader();

                        if (objRS2.HasRows)
                        {
                            while (objRS2.Read())
                            {
                                HttpContext.Current.Session["TeamID"] = objRS2["teamID"];
                            }
                        }

                        objCmd2 = null;
                        objRS2.Close();
                        objCon2.Close();

                        HttpContext.Current.Session["UserID"] = objRS["userID"].ToString();
                        HttpContext.Current.Session["Username"] = Email.Text;
                        HttpContext.Current.Session["UserType"] = objRS["userType"].ToString();
                        Response.Redirect("TeamProfile.aspx");
                    }
                    else if (objRS["userType"].ToString() == "coach")
                    {
                        //get teamID from table to store in session
                        objCon2.Open();
                        objCmd2 = new SqlCommand();
                        objCmd2.Connection = objCon2;

                        strsql2 = "Select c.teamID from UserTable u join CoachTable c on c.userID = u.userID";

                        objCmd2 = new SqlCommand(strsql2, objCon2);

                        objRS2 = objCmd2.ExecuteReader();

                        if (objRS2.HasRows)
                        {
                            while (objRS2.Read())
                            {
                                HttpContext.Current.Session["TeamID"] = objRS2["teamID"];
                            }
                        }

                        objCmd2 = null;
                        objRS2.Close();
                        objCon2.Close();

                        HttpContext.Current.Session["UserID"] = objRS["userID"].ToString();
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

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }

    }
}
