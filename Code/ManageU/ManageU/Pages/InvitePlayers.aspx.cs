using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ManageU.Pages
{
    public partial class InvitePlayers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }


        protected void inviteButton_Click(object sender, EventArgs e)
        {
            userExistsErr.InnerText = "You have already invited the following players: ";
            //loop here with incrementing id's (store id count in session from index change function?
            int num = Int32.Parse(numPlayersHidden.Value);
            string successfullyAdded = ""; 

            List<string> playerEmails = new List<string>();

            for(int i = 1; i <= num; i++)
            {
                switch (i)
                {
                    case 1:
                        if(email1.Text != "")
                        {
                            playerEmails.Add(email1.Text);
                        }
                        break;
                    case 2:
                        if (email2.Text != "")
                        {
                            playerEmails.Add(email2.Text);
                        }
                        break;
                    case 3:
                        if (email3.Text != "")
                        {
                            playerEmails.Add(email3.Text);
                        }
                        break;
                    case 4:
                        if (email4.Text != "")
                        {
                            playerEmails.Add(email4.Text);
                        }
                        break;
                    case 5:
                        if (email5.Text != "")
                        {
                            playerEmails.Add(email5.Text);
                        }
                        break;
                    case 6:
                        if (email6.Text != "")
                        {
                            playerEmails.Add(email6.Text);
                        }
                        break;
                    case 7:
                        if (email7.Text != "")
                        {
                            playerEmails.Add(email7.Text);
                        }
                        break;
                    case 8:
                        if (email8.Text != "")
                        {
                            playerEmails.Add(email8.Text);
                        }
                        break;
                    case 9:
                        if (email9.Text != "")
                        {
                            playerEmails.Add(email9.Text);
                        }
                        break;
                    case 10:
                        if (email10.Text != "")
                        {
                            playerEmails.Add(email10.Text);
                        }
                        break;
                    default:
                        break;
                }
            }

            //for each player email
            userExistsErr.Style.Add("display", "none");
            foreach (string uEmail in playerEmails)
            {
                SqlConnection objCon3 = default(SqlConnection);
                SqlCommand objCmd3 = default(SqlCommand);
                objCon3 = new SqlConnection();
                objCon3.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
                objCon3.Open();
                objCmd3 = new SqlCommand();
                objCmd3.Connection = objCon3;
                SqlDataReader objRS3;
                string strsql3 = "";

                strsql3 = "Select * from UserTable where userEmail='" + uEmail + "'";
                objCmd3 = new SqlCommand(strsql3, objCon3);
                objRS3 = objCmd3.ExecuteReader();
                if (objRS3.HasRows)
                {
                    if(userExistsErr.InnerText == "You have already invited the following players: ")
                    {
                        userExistsErr.InnerText = userExistsErr.InnerText + uEmail;
                    }
                    else{
                        userExistsErr.InnerText = userExistsErr.InnerText + ", " + uEmail;
                    }
                    userExistsErr.Style.Add("display", "inline-block");
                }
                else
                {
                    
                        string password = System.Web.Security.Membership.GeneratePassword(10, 0);

                        SqlConnection objCon = default(SqlConnection);
                        SqlConnection objCon2 = default(SqlConnection);
                        SqlCommand objCmd = default(SqlCommand);
                        SqlCommand objCmd2 = default(SqlCommand);
                        objCon = new SqlConnection();
                        objCon2 = new SqlConnection();
                        objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
                        objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
                        objCon.Open();
                        objCmd = new SqlCommand();
                        objCmd2 = new SqlCommand();
                        objCmd.Connection = objCon;
                        objCmd2.Connection = objCon2;
                        SqlDataReader objRS;
                        string strsql = "";
                        string strsql2 = "";
                        int userIDFromTable;
                        int teamIDFromTable;
                        string coachUsername = HttpContext.Current.Session["Username"].ToString();

                        //insert new user into UserTable 

                        strsql = "insert into UserTable (userEmail,userPassword,userType) OUTPUT inserted.userID values (@userE, @userP, @userT);";
                        objCmd = new SqlCommand(strsql, objCon);

                        objCmd.Parameters.AddWithValue("userE", uEmail);
                        objCmd.Parameters.AddWithValue("userP", password);
                        objCmd.Parameters.AddWithValue("userT", "player");

                        userIDFromTable = (int)objCmd.ExecuteScalar();

                        objCmd = null;

                        objCon2.Open();
                        strsql2 = "select c.teamID from UserTable u join CoachTable c on c.userID = u.userID where u.userEmail = '" + coachUsername + "'";
                        objCmd2 = new SqlCommand(strsql2, objCon2);

                        objRS = objCmd2.ExecuteReader();
                        if (objRS.HasRows)
                        {
                            while (objRS.Read())
                            {
                                teamIDFromTable = Int32.Parse(objRS["teamID"].ToString());
                                //insert new player into PlayerTable

                                objCmd = new SqlCommand();
                                objCmd.Connection = objCon;
                                strsql = "insert into PlayerTable (userID,teamID,playerEmail) values (@userid, @teamid, @playerE);";
                                objCmd = new SqlCommand(strsql, objCon);

                                objCmd.Parameters.AddWithValue("userid", userIDFromTable);
                                objCmd.Parameters.AddWithValue("teamid", teamIDFromTable);
                                objCmd.Parameters.AddWithValue("playerE", uEmail);


                                objCmd.ExecuteNonQuery();
                            }

                        }

                        objRS.Close();
                        objCmd2 = null;
                        objCmd = null;
                        objCon2.Close();
                        objCon.Close();

                        //send email to player

                        MailMessage mail = new MailMessage();
                        mail.To.Add(uEmail);
                        mail.From = new MailAddress("manageuapp@gmail.com");
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential
             ("manageuapp@gmail.com", "Seniordes2017");
                        //client.Host = "localhost";
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        mail.Subject = "ManageU Invitation";
                        mail.Body = "You have been invited by " + coachUsername + " to join ManageU. Your username is: " + uEmail + " and your temporary password is: " + password + " Click <a href=\"http://localhost:57074/ChangePassword.aspx\">here</a> to change your password and log into the app";
                        mail.IsBodyHtml = true;
                        client.Send(mail);

                    if(successfullyAdded == "")
                    {
                        successfullyAdded = uEmail;
                    }
                    else
                    {
                        successfullyAdded = ", " + uEmail;
                    }

                    hiddenSuccess.Value = "You have successfully invited the following players: " + successfullyAdded;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessFunction", "alertSuccess()", true);
                }

                
            }


        }


    }
}
