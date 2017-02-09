using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ManageU.Pages
{
    public partial class TeamProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadInfo();
        }

        protected void invitePlayersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvitePlayers.aspx");
        }

        protected void goToRosterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Roster.aspx");
        }

        protected void goToMyInfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyInfo.aspx");
        }

        protected void editButtonClick(object sender, EventArgs e)
        {

        }

        protected void saveTeamInfoButton_Click(object sender, EventArgs e)
        {
            string division = division2.Text;
            string conference = conference2.Text;
            string wins = wins2.Text;
            string losses = losses2.Text;
            string location = location2.Text;
            string schoolSite = schoolSite2.Text;
            string teamSite = siteTeam2.Text;

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            //Have to have set be actual values
            strsql = "Update TeamTable set division='" + division + "', conference='" + conference + "', wins='" + wins + "', losses='" + losses + "', location='" + location + "', schoolLink='" + schoolSite + "', teamLink='" + teamSite + "'  where teamId='" + HttpContext.Current.Session["TeamID"] + "'";

            objCon.Open();

            objCmd = new SqlCommand(strsql, objCon);
            objCmd.ExecuteNonQuery();

            loadInfo();

        }

        public void loadInfo()
        {
            SqlConnection objCon = default(SqlConnection);
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlCommand objCmd2 = default(SqlCommand);
            objCon = new SqlConnection();
            objCon2 = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd2 = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd2.Connection = objCon2;
            SqlDataReader objRS;
            SqlDataReader objRS2;
            string strsql = "";
            string strsql2 = "";
            int teamIDFromTable;

            //if a coach is logged in
            if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                strsql = "select c.teamID from UserTable u join CoachTable c on c.userID = u.userID where u.userEmail = '" + HttpContext.Current.Session["Username"] + "'";
            }
            //if a player is logged in
            else
            {
                strsql = "select p.teamID from UserTable u join PlayerTable p on p.userID = u.userID where u.userEmail = '" + HttpContext.Current.Session["Username"] + "'";
            }
            objCon.Open();
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    teamIDFromTable = Int32.Parse(objRS["teamID"].ToString());
                    HttpContext.Current.Session["TeamID"] = teamIDFromTable;
                    strsql2 = "select * from TeamTable where teamId ='" + teamIDFromTable + "'";
                    objCon2.Open();

                    objCmd2 = new SqlCommand(strsql2, objCon2);

                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            teamName.InnerText = objRS2["university"].ToString() + " " + objRS2["sport"].ToString();
                            division.Text = objRS2["division"].ToString();
                            conference.Text = objRS2["conference"].ToString();
                            wins.Text = objRS2["wins"].ToString();
                            losses.Text = objRS2["losses"].ToString();
                            location.Text = objRS2["location"].ToString();
                            schoolSite.Text = objRS2["schoolLink"].ToString();
                            siteTeam.Text = objRS2["teamLink"].ToString();
                            //***still have to get head coach & head coach phone number & email
                        }
                    }

                    objCmd2 = null;
                    objRS2.Close();

                    strsql2 = "select * from CoachTable where teamId ='" + teamIDFromTable + "'";

                    objCmd2 = new SqlCommand(strsql2, objCon2);

                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            headCoach.Text = objRS2["coachFName"].ToString() + " " + objRS2["coachLName"].ToString();
                            coachNumber.Text = objRS2["coachNumber"].ToString();
                        }
                    }

                    objCmd2 = null;
                    objRS2.Close();
                    objCon2.Close();
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }
    }
}