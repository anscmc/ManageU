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
            if(!IsPostBack)
            {
                HttpContext.Current.Session["NumLifts"] = 0;
            }
            
        }

        protected void newLiftButton_Click(object sender, EventArgs e)
        {
            //lift1.Style.Add("display", "block");
            HttpContext.Current.Session["NumLifts"] = Int32.Parse(HttpContext.Current.Session["NumLifts"].ToString()) + 1;
            createLiftDivs();
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

        }
    }
}