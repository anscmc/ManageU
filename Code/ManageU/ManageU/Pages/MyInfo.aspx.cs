using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ManageU.Pages
{
    public partial class MyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["UserType"].ToString() == "player")
                {
                    numLabel.Visible = false;
                    numLabel.Disabled = true;
                    phoneNum.Visible = false;
                    phoneNum.Enabled = false;
                }
                else if(HttpContext.Current.Session["UserType"].ToString() == "coach")
                {
                    positionLabel.Visible = false;
                    positionLabel.Disabled = true;
                    position.Visible = false;
                    position.Enabled = false;
                    classLabel.Visible = false;
                    classLabel.Disabled = true;
                    playerClass.Visible = false;
                    playerClass.Enabled = false;
                    playerNumLabel.Visible = false;
                    playerNumLabel.Disabled = true;
                    playerNum.Visible = false;
                    playerNum.Enabled = false;
                }
                else
                {
                    Response.Redirect("Landing.aspx");
                }

                    loadInfo();
            }
        }

        protected void loadInfo()
        {
            string strsql = "";
            int userIDFromTable;
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            //first need to get userID from UserTable to find user in either PlayerTable or CoachTable
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd2 = default(SqlCommand);
            SqlDataReader objRS2;
            objCon2 = new SqlConnection();
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];



            objCon.Open();

            strsql = "Select userID from UserTable where userEmail='" + HttpContext.Current.Session["Username"].ToString() + "'";

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    userIDFromTable = Int32.Parse(objRS[0].ToString());

                    if (HttpContext.Current.Session["UserType"].ToString() == "player")
                    {
                        //get info from PlayerTable and place it in textboxes
                        strsql = "Select * from PlayerTable where userID ='" + userIDFromTable + "'";

                        objCon2.Open();
                        objCmd2 = new SqlCommand(strsql, objCon2);

                        objRS2 = objCmd2.ExecuteReader();

                        if (objRS2.HasRows)
                        {
                            while (objRS2.Read())
                            {
                                fName.Text = objRS2["playerFName"].ToString();
                                lName.Text = objRS2["playerLName"].ToString();
                                position.Text = objRS2["position"].ToString();
                                playerClass.Text = objRS2["class"].ToString();
                                playerNum.Text = objRS2["playerNumber"].ToString();
                            }
                        }

                        objCmd = null;
                        objRS2.Close();
                        objCon2.Close();
                    }
                    else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                    {
                        //get info from CoachTable and place it in textboxes
                        strsql = "Select * from CoachTable where userID ='" + userIDFromTable + "'";
                        objCon2.Open();
                        objCmd2 = new SqlCommand(strsql, objCon2);

                        objRS2 = objCmd2.ExecuteReader();

                        if (objRS2.HasRows)
                        {
                            while (objRS2.Read())
                            {
                                fName.Text = objRS2["coachFName"].ToString();
                                lName.Text = objRS2["coachLName"].ToString();
                                phoneNum.Text = objRS2["coachNumber"].ToString();
                            }
                        }

                        objCmd = null;
                        objRS2.Close();
                        objCon2.Close();
                    }
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }

        protected void saveInfoButton_Click(object sender, EventArgs e)
        {
            string firstName = fName.Text;
            string lastName = lName.Text;
            string number = phoneNum.Text;
            string playerPosition = position.Text;
            string pClass = playerClass.Text;
            string pNum = playerNum.Text;

            int userIDFromTable;

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            //first need to get userID from UserTable to find user in either PlayerTable or CoachTable
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd2 = default(SqlCommand);
            SqlDataReader objRS;
            objCon2 = new SqlConnection();
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            strsql = "Select userID from UserTable where userEmail='" + HttpContext.Current.Session["Username"].ToString() + "'";

            objCon2.Open();

            objCmd2 = new SqlCommand(strsql, objCon2);

            objRS = objCmd2.ExecuteReader();

            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    userIDFromTable = Int32.Parse(objRS[0].ToString());

                    objCon.Open();
                    objCmd = new SqlCommand();
                    objCmd.Connection = objCon;

                    if (HttpContext.Current.Session["UserType"].ToString() == "player")
                    {
                        //Update info in PlayerTable
                        strsql = "Update PlayerTable set playerFName='" + firstName + "', playerLName='" + lastName + "', position='" + playerPosition + "', class='" + pClass + "', playerNumber ='" + pNum + "' where userID= '" + userIDFromTable + "'";
                        objCmd = new SqlCommand(strsql, objCon);

                        objCmd.ExecuteNonQuery();
                    }
                    else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                    {

                        //Update info in CoachTable

                        strsql = "Update CoachTable set coachFName='" + firstName + "', coachLName='" + lastName + "', coachNumber='" + number + "' where userID= '" + userIDFromTable + "'";
                        objCmd = new SqlCommand(strsql, objCon);

                        objCmd.ExecuteNonQuery();
                    }

                    objCmd = null;
                    objCon.Close();

                }
            }

            objCmd2 = null;
            objRS.Close();
            objCon2.Close();

            loadInfo();
        }
    }
}