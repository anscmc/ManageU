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
    public partial class ChangePassword : System.Web.UI.Page
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
        }

        protected void updatePassButton_Click(object sender, EventArgs e)
        {
            string strsql = "";
            bool userFound = false;
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlDataReader objRS;
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            strsql = "Select * from UserTable where userEmail='" + email.Text + "' and userPassword='" + oldPassword.Text + "'";

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();

            if (objRS.HasRows)
            {

                userFound = true;

            }

            objCmd = null;
            objRS.Close();

            if (userFound == true)
            {
                strsql = "Update UserTable set userPassword = '" + newPassword.Text + "' where userEmail= '" + email.Text + "' and userPassword='" + oldPassword.Text + "'";
                objCmd = new SqlCommand(strsql, objCon);
                objCmd.ExecuteNonQuery();
                objCmd = null;
                objCon.Close();
                Response.Redirect("~/Pages/Landing.aspx");
            }

            else {
                errLabel.Style.Add("display", "inline-block");
                objCmd = null;
                objCon.Close();
            }


        }
    }
}