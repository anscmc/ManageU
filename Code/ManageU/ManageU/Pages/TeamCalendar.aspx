<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamCalendar.aspx.cs" Inherits="ManageU.Pages.TeamCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
        <h2 ><%: Title %></h2>
        <hr />

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
                    <div class="topCalRow">
                        <div class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label>sun</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <i class="fa fa-long-arrow-left" aria-hidden="true" runat="server" onclick="lastMonth();" style="margin-top:10%;font-size:30px;"></i>
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
                            <label id="monthLabel" runat="server" style="margin-top:10%;margin-bottom:0px !important;font-size:16px;"></label>
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
                            <i class="fa fa-long-arrow-right" runat="server" onclick="nextMonth();" aria-hidden="true" style="margin-top:10%;font-size:30px;"></i>
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
                        <div id="day1" runat="server" class="content" onclick="showLeftPanel()">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day2" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day3" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day4" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day5" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day6" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day7" runat="server" class="content">

                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div id="day8" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div id="day9" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day10" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day11" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day12" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day13" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day14" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div id="day15" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div id="day16" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day17" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day18" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day19" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                    <div class="square">
                        <div id="day20" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day21" runat="server" class="content">

                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div id="day22" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div id="day23" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day24" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day25" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day26" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day27" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day28" runat="server" class="content">
                            <i class="fa fa-circle" aria-hidden="true" style="color:#ba9800;font-size:25px;margin-top:30%;"></i>
                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div id="day29" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div id="day30" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day31" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day32" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day33" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day34" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div id="day35" runat="server" class="content">

                        </div>
                    </div>
                </div>

                <div id="left-panel">
                    [&gt;]()
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
            var elem = document.getElementById("left-panel");
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

    </script>


</asp:Content>
