using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ManageU.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //STILL HAVE TO:
        //1. User Table needs to have a userType column
        protected void registerButton_Click(object sender, EventArgs e)
        {
            string coachEmail;
            string coachPassword;
            string coachFName;
            string coachLName;
            string coachNumber;
            string university;
            string sport;
            string strsql = "";
            string type = "coach";
            int userIDFromTable;
            int teamIDFromTable;
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            DataSet ds = new DataSet();
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            coachEmail = email.Text;
            coachPassword = pass1.Text;
            coachFName = first.Text;
            coachLName = last.Text;
            coachNumber = phone.Text;
            university = univ.Text;
            sport = sportType.Value;

            //check to see if fields are blank
            //If they are, display error messages
            //if (coachEmail == "" || coachPassword == "" || coachFName == "" || coachLName == "" || university == "" || sport == "")
            //{
            //    if (coachEmail == "")
            //    {
            //        emailNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        emailNull.Style.Add("display", "none");
            //    }
            //    if (coachPassword == "")
            //    {
            //        passwordNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        passwordNull.Style.Add("display", "none");
            //    }
            //    if (coachFName == "")
            //    {
            //        fNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        fNull.Style.Add("display", "none");
            //    }
            //    if (coachLName == "")
            //    {
            //        lNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        lNull.Style.Add("display", "none");
            //    }
            //    if (university == "")
            //    {
            //        univNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        univNull.Style.Add("display", "none");
            //    }
            //    if (sport == "")
            //    {
            //        sportNull.Style.Add("display", "inline-block");
            //    }
            //    else {
            //        sportNull.Style.Add("display", "none");
            //    }

            //}


            ////If they are not, register
            //else {
                objCon.Open();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon;

                //Register coach in user table

                strsql = "insert into UserTable (userEmail,userPassword,userType) OUTPUT inserted.userID values (@userE, @userP, @userT);";
                objCmd = new SqlCommand(strsql, objCon);

                objCmd.Parameters.AddWithValue("userE", coachEmail);
                objCmd.Parameters.AddWithValue("userP", coachPassword);
                objCmd.Parameters.AddWithValue("userT", type);

                userIDFromTable = (int)objCmd.ExecuteScalar();


                //Register team in team table

                objCmd = null;

                objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                strsql = "insert into TeamTable (university,sport) OUTPUT inserted.teamID values (@un, @sp);";
                objCmd = new SqlCommand(strsql, objCon);

                objCmd.Parameters.AddWithValue("un", university);
                objCmd.Parameters.AddWithValue("sp", sport);

                teamIDFromTable = (int)objCmd.ExecuteScalar();

                //Register coach in coach table
                //HAVE TO MAKE COACHID FIELD IN COACH TABLE THAT IS PRIMARY AND HAVE COACHID AND TEAMID AS FOREIGN KEYS ONLY
                objCmd = null;

                objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                strsql = "insert into CoachTable (userID,teamID,coachEmail,coachFName,coachLName,coachNumber) values (@userid, @teamid, @coachE, @coachF, @coachL, @coachNum);";
                objCmd = new SqlCommand(strsql, objCon);

                objCmd.Parameters.AddWithValue("userid", userIDFromTable);
                objCmd.Parameters.AddWithValue("teamid", teamIDFromTable);
                objCmd.Parameters.AddWithValue("coachE", coachEmail);
                objCmd.Parameters.AddWithValue("coachF", coachFName);
                objCmd.Parameters.AddWithValue("coachL", coachLName);
                objCmd.Parameters.AddWithValue("coachNum", coachNumber);

                objCmd.ExecuteNonQuery();

                objCmd = null;
                objCon.Close();

            Response.Redirect("Landing.aspx");
           // }
        }
    }
}