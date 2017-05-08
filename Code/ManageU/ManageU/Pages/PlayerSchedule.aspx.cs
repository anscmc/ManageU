using System;
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
    public partial class PlayerSchedule : System.Web.UI.Page
    {
        List<string> classInfo = new List<string>();
        List<string> masterIDs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    add.Style.Add("display", "none");
                    System.Web.UI.HtmlControls.HtmlGenericControl hide3 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("att");

                    hide3.Style.Add("display", "none");
                }
                else
                {
                    Response.Redirect("Landing.aspx");
                }
                loadCalendar();
            }

            else
            {
                Response.Redirect("Landing.aspx");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //HttpContext.Current.Session["FromRoster"] = null;
        }

        private void loadCalendar()
        {
            String eventName = "";
            String eventStart = "";
            String eventEnd = "";
            string daysClassHeld = "";

            int idCount = 0;

            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            SqlDataReader objRS;
            string strsql = "";
            string mID = "";
            string assocID = "";
            string eventT = "";

            string[] startSplit;
            string[] endSplit;

            classDiv.InnerHtml = "";
            if (HttpContext.Current.Session["FromRoster"] != null){
                //if coach viewing it
                if (HttpContext.Current.Session["FromRoster"].ToString() == "y")
                {
                    strsql = "select * from EventMasterTable where associatedID ='" + HttpContext.Current.Session["PlayerIDForSched"].ToString() + "'";
                }
                //if the player (owner) is viewing it
                else
                {
                    strsql = "select * from EventMasterTable where associatedID ='" + HttpContext.Current.Session["UserID"].ToString() + "'";
                }
            }
            else
            {
                strsql = "select * from EventMasterTable where associatedID ='" + HttpContext.Current.Session["UserID"].ToString() + "'";
            }

            objCon.Open();

            objCmd = new SqlCommand(strsql, objCon);

            objRS = objCmd.ExecuteReader();
            if (objRS.HasRows)
            {
                while (objRS.Read())
                {
                    daysClassHeld = "";
                    idCount = idCount + 1;
                    //get all of event's data to store in session for delete and edit usages
                    mID = objRS["masterID"].ToString();
                    assocID = objRS["associatedID"].ToString();
                    eventName = objRS["eventName"].ToString();
                    eventT = objRS["eventType"].ToString();
                    eventStart = objRS["eventStart"].ToString();
                    eventEnd = objRS["eventEnd"].ToString();

                    startSplit = eventStart.Split(' ');
                    endSplit = eventEnd.Split(' ');

                    //create front end
                    HtmlGenericControl singleClassDiv =
                    new HtmlGenericControl("div");
                    singleClassDiv.Attributes["id"] = "class" + idCount.ToString();
                    singleClassDiv.Attributes["class"] = "classDiv";
                    singleClassDiv.Attributes["runat"] = "server";
                    classDiv.Controls.Add(singleClassDiv);


                    HtmlGenericControl classTimes =
                    new HtmlGenericControl("div");
                    classTimes.Attributes["id"] = "classTimes" + idCount.ToString();
                    classTimes.Attributes["class"] = "col-sm-4";
                    classTimes.Attributes["runat"] = "server";
                    classTimes.Attributes["style"] = "float:left; width: 25%; border: 1px solid #008CBA; vertical-align:middle; text-align:center;padding:0px;";

                    Label startTimeLabel = new Label();
                    startTimeLabel.Text = (startSplit[1] +  "  " + startSplit[2]).Replace(":00 ", "");
                    Label endTimeLabel = new Label();
                    endTimeLabel.Text = (endSplit[1] + "  " + endSplit[2]).Replace(":00 ", "");
                    classTimes.Controls.Add(startTimeLabel);
                    classTimes.Controls.Add(new Literal() { Text = "<br/>" });
                    classTimes.Controls.Add(endTimeLabel);

                    HtmlGenericControl classDetails =
                    new HtmlGenericControl("div");
                    classDetails.Attributes["id"] = "classDetails" + idCount.ToString();
                    classDetails.Attributes["class"] = "col-sm-4";
                    classDetails.Attributes["runat"] = "server";
                    classDetails.Attributes["style"] = "float:left; width: 50%; border: 1px solid #008CBA; vertical-align:middle; text-align:center;padding:0px;";

                    if (HttpContext.Current.Session["FromRoster"] != null)
                    {
                        //owner looking at own schedule
                        if (HttpContext.Current.Session["PlayerIDForSched"].ToString() == HttpContext.Current.Session["UserID"].ToString())
                        {
                            classDetails.Controls.Add(new Literal() { Text = "<a  style='z-index:1000;' onclick='return deleteClass(" + idCount.ToString() + ")'><i class='fa fa-minus-circle' aria-hidden='true' style='font-size:30px;color:#ba0047;float:left;'></i></a>" });
                            classDetails.Controls.Add(new Literal() { Text = "<a  style='z-index:1000;' onclick='return editClass(" + idCount.ToString() + ")'><i class='fa fa-pencil-square-o' aria-hidden='true' style='font-size:30px;color:black;float:right;'></i></a>" });

                        }
                        else
                        {

                        }
                    }
                    //haven't gone to roster page, so owner is viewing schedule
                    else
                    {
                        classDetails.Controls.Add(new Literal() { Text = "<a  style='z-index:1000;' onclick='return deleteClass(" + idCount.ToString() + ")'><i class='fa fa-minus-circle' aria-hidden='true' style='font-size:30px;color:#ba0047;float:left;'></i></a>" });
                        classDetails.Controls.Add(new Literal() { Text = "<a  style='z-index:1000;' onclick='return editClass(" + idCount.ToString() + ")'><i class='fa fa-pencil-square-o' aria-hidden='true' style='font-size:30px;color:black;float:right;'></i></a>" });

                    }

                    Label classNameLabel = new Label();
                    classNameLabel.Text = eventName;
                    Label classDaysLabel = new Label();
                    if (objRS["reoccur"].ToString().Contains("Sunday"))
                    {
                        daysClassHeld = daysClassHeld + "Sun ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Monday"))
                    {
                        daysClassHeld = daysClassHeld + "M ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Tuesday"))
                    {
                        daysClassHeld = daysClassHeld + "Tue ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Wednesday"))
                    {
                        daysClassHeld = daysClassHeld + "W ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Thursday"))
                    {
                        daysClassHeld = daysClassHeld + "Th ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Friday"))
                    {
                        daysClassHeld = daysClassHeld + "F ";
                    }
                    if (objRS["reoccur"].ToString().Contains("Saturday"))
                    {
                        daysClassHeld = daysClassHeld + "Sat ";
                    }


                    //save event info in session
                    classInfo.Add(mID + "-" + assocID + "-" + eventName + "-" + eventT + "-" + eventStart + "-" + eventEnd + "-" + daysClassHeld);
                    HttpContext.Current.Session["ClassesInfo"] = classInfo;

                    classDaysLabel.Text = daysClassHeld;
                    classDetails.Controls.Add(classNameLabel);
                    classDetails.Controls.Add(new Literal() { Text = "<br/>" });
                    classDetails.Controls.Add(classDaysLabel);
                    classDetails.Controls.Add(new Literal() { Text = "<br/>" });
                    //if (HttpContext.Current.Session["FromRoster"] != null)
                    //{
                    //    //owner looking at own schedule
                    //    if (HttpContext.Current.Session["PlayerIDForSched"].ToString() == HttpContext.Current.Session["UserID"].ToString())
                    //    {
                    //        classDetails.Controls.Add(new Literal() { Text = "<a onclick='return deleteClass(" + idCount.ToString() + ")'><i class='fa fa-minus-circle' aria-hidden='true' style='display:inline;font-size:30px;color:#ba0047;'></i></a>" });
                    //        classDetails.Controls.Add(new Literal() { Text = "<a onclick='return editClass(" + idCount.ToString() + ")'><i class='fa fa-pencil-square-o' aria-hidden='true' style='display:inline;font-size:30px;color:white;'></i></a>" });

                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                    ////haven't gone to roster page, so owner is viewing schedule
                    //else
                    //{
                    //    classDetails.Controls.Add(new Literal() { Text = "<a onclick='return deleteClass(" + idCount.ToString() + ")'><i class='fa fa-minus-circle' aria-hidden='true' style='display:inline;font-size:30px;color:#ba0047;'></i></a>" });
                    //    classDetails.Controls.Add(new Literal() { Text = "<a onclick='return editClass(" + idCount.ToString() + ")'><i class='fa fa-pencil-square-o' aria-hidden='true' style='display:inline;font-size:30px;color:white;'></i></a>" });

                    //}

                    HtmlGenericControl classDates =
                    new HtmlGenericControl("div");
                    classDates.Attributes["id"] = "classDates" + idCount.ToString();
                    classDates.Attributes["class"] = "col-sm-4";
                    classDates.Attributes["runat"] = "server";
                    classDates.Attributes["style"] = "float:left; width: 25%; border: 1px solid #008CBA; vertical-align:middle; text-align:center;padding:0px;";

                    Label startDateLabel = new Label();
                    startDateLabel.Text = startSplit[0];
                    Label endDateLabel = new Label();
                    endDateLabel.Text = endSplit[0];
                    classDates.Controls.Add(startDateLabel);
                    classDates.Controls.Add(new Literal() { Text = "<br/>" });
                    classDates.Controls.Add(endDateLabel);

                    HiddenField idHidden = new HiddenField();
                    idHidden.ID = "hidden" + idCount.ToString();
                    idHidden.Value = mID;
                    masterIDs.Add(mID);

                    //Label startDateLabel = new Label();
                    //startDateLabel.Text = "1/1/2017";
                    //Label endDateLabel = new Label();
                    //endDateLabel.Text = "5/5/2017";
                    //classTimes.Controls.Add(startDateLabel);
                    //classTimes.Controls.Add(new Literal() { Text = "<br/>" });
                    //classTimes.Controls.Add(endDateLabel);

                    singleClassDiv.Controls.Add(classTimes);
                    singleClassDiv.Controls.Add(classDetails);
                    singleClassDiv.Controls.Add(classDates);
                    singleClassDiv.Controls.Add(idHidden);
                    classDiv.Controls.Add(singleClassDiv);


                    //show the classes
                }
            }

            objCmd = null;
            objRS.Close();
            objCon.Close();
        }


        protected void newClass(object sender, EventArgs e)
        {
            Response.Redirect("AddClass.aspx");
        }
        protected void deletePlayerClass(object sender, EventArgs e)
        {
            //need to change these vars to grab from hidden fields
            string masterID = masterIDs.ElementAt(Int32.Parse(deleteHiddenField.Value)-1);

            string strsql = "";
            SqlConnection objCon = default(SqlConnection);
            SqlCommand objCmd = default(SqlCommand);
            objCon = new SqlConnection();
            objCon.ConnectionString = ConfigurationManager.AppSettings["ManageUConnectionString"];

            objCon.Open();
            objCmd = new SqlCommand();
            objCmd.Connection = objCon;

            //Delete class from database if want to delete all instances

            strsql = "delete from EventMasterTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCmd = null;

            strsql = "delete from EventDetailsTable where masterID='" + masterID + "'";
            objCmd = new SqlCommand(strsql, objCon);

            objCmd.ExecuteNonQuery();

            objCon.Close();

            loadCalendar();

        }

        protected void editPlayerClass(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ClassToEdit"] = Int32.Parse(editHiddenField.Value);
            Response.Redirect("EditClass.aspx");
            
        }
    }
}