﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace ManageU.Pages
{
    

    public partial class Roster : System.Web.UI.Page
    {
        List<string> playerIDs = new List<string>();
        List<string> playerEmails = new List<string>();
        List<CheckBox> checkboxes = new List<CheckBox>();
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
                System.Web.UI.HtmlControls.HtmlGenericControl hide3 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("att");

                hide3.Style.Add("display", "none");
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            HttpContext.Current.Session["testEmail"] = "";

            if (HttpContext.Current.Session["UserType"].ToString() == "player")
            {
                load();
            }
            else if (HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                load();
            }
            else
            {
                Response.Redirect("Landing.aspx");
            }

            if (!IsPostBack)
            {
                this.Session["emailList"] = "";
                this.Session["sessionEmails"] = "";
                
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
            playerInfo.InnerHtml = "";
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
                            playerIDs.Add(objRS2["userID"].ToString());
                            playerFName = objRS2["playerFName"].ToString();
                            playerLName = objRS2["playerLName"].ToString();
                            playerPos = objRS2["position"].ToString();
                            playerClass = objRS2["class"].ToString();
                            playerNum = objRS2["playerNumber"].ToString();
                            playerEmail = objRS2["playerEmail"].ToString();
                            playerEmails.Add(playerEmail);

                            
                            idNum = idNum + 1;
                            checkboxIdNum = checkboxIdNum + 1;

                    //hidden label = new label();
                    //label.text = playerUserID dynamic id
                    
                            Label lb1 = new Label();
                            lb1.Text = playerFName + " " + playerLName;

                            Label lb2 = new Label();
                            lb2.Text = playerClass;

                            Label lb3 = new Label();
                            lb3.Text = playerPos;

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
                            lb5.Attributes["style"] = "margin-bottom:10px;";

                            CheckBox emailCheck = new CheckBox();
                            emailCheck.ID = "check" + idNum.ToString();
                            emailCheck.InputAttributes.Add("class", "rosterCheck");
                            emailCheck.Text = "Add " + playerEmail + " to email list";

                            checkboxes.Add(emailCheck);

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
                            infoDiv.Attributes["style"] = "background-color:rgba(255,255,255,1);height:auto;max-width:500px;margin: 0 auto;";



                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            if (HttpContext.Current.Session["UserType"].ToString() == "coach")
                            {
                                infoDiv.Controls.Add(new Literal() { Text = "<a onclick='return playerClasses(" + idNum.ToString() + ")'><i class='fa fa-calendar fontA' aria-hidden='true' runat='server' style='display:inline;color:black;font-size:40px;padding-right:20px;position:absolute;left:10px;top:10px;'></i></a>" });
                                infoDiv.Controls.Add(new Literal() { Text = "<a onclick='return deletePlayer(" + idNum.ToString() + ")'><i class='fa fa-minus-circle fontA' aria-hidden='true' style='display:inline;font-size:30px;color:#ba0047;padding-left:20px;position:absolute;right:10px;top:10px;'></i></a>" });
                            }
                            infoDiv.Controls.Add(lb1);
                            infoDiv.Controls.Add(new Literal() { Text = "<i class='fa fa-circle' aria-hidden='true' style='color:#ba9800;font-size:10px;padding:5px;'></i>" });
                            infoDiv.Controls.Add(lb4);
                            
                            //infoDiv.Controls.Add(lb6);
                            //infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            //infoDiv.Controls.Add(lb1);
                            //infoDiv.Controls.Add(lb4);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            //infoDiv.Controls.Add(new Literal() { Text = "<hr/>" });
                            infoDiv.Controls.Add(lb2);
                            infoDiv.Controls.Add(new Literal() { Text = "<i class='fa fa-circle' aria-hidden='true' style='color:#ba9800;font-size:10px;padding:5px;'></i>" });
                            //infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(lb3);
                            //infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            //infoDiv.Controls.Add(new Literal() { Text = "<hr/>" });
                            
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            infoDiv.Controls.Add(new Literal() { Text = "<span class='icon-bar' style='background-color:#ba9800 !important;width:75%;z-index:1000;'></span>" });
                            //infoDiv.Controls.Add(lb6);
                            infoDiv.Controls.Add(new Literal() { Text = "<br/>" });
                            //infoDiv.Controls.Add(lb5);

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
                    //infoDiv.Controls.Add(boxDiv);
                    
                        infoDiv.Controls.Add(emailCheck);
                    
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
            string playersToEmail = "";

            for(int i = 0; i < checkboxes.Count; i++)
            {
                if (checkboxes[i].Checked)
                {
                    if (playersToEmail == "")
                    {
                        playersToEmail = playerEmails.ElementAt(i);
                    }
                    else
                    {
                        playersToEmail = playersToEmail + "," + playerEmails.ElementAt(i);
                    }
                }
                
            }
            
         

            HttpContext.Current.Session["RosterEmailAddresses"] = playersToEmail;
            HttpContext.Current.Session["FromRosterToContact"] = "y";
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

        protected void playerSched(object sender, EventArgs e)
        {
            string userID = playerIDs.ElementAt(Int32.Parse(calHiddenField.Value) - 1);
            HttpContext.Current.Session["PlayerIDForSched"] = userID;
            HttpContext.Current.Session["FromRoster"] = "y";
            Response.Redirect("PlayerSchedule.aspx");
        }

        protected void deleteP(object sender, EventArgs e)
        {
            
            string userID = playerIDs.ElementAt(Int32.Parse(deleteHiddenField.Value) - 1);

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

            load();
        }

        protected void xButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/TeamProfile.aspx");
        }
    }
}