using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class AddLift : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                HttpContext.Current.Session["NumLifts"] = 0;
            }
            
        }

        protected void newLiftButton_Click(object sender, EventArgs e)
        {
            //lift1.Style.Add("display", "block");
            HttpContext.Current.Session["NumLifts"] = Int32.Parse(HttpContext.Current.Session["NumLifts"].ToString()) + 1;
        }

        protected void createLiftDivs()
        {
            int num = Int32.Parse(HttpContext.Current.Session["NumLifts"].ToString());
            for (int i = 1; i <= num; i++)
            {
                //Create new lift div
                HtmlGenericControl newLift = new HtmlGenericControl("div");
                newLift.Attributes["id"] = "lift" + i;
                newLift.Attributes["runat"] = "server";

                Label newLiftNameLabel = new Label();
                newLiftNameLabel.Text = "Lift Name";

                TextBox newLiftName = new TextBox();
                newLiftName.ID = "liftName" + i;
                newLiftName.Attributes["runat"] = "server";

                Label newLiftSetLabel = new Label();
                newLiftSetLabel.Text = "Sets";

                TextBox newLiftSets = new TextBox();
                newLiftSets.ID = "liftSets" + i;
                newLiftSets.Attributes["runat"] = "server";

                Label newLiftRepLabel = new Label();
                newLiftRepLabel.Text = "Reps";

                TextBox newLiftReps = new TextBox();
                newLiftReps.ID = "liftReps" + i;
                newLiftReps.Attributes["runat"] = "server";

                Button deleteButton = new Button();
                deleteButton.ID = "delete" + i;
                deleteButton.Text = "Delete";
                deleteButton.Attributes.Add("OnClick", "deleteButton_Click");

                newLift.Controls.Add(newLiftNameLabel);
                newLift.Controls.Add(newLiftName);
                newLift.Controls.Add(new Literal() { Text = "<br/>" });
                newLift.Controls.Add(newLiftSetLabel);
                newLift.Controls.Add(newLiftSets);
                newLift.Controls.Add(new Literal() { Text = "<br/>" });
                newLift.Controls.Add(newLiftRepLabel);
                newLift.Controls.Add(newLiftReps);
                newLift.Controls.Add(new Literal() { Text = "<br/>" });
                newLift.Controls.Add(deleteButton);

                newlyAddedLifts.Controls.Add(newLift);
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["NumLifts"] = Int32.Parse(HttpContext.Current.Session["NumLifts"].ToString()) - 1;
            createLiftDivs();
        }

        protected void addLiftButton_Click(object sender, EventArgs e)
        {
            string[] idSplit = liftIDsHidden.Value.Split(',');
            string[] nameSplit = liftNamesHidden.Value.Split(',');
            string[] setSplit = liftSetsHidden.Value.Split(',');
            string[] repSplit = liftRepsHidden.Value.Split(',');
            string liftID;
            string liftName;
            string liftSets;
            string liftReps;

            for(int i = 0; i < idSplit.Length; i++)
            {
                if (idSplit[i] == "")
                {

                }
                else
                {
                    liftID = idSplit[i];
                    liftName = nameSplit[i];
                    liftSets = setSplit[i];
                    liftReps = repSplit[i];

                    //have to find the elements with these ids to get their values
                }
            }
        }
    }
}