<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamCalendar.aspx.cs" Inherits="ManageU.Pages.TeamCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
        <h2 ><%: Title %></h2>
        <hr />
        <label id="firstDayName" runat="server" style="display:none;font-size:16px;"></label>
        <label id="lastDayNum" runat="server" style="display:none;font-size:16px;"></label>
        <label id="dayOneLabel" runat="server" style="display:none;font-size:16px;"></label>
        <label id="monthYear" runat="server" style="display:none;font-size:16px;"></label>
        <label id="monthMonth" runat="server" style="display:none;font-size:16px;"></label>
        <asp:Button ID="nextMonthButton" runat="server" style="display:none;" OnClick="nextMonth" />
        <asp:Button ID="lastMonthButton" runat="server" style="display:none;" OnClick="lastMonth" />

        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Create Event" CssClass="btn btn-default" OnClick="createEvent"
                style="display: block; margin: 0 auto; margin-bottom:10px !important;text-align: center; color:#008CBA; background-color:white;" />
        </div>

        <%--<i class="fa fa-long-arrow-left" aria-hidden="true" runat="server" onclick="lastMonth();"></i>
        <label id="monthLabel" runat="server" style="padding-left:30px; padding-right:30px;"></label>
        <i class="fa fa-long-arrow-right" runat="server" onclick="nextMonth();" aria-hidden="true"></i>--%>

        <div class="calWrap" style="max-width:450px !important;">
            <div class="container"  style="max-width:450px !important;">

                <div class="calRow">
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div1" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div2" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <i class="fa fa-long-arrow-left" aria-hidden="true" runat="server" onclick="lastMonth();" style="font-size:30px;"></i>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div3" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div4" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label id="monthLabel" runat="server" style="font-size:16px;"></label>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div5" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div6" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <i class="fa fa-long-arrow-right" runat="server" onclick="nextMonth();" aria-hidden="true" style="font-size:30px;"></i>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;">
                        <div id="Div7" runat="server" class="content">
                            
                        </div>
                    </div>
                </div>
                <div class="calRow">
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>sun</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>mon</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>tues</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>wed</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>thur</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>fri</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>sat</label>
                        </div>
                    </div>
                </div>
                <div class="calRow">
                    <div class="square">
                        <div id="day1" class="content" onclick="showLeftPanel()">
                            <label id="label1" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day2" class="content">
                            <label id="label2" style="float:left;margin-left:5px;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day3" class="content">
                            <label id="label3" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day4" class="content">
                            <label id="label4" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day5" class="content">
                            <label id="label5" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day6" class="content">
                            <label id="label6" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day7" class="content">
                            <label id="label7" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div id="day8" runat="server" class="content">
                            <label id="label8" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day9" runat="server" class="content">
                            <label id="label9" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day10" runat="server" class="content">
                            <label id="label10" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day11" runat="server" class="content">
                            <label id="label11" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day12" runat="server" class="content">
                            <label id="label12" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day13" runat="server" class="content">
                            <label id="label13" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day14" runat="server" class="content">
                            <label id="label14" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div id="day15" runat="server" class="content">
                            <label id="label15" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day16" runat="server" class="content">
                            <label id="label16" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day17" runat="server" class="content">
                            <label id="label17" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day18" runat="server" class="content">
                            <label id="label18" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day19" runat="server" class="content">
                            <label id="label19" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day20" runat="server" class="content">
                            <label id="label20" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day21" runat="server" class="content">
                            <label id="label21" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div id="day22" runat="server" class="content">
                            <label id="label22" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day23" runat="server" class="content">
                            <label id="label23" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day24" runat="server" class="content">
                            <label id="label24" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day25" runat="server" class="content">
                            <label id="label25" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day26" runat="server" class="content">
                            <label id="label26" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day27" runat="server" class="content">
                            <label id="label27" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day28" runat="server" class="content">
                            <label id="label28" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>
                
                <div class="calRow">
                    <div class="square">
                        <div id="day29" runat="server" class="content">
                            <label id="label29" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day30" runat="server" class="content">
                            <label id="label30" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day31" runat="server" class="content">
                            <label id="label31" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day32" runat="server" class="content">
                            <label id="label32" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day33" runat="server" class="content">
                            <label id="label33" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day34" runat="server" class="content">
                            <label id="label34" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day35" runat="server" class="content">
                            <label id="label35" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>
                <div class="calRow">
                    <div class="square">
                        <div id="day36" runat="server" class="content">
                            <label id="label36" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day37" runat="server" class="content">
                            <label id="label37" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day38" runat="server" class="content">
                            <label id="label38" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day39" runat="server" class="content">
                            <label id="label39" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day40" runat="server" class="content">
                            <label id="label40" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day41" runat="server" class="content">
                            <label id="label41" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day42" runat="server" class="content">
                            <label id="label42" style="float:left;margin-left:5px;"></label>
                        </div>
                    </div>
                </div>


                <div id="leftpanel" class="leftpanel">
                    <div id="downArrow" onclick="showLeftPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                        <i class="fa fa-chevron-down" aria-hidden="true"></i>
                    </div>

                    <div id="eventBasic" onclick="showRightPanel()" style="color:black;">
                        event - click to see info
                    </div>
                 </div>
                 <div id="rightpanel" >
                    <div id="leftArrow" onclick="showRightPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                        <i class="fa fa-chevron-down" aria-hidden="true"></i>
                    </div>

                    <%--[&gt;]()--%>
                </div>

                <%--<div id="bottomRow" class="calRow">
                    <div class="square">
                        <div id="day36" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div id="day37" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day38" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day39" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day40" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day41" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day42" class="content">

                        </div>
                    </div>
                </div>--%>
                
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function lastMonth()
        { 
            var lastMonthButton = $('#<%= lastMonthButton.ClientID %>');

                lastMonthButton.click();
        }

        function nextMonth()
        { 
            var nextMonthButton = $('#<%= nextMonthButton.ClientID %>');

                nextMonthButton.click();
            
        }

        function showLeftPanel() {
            var elem = document.getElementById("leftpanel");
            if (elem.classList) {
                elem.classList.toggle("show");
            } else {
                var classes = elem.className;
                if (classes.indexOf("show") >= 0) {
                    elem.className = classes.replace("show", "");
                } else {
                    elem.className = classes + " show";
                }
                console.log(elem.className);
            }
        }

        function showRightPanel() {
            var elem = document.getElementById("rightpanel");
            if (elem.classList) {
                elem.classList.toggle("show");
            } else {
                var classes = elem.className;
                if (classes.indexOf("show") >= 0) {
                    elem.className = classes.replace("show", "");
                } else {
                    elem.className = classes + " show";
                }
                console.log(elem.className);
            }
        }

        //var divs = $('div[id^="day"]').hide(),
        //i = 0;
        ////i2 = 1;

        //(function cycle() {
            
        //    //divs.eq(i).text(i2);
        //    divs.eq(i).append("<br/><i class='fa fa-circle' aria-hidden='true' style='color:#ba9800;font-size:10px;'></i>")
        //    divs.eq(i).show(0, cycle);
        //              //.delay(1000)
        //              //.hide(0, cycle);

        //    //i = ++i % divs.length;
        //    i = ++i;
        //    //i2 = ++i2;

        //})();
        var month = $('#<%=monthLabel.ClientID%>').html();
        var firstDay = $('#<%=firstDayName.ClientID%>').html();
        var lastDay = $('#<%=lastDayNum.ClientID%>').html();
        var labels = $('label[id^="label"]').hide();

        i = 0;
        i2 = 1;
        i3 = parseInt(lastDay);

        switch (firstDay) {
            case "Sunday":
                i = 0;
                break;
            case "Monday":
                i = 1;
                break;
            case "Tuesday":
                i = 2;
                break;
            case "Wednesday":
                i = 3;
                break;
            case "Thursday":
                i = 4;
                break;
            case "Friday":
                i = 5;
                break;
            case "Saturday":
                i = 6;
                break;

        }

        (function cycle() {

            if (i2 > i3) return;
            labels.eq(i).text(i2);
            //labels.eq(i).append("<div style='float:right;height:auto;width:50%;margin:0 auto;'><i class='fa fa-circle' aria-hidden='true' style='color:#ba9800;font-size:10px;'></i></div>")
            labels.eq(i).show(0, cycle);

            i = ++i;
            i2 = i2 + 1;

            

        })();

    </script>


</asp:Content>
