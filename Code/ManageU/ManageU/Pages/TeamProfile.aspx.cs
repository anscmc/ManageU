using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ManageU.Pages
{
    public partial class TeamProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            editTeam.Visible = false;
            editCoach.Visible = false;
            editLink.Visible = false;
            saveTeamInfo.Visible = false;

            if (!IsPostBack)
            {
                loadInfo();
            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = false;
            saveTeamInfo.Visible = true;
            teamInfo.Visible = false;
            coachInfo.Visible = false;
            linkInfo.Visible = false;

            editTeam.Visible = true;
            editCoach.Visible = true;
            editLink.Visible = true;

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

            if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                uploadPic();
            }

            teamInfo.Visible = true;
            coachInfo.Visible =true;
            linkInfo.Visible = true;
            saveTeamInfo.Visible = false;
            editButton.Visible = true;

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
                    strsql2 = "select * from TeamTable where teamID ='" + teamIDFromTable + "'";
                    objCon2.Open();

                    objCmd2 = new SqlCommand(strsql2, objCon2);

                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            teamName.Text = objRS2["university"].ToString() + " " + objRS2["sport"].ToString();
                            division.Text = objRS2["division"].ToString() + " | " + objRS2["conference"].ToString();
                            conference2.Text = objRS2["conference"].ToString();
                            wins.Text = "Record" + objRS2["wins"].ToString();
                            wins2.Text = objRS2["wins"].ToString();
                            losses.Text = objRS2["losses"].ToString();
                            losses2.Text = objRS2["losses"].ToString();
                            location.Text = objRS2["location"].ToString();
                            location2.Text = objRS2["location"].ToString();
                            schoolSite.Attributes["href"] = objRS2["schoolLink"].ToString();
                            schoolSite2.Text = objRS2["schoolLink"].ToString();
                            siteTeam.Attributes["href"] = objRS2["teamLink"].ToString();
                            siteTeam2.Text = objRS2["teamLink"].ToString();
                            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
                            List<ListItem> files = new List<ListItem>();
                            foreach (string filePath in filePaths)
                            {
                                if (filePath == ("C:\\Users\\anscmc\\Desktop\\Senior Design\\ManageU\\ManageU\\Code\\ManageU\\ManageU\\Images" + objRS2["picPath"].ToString()))
                                {
                                    string fileName = Path.GetFileName(filePath);
                                    files.Add(new ListItem(fileName, "Images/" + fileName));
                                }

                            }
                            profilePicGrid.DataSource = files;
                            profilePicGrid.DataBind();
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
                            coachEmail.Text = objRS2["coachEmail"].ToString();
                        }
                    }

                    if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                    {
                        division2.Style.Add("display", "block");
                        conference2.Style.Add("display", "block");
                        wins2.Style.Add("display", "block");
                        losses2.Style.Add("display", "block");
                        location2.Style.Add("display", "block");
                        schoolSite2.Style.Add("display", "block");
                        siteTeam2.Style.Add("display", "block");
                        profilePicUpload.Style.Add("display", "block");
                        saveTeamInfo.Style.Add("display", "block");
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

        protected void uploadPic()
        {
            if (profilePicUpload.HasFile)
            {
                DateTime date = DateTime.Now;
                string dateString = date.ToString("yyyyMMddHHmmssfff");
                string fileName = dateString + ".jpg";

                //upload path to database
                string strsql = "";
                SqlConnection objCon = default(SqlConnection);
                SqlCommand objCmd = default(SqlCommand);
                objCon = new SqlConnection();
                objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

                //Have to have set be actual values
                strsql = "Update TeamTable set picPath='" + fileName + "' where teamID=" + HttpContext.Current.Session["TeamID"].ToString();

                objCon.Open();

                objCmd = new SqlCommand(strsql, objCon);
                objCmd.ExecuteNonQuery();

                objCmd = null;
                objCon.Close();

                //upload to folder   

                //Path.GetFileName(profilePicUpload.PostedFile.FileName);
                profilePicUpload.PostedFile.SaveAs(Server.MapPath("Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);


            }
        }
    }
}