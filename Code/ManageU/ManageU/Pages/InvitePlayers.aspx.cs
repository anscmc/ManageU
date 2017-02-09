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
            
        }

        protected void inviteButton_Click(object sender, EventArgs e)
        {
            string emails = emailAddresses.Text;

            char[] delimiterChars = { ',', ':', '\t', ';' };

            string[] playerEmails = emails.Split(delimiterChars);

            //for each player email

            foreach (string email in playerEmails)
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

                objCmd.Parameters.AddWithValue("userE", email);
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
                        objCmd.Parameters.AddWithValue("playerE", email);


                        objCmd.ExecuteNonQuery();
                    }

                }

                objRS.Close();
                objCmd2 = null;
                objCmd = null;
                objCon2.Close();
                objCon.Close();

                //send email to player

                //MailMessage mail = new MailMessage("jennifer.moran2017@gmail.com", emails);
                //SmtpClient client = new SmtpClient();
                //client.Port = 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = true;
                //client.Host = "localhost";
                ////client.Host = "smtp.isp.com";
                //mail.Subject = "This is a test";
                //mail.Body = "This is my test email body";
                //client.Send(mail);
                //sendEmail("Test email", "This is the body");
                //SendMail("moran014@knights.gannon.edu", "Test Body", "Test");
            }
            Response.Redirect("~/Pages/TeamProfile.aspx");
        }

        private bool SendMail(string from, string body, string subject)
        {

            string mailServerName = "localhost";
            MailMessage message = new MailMessage(from, "jennifer.moran2017@yahoo.com", subject, body);
            SmtpClient mailClient = new SmtpClient();
            mailClient.Host = mailServerName;
            mailClient.Send(message);
            message.Dispose();

            return true;
        }

        private static void sendEmail(string subject, string body)
        {
            Console.WriteLine("Sending Email to " + "moran014@knights.gannon.edu");

            //try
            //{
            MailMessage mm = new MailMessage("jennifer.moran2017@yahoo.com", "moran014@knights.gannon.edu");
            mm.Subject = subject;
            mm.Body = body;

            SmtpClient client = new SmtpClient("LOCALHOST", 25);
            client.Send(mm);
            //}
            //catch (Exception ex)
            //{
            //    File.WriteAllText(Settings.Default.LogFile + "emailerror.txt", "Error sending email: " + ex.Message + " Original Error:" + body);
            //    throw ex;
            //}
        }
    }
}