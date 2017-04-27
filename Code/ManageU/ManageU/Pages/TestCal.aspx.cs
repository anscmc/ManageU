using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageU.Pages
{
    public partial class TestCal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "player" || HttpContext.Current.Session["UserType"].ToString() == "coach")
            {
                if (!IsPostBack)
                {
                    Calendar2.ShowNextPrevMonth = false;
                    Calendar2.SelectedDate = DateTime.Now;
                    Calendar2.VisibleDate = Calendar2.SelectedDate;
                    DateTime curMonth = Calendar2.SelectedDate;
                    //monthLabel.InnerText = curMonth.Month.ToString();

                    int monthInt = curMonth.Month;

                    switch (monthInt)
                    {
                        case 1:
                            monthLabel.InnerText = "January";
                            break;
                        case 2:
                            monthLabel.InnerText = "February";
                            break;
                        case 3:
                            monthLabel.InnerText = "March";
                            break;
                        case 4:
                            monthLabel.InnerText = "April";
                            break;
                        case 5:
                            monthLabel.InnerText = "May";
                            break;
                        case 6:
                            monthLabel.InnerText = "June";
                            break;
                        case 7:
                            monthLabel.InnerText = "July";
                            break;
                        case 8:
                            monthLabel.InnerText = "August";
                            break;
                        case 9:
                            monthLabel.InnerText = "September";
                            break;
                        case 10:
                            monthLabel.InnerText = "October";
                            break;
                        case 11:
                            monthLabel.InnerText = "November";
                            break;
                        case 12:
                            monthLabel.InnerText = "December";
                            break;
                    }
                }
            }
        }

        protected void nextMonth(object sender, EventArgs e)
        {
            //Calendar2.VisibleDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.SelectedDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.VisibleDate = Calendar2.SelectedDate;
            DateTime curMonth = Calendar2.SelectedDate;
            //monthLabel.InnerText = curMonth.Month.ToString();

            int monthInt = curMonth.Month;

            switch (monthInt)
            {
                case 1:
                    monthLabel.InnerText = "January";
                    break;
                case 2:
                    monthLabel.InnerText = "February";
                    break;
                case 3:
                    monthLabel.InnerText = "March";
                    break;
                case 4:
                    monthLabel.InnerText = "April";
                    break;
                case 5:
                    monthLabel.InnerText = "May";
                    break;
                case 6:
                    monthLabel.InnerText = "June";
                    break;
                case 7:
                    monthLabel.InnerText = "July";
                    break;
                case 8:
                    monthLabel.InnerText = "August";
                    break;
                case 9:
                    monthLabel.InnerText = "September";
                    break;
                case 10:
                    monthLabel.InnerText = "October";
                    break;
                case 11:
                    monthLabel.InnerText = "November";
                    break;
                case 12:
                    monthLabel.InnerText = "December";
                    break;
            }
        }
        protected void lastMonth(object sender, EventArgs e)
        {
            //Calendar2.VisibleDate = Calendar2.SelectedDate.AddMonths(1);
            Calendar2.SelectedDate = Calendar2.SelectedDate.AddMonths(-1);
            Calendar2.VisibleDate = Calendar2.SelectedDate;
            DateTime curMonth = Calendar2.SelectedDate;
            //monthLabel.InnerText = curMonth.Month.ToString();

            int monthInt = curMonth.Month;

            switch (monthInt)
            {
                case 1:
                    monthLabel.InnerText = "January";
                    break;
                case 2:
                    monthLabel.InnerText = "February";
                    break;
                case 3:
                    monthLabel.InnerText = "March";
                    break;
                case 4:
                    monthLabel.InnerText = "April";
                    break;
                case 5:
                    monthLabel.InnerText = "May";
                    break;
                case 6:
                    monthLabel.InnerText = "June";
                    break;
                case 7:
                    monthLabel.InnerText = "July";
                    break;
                case 8:
                    monthLabel.InnerText = "August";
                    break;
                case 9:
                    monthLabel.InnerText = "September";
                    break;
                case 10:
                    monthLabel.InnerText = "October";
                    break;
                case 11:
                    monthLabel.InnerText = "November";
                    break;
                case 12:
                    monthLabel.InnerText = "December";
                    break;
            }
        }
    }
}