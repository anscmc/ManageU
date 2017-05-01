using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //emailAddresses.Text = this.Session["sessionEmails"].ToString();
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
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

                if (Session["FromRosterToContact"] != null)
                {
                    if (HttpContext.Current.Session["FromRosterToContact"].ToString() == "y")
                    {
                        emailAddresses.Text = HttpContext.Current.Session["RosterEmailAddresses"].ToString();
                    }
                    else if (HttpContext.Current.Session["FromRosterToContact"].ToString() == null)
                    {
                        emailAddresses.Text = "";
                    }
                    else
                    {
                        emailAddresses.Text = "";
                    }
                }
                    
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }
        }
        protected void emailButton_Click(object sender, EventArgs e)
        {
            string emails = emailAddresses.Text;
            string[] emailsSplit = emails.Split(',');
            for(int i = 0; i < emailsSplit.Length; i++)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(emailsSplit[i]);
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
                mail.Subject = messageSubject.Text;
                mail.Body = messageBody.Text;
                mail.IsBodyHtml = true;
                client.Send(mail);
                
            }

            Response.Write("<script>alert('Your message has been sent!');</script>");
            HttpContext.Current.Session["FromRosterToContact"] = "n";
            emailAddresses.Text = "";
            messageSubject.Text = "";
            messageBody.Text = "";

        }
    }
}