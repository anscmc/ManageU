using System;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ManageU.Pages
{
    

    public partial class Roster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpContext.Current.Session["testEmail"] = "";

            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {

            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {

            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            if (!IsPostBack)
            {
                this.Session["emailList"] = "";
                this.Session["sessionEmails"] = "";
                load();
            }
        }

        protected void load()
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
            string playerEmail = "";
            int idNum = 0;
            int checkboxIdNum = 0;
            string emailString = "";

                    //find all players associated with that team
                    objCon2.Open();
                    strsql2 = "select * from PlayerTable where teamID='" + HttpContext.Current.Session["TeamID"].ToString() + "'";
                    objCmd2 = new SqlCommand(strsql2, objCon2);
                    objRS2 = objCmd2.ExecuteReader();
                    if (objRS2.HasRows)
                    {
                        while (objRS2.Read())
                        {
                            //playerUserID = objRS2["userID"].ToString();
                            playerFName = objRS2["playerFName"].ToString();
                            playerLName = objRS2["playerLName"].ToString();
                            playerPos = objRS2["position"].ToString();
                            playerClass = objRS2["class"].ToString();
                            playerNum = objRS2["playerNumber"].ToString();
                            playerEmail = objRS2["playerEmail"].ToString();

                            
                            idNum = idNum + 1;
                            checkboxIdNum = checkboxIdNum + 1;

                            //hidden label = new label();
                            //label.text = playerUserID dynamic id

                            Label lb1 = new Label();
                            lb1.Text = playerFName + " ";

                            Label lb2 = new Label();
                            lb2.Text = "Class: " + playerClass;

                            Label lb3 = new Label();
                            lb3.Text = "Position: " + playerPos;

                            Label lb4 = new Label();
                            lb4.Text = "#" + playerNum;

                            Label lb5 = new Label();
                            lb5.Text = playerEmail;
                            this.Session["sessionEmails"] = this.Session["sessionEmails"] + lb5.Text.ToString()+ ";";

                            Label lb6 = new Label();
                            lb6.Text = "Hidden Text";
                            lb6.ForeColor = System.Drawing.Color.White;
                            /*emails.InnerText = this.Session["sessionEmails"].ToString();*/

                            lb5.Attributes["id"] = "lbID" + idNum.ToString() + ";";
                            lb1.Attributes["style"] = "padding:10px; bottom:10px;";
                            lb5.Attributes["style"] = "margin-bottom:10px;";

                            CheckBox emailCheck = new CheckBox();
                            emailCheck.ID = "check" + idNum.ToString();
                            emailCheck.InputAttributes.Add("class", "rosterCheck");

                    //HtmlGenericControl xButton =
                    //new HtmlGenericControl("button");

                    //xButton.Attributes["type"] = "button";
                    //xButton.Attributes["ID"] = "xButton" + idNum.ToString() + ";";
                    //xButton.Attributes["class"] = "xButtonCSS";
                    //xButton.Attributes["runat"] = "server";
                    //xButton.InnerText = "";
                    //xButton.Attributes["OnClientClick"] = "return false";
                    //xButton.Attributes["OnServerClick"] = "xButtonClick";

                    //xButton.Attributes["OnClientClick"] = "xButtonClick";
                    //xButton.Attributes.Add("clientclick", "return false");

                            HtmlGenericControl calButton =
                            new HtmlGenericControl("button");

                            calButton.Attributes["type"] = "button";
                            calButton.Attributes["ID"] = "calButton" + idNum.ToString() + ";";
                            calButton.Attributes["class"] = "calButtonCSS";
                            calButton.Attributes["runat"] = "server";
                            calButton.InnerText = "";
                            calButton.Attributes["OnClientClick"] = "return false";
                            calButton.Attributes["OnServerClick"] = "xButtonClick";
                            //xButton.Attributes["OnClientClick"] = "xButtonClick";
                            //xButton.Attributes.Add("clientclick", "return false");

                            HtmlGenericControl infoDiv =
                            new HtmlGenericControl("div");

                            infoDiv.Attributes["id"] = "rosterContent";
                            infoDiv.Attributes["class"] = "col-sm-4 infoDiv";
                            infoDiv.Attributes["runat"] = "server";
                            //10px for padding not 10??? --------------->
                            infoDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:225px;max-width:500px;margin: 0 auto;padding:10";
                            infoDiv.Attributes["onclick"] = "infoDivClick()";


                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb6);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb1);
                            infoDiv.Controls.Add(lb4);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(new Literal() { Text = "<hr/>" });
                            infoDiv.Controls.Add(lb2);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb3);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(new Literal() { Text = "<hr/>" });
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb6);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb5);

                            HtmlGenericControl boxDiv =
                            new HtmlGenericControl("div");

                            boxDiv.Attributes["id"] = "rosterCheckBox" + checkboxIdNum.ToString();
                            boxDiv.Attributes["class"] = "rosterCheckBox";
                            boxDiv.Attributes["runat"] = "server";

                            HtmlGenericControl boxDiv2 =
                            new HtmlGenericControl("div");

                            boxDiv2.Attributes["id"] = "calDiv" + checkboxIdNum.ToString();
                            boxDiv2.Attributes["class"] = "calDiv";
                            boxDiv2.Attributes["runat"] = "server";
                    //boxDiv.Attributes["style"] = "background-color:rgb(255,255,255);padding:2px;border:1px solid black;border-radius:5px;height:20px;width:20px;line-height:20px;text-align:center;float:right;padding:0;box-shadow: 0 0 10px #000;font-family:'Microsoft Yahei';";

                    //Label checkX = new Label();
                    //checkX.ForeColor = System.Drawing.ColorTranslator.FromHtml("#008CBA");
                    //checkX.Font.Size = 27;
                    //checkX.Text = "X";
                    //checkX.Visible = false;

                    //CheckBox emailBox = new CheckBox();
                    //emailBox.Attributes["id"] = "checkboxID" + checkboxIdNum.ToString();
                    //emailBox.Attributes["runat"] = "server";
                    //emailBox.Attributes["AutoPostBack"] = "True";
                    //emailBox.Attributes["OnCheckedChanged"] = "selectAll";

                    //if (selectAllBox.Checked == true)
                    //{
                    //    emailBox.Checked = true;
                    //}
                    //else
                    //{
                    //    emailBox.Checked = false;
                    //}

                    /*boxDiv.Controls.Add(emailBox);*/
                            playerInfo.Controls.Add(infoDiv);
                            infoDiv.Controls.Add(boxDiv);
                            boxDiv.Controls.Add(emailCheck);
                            //boxDiv2.Controls.Add(calButton);
                            //boxDiv.Controls.Add(checkX);
                            //playerInfo.Controls.Add(boxDiv);

                            //if (emailBox.Checked == true)
                            //{
                            //    emailString = emailString + playerEmail;
                            //}
                            //emails.InnerText = emailString;
                }

                    }
                    objRS2.Close();



            objCmd2 = null;
            objCon2.Close();


        }
        protected void selectAll(object sender, EventArgs e)
        {
            load();
        }
        protected void emailClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Contact.aspx");
        }

        protected void infoDivClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateMeeting.aspx");
        }

        //protected void xButtonClick(object sender, EventArgs e)
        //{
        //    if(xCheck == 1)
        //    {
        //        xButton.InnerText = "X";
        //        xCheck = 0;
        //    }
        //    else
        //    {
        //        xButton.InnerText = "";
        //        xCheck = 1;
        //    }
        //}
        protected void deletePlayerButton_Click(object sender, EventArgs e)
        {
            //

            string userID = "55";

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            strsql = "delete from PlayerTable where userID='" + userID + "'";
            objCmd = new SqlCommand(strsql, objCon);
            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from UserTable where userId='" + userID + "'";
            objCmd = new SqlCommand(strsql, objCon);
            objCmd.ExecuteNonQuery();

            objCmd = null;
            objCon.Close();
        }

        protected void xButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/TeamProfile.aspx");
        }
    }
}