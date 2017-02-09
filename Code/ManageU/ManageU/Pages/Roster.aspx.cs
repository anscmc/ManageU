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
    public partial class Roster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            SqlConnection objCon2 = default(SqlConnection);
            SqlCommand objCmd2 = default(SqlCommand);
            objCon = new SqlConnection();
            objCon2 = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCon2.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd2 = new SqlCommand();
            objCmd2.Connection = objCon2;
            SqlDataReader objRS;
            SqlDataReader objRS2;
            string strsql = "";
            string strsql2 = "";
            int teamIDFromTable;
            string coachUsername = HttpContext.Current.Session["Username"].ToString();
            string playerFName = "";
            string playerLName = "";
            string playerPos = "";
            string playerClass = "";
            string playerNum = "";

            objCon.Open();
            strsql = "select c.teamID from UserTable u join CoachTable c on c.userID = u.userID where u.userEmail = '" + coachUsername + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    teamIDFromTable = Int32.Parse(objRS["teamID"].ToString());
                    //find all players associated with that team
                    objCon2.Open();
                    strsql2 = "select * from PlayerTable where teamID='" + teamIDFromTable + "'";
                    objCmd2 = new SqlCommand(strsql2, objCon2);
                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            //create divs with info
                            //will just have to store these in the front end labels/textboxes
                            playerFName = objRS2["playerFName"].ToString();
                            playerLName = objRS2["playerLName"].ToString();
                            playerPos = objRS2["position"].ToString();
                            playerClass = objRS2["class"].ToString();
                            playerNum = objRS2["playerNumber"].ToString();

                            Label1.InnerText = playerFName;
                        }

                    }
                    objRS2.Close();
                }

            }

            objRS.Close();
            objCmd = null;
            objCmd2 = null;
            objCon2.Close();
            objCon.Close();


        }
    }
}