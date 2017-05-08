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
            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {
                System.Web.UI.HtmlControls.HtmlGenericControl hide1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("meetings");

                hide1.Style.Add("display", "none");
                System.Web.UI.HtmlControls.HtmlGenericControl hide2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("invite");

                hide2.Style.Add("display", "none");
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                editButton.Style.Add("display", "block");
                System.Web.UI.HtmlControls.HtmlGenericControl hide = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("mySched");
                hide.Style.Add("display", "none");
                System.Web.UI.HtmlControls.HtmlGenericControl hide3 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("att");

                hide3.Style.Add("display", "none");
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            editTeam.Visible = false;
            editCoach.Visible = false;
            editLink.Visible = false;
            saveTeamInfo.Style.Add("display", "none");
            cancel.Style.Add("display", "none");

            if (!IsPostBack)
            {
                loadInfo();
            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            editButton.Style.Add("display", "none");
            saveTeamInfo.Style.Add("display", "block");
            cancel.Style.Add("display", "block");
            teamDivision.Visible = false;
            teamConference.Visible = false;
            teamRecord.Visible = false;
            //teamLocation.Visible = false;
            coachInfo.Visible = false;
            linkInfo.Visible = false;
            editTeam.Visible = true;
            editCoach.Visible = true;
            editLink.Visible = true;
            profilePicUpload.Style.Add("display", "block");

        }

        protected void saveTeamInfoButton_Click(object sender, EventArgs e)
        {
            //int numEmails = Int32.Parse(hidden.Value);
            string division = divisionPicker.Value;
            string conference = conference2.Text;
            string wins = wins2.Text;
            string losses = losses2.Text;
            string location = city2.Text + "," + state2.Value;
            string schoolSite = schoolSite2.Text;
            string teamSite = siteTeam2.Text;

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            //Have to have set be actual values
            strsql = "Update TeamTable set division='" + division + "', conference='" + conference + "', wins='" + wins + "', losses='" + losses + "', city='" + city2.Text + "', state='" + state2.Value + "', schoolLink='" + schoolSite + "', teamLink='" + teamSite + "'  where teamId='" + HttpContext.Current.Session["TeamID"] + "'";

            objCon.Open();

            objCmd = new SqlCommand(strsql, objCon);
           objCmd.ExecuteNonQuery();

            if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                uploadPic();
            }

            teamDivision.Visible = true;
            teamConference.Visible = true;
            teamRecord.Visible = true;
            //teamLocation.Visible = true;
            coachInfo.Visible =true;
            linkInfo.Visible = true;
            saveTeamInfo.Style.Add("display", "none");
            cancel.Style.Add("display", "none");
            editButton.Style.Add("display", "block");
            profilePicUpload.Style.Add("display", "none");

            loadInfo();


        }

        public void loadInfo()
        {
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd2 = default(SqlCommand);
            objCon2 = new SqlConnection();
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd2 = new SqlCommand();
            objCmd2.Connection = objCon2;
            SqlDataReader objRS2;
            string strsql2 = "";
            strsql2 = "select * from TeamTable where teamID ='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
            objCon2.Open();

            objCmd2 = new SqlCommand(strsql2, objCon2);

            objRS2 = objCmd2.ExecuteReader();
            if (objRS2.HasRows)
            {
                while (objRS2.Read())
                {
                    teamName.Text = objRS2["university"].ToString() + " " + objRS2["sport"].ToString();
                    division.Text = objRS2["division"].ToString();
                    divisionPicker.Value = objRS2["division"].ToString();
                    conference.Text = objRS2["conference"].ToString();
                    conference2.Text = objRS2["conference"].ToString();
                    wins.Text = objRS2["wins"].ToString();
                    wins2.Text = objRS2["wins"].ToString();
                    losses.Text = objRS2["losses"].ToString();
                    losses2.Text = objRS2["losses"].ToString();
                    record.Text = objRS2["wins"].ToString() + "-" + objRS2["losses"].ToString();
                    location.Text = objRS2["city"].ToString() + ", " + objRS2["state"].ToString();
                    city2.Text = objRS2["city"].ToString();
                    state2.Value = objRS2["state"].ToString();
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

            strsql2 = "select * from CoachTable where teamId ='" + HttpContext.Current.Session["TeamID"].ToString() + "'";

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
            
            objCmd2 = null;
            objRS2.Close();
            objCon2.Close();


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


        protected void cancel_Click(object sender, EventArgs e)
        {
            editButton.Style.Add("display", "block");
            saveTeamInfo.Style.Add("display", "none");
            cancel.Style.Add("display", "none");
            teamDivision.Visible = true;
            teamConference.Visible = true;
            teamRecord.Visible = true;
            //teamLocation.Visible = false;
            coachInfo.Visible = true;
            linkInfo.Visible = true;
            editTeam.Visible = false;
            editCoach.Visible = false;
            editLink.Visible = false;
        }
        
    }
}