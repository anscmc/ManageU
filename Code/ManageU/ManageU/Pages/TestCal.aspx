<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TestCal.aspx.cs" Inherits="ManageU.Pages.TestCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    
    <div id="topLeft" onclick="goHome()" style="z-index:3000;height:45px;width:115px;position:absolute;top:0px;left:0px;">

    </div>

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <asp:Button ID="nextMonthButton" runat="server" style="display:none;" OnClick="nextMonth" />
        <asp:Button ID="lastMonthButton" runat="server" style="display:none;" OnClick="lastMonth" />
        <%--<div style="background-color:white;height:auto;width:auto;">
            <asp:Calendar ID="Calendar1" class="testCal" runat="server"></asp:Calendar>
        </div>--%>

                <div style="height:auto;width:100%;z-index:1500;">
                    <div id="container2" class="container" runat="server" style="width:100%;margin-right:0px;margin-left:0px;">
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div2" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div3" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <i class="fa fa-long-arrow-left" aria-hidden="true" runat="server" onclick="lastMonth();" style="font-size:30px;"></i>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div4" runat="server" class="content">
                            
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div5" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <label id="monthLabel" runat="server" style="font-size:16px;"></label>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div6" runat="server" class="content">

                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div7" runat="server" class="content">
                            <label runat="server" style="margin-top:10%;"></label>
                            <br />
                            <i class="fa fa-long-arrow-right" runat="server" onclick="nextMonth();" aria-hidden="true" style="font-size:30px;"></i>
                        </div>
                    </div>
                    <div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
                        <div id="Div8" runat="server" class="content">
                            
                        </div>
                    </div>

                <%--<div id="leftpanel" runat="server" class="leftpanel">
                    <div id="downArrow" onclick="showLeftPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                        <i class="fa fa-chevron-down" aria-hidden="true"></i>
                    </div>

                    <div id="eventBasic" onclick="showInfo()" runat="server" class="eventBasic" style="color:black;">
                        event - click to see info
                    </div>
                </div>--%>
                <%--<div id="rightpanel" >
                   <div id="leftArrow" onclick="showRightPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                       <i class="fa fa-chevron-down" aria-hidden="true"></i>
                   </div>

                    [&gt;]()
                </div>--%>

                </div>
            </div>

               <%--see margin top--%>
            <div class="square3" style="background-color:white !important;z-index:500;margin-top:-40px;">
                <div id="Div1" runat="server" class="content" style="text-align:left !important;">
                       <asp:Calendar ID="Calendar2" class="testCal" runat="server" style="height:100%;width:100%;"></asp:Calendar>     
                </div>
            </div>
        <div id="divClick" class="content" onclick="showLeftPanel()" style="display:none;">
        </div>
        
        
    </div>

    <%--<asp:Calendar ID="Calendar1" CssClass="cal" runat="server"></asp:Calendar>--%>
    <script type="text/javascript">
        
        $('td a').on('click', function () {
            //console.log($(this).text());
            //var dayNum = console.log($(this).attr('title'));
            var dayNum = $(this).text();
            //var dayTitle = $(this).attr('title'));
            divClick.innerText = "";
            divClick.innerText = "x" + dayNum + "x";
        });

        var elemAs = document.getElementsByTagName("a");
        for (var i = 0; i < elemAs.length; i++) {
            var elemA = elemAs[i];
            var dayLabels = document.getElementsByClassName("daysClass");
            for (var i = 0; i < dayLabels.length; i++) {
                if (dayLabels[i].innerText == elemA.innerText) {
                    console.log('match');
                }
            }
        }

        window.onload = function () {

            $(function () {
                $('a').on('click', function (event) { event.preventDefault(); });
            });

            var elemTDs = document.getElementsByTagName('td');
            for (var i = 0; i < elemTDs.length; i++) {
                var elemTD = elemTDs[i];
                elemTD.onclick = function () {
                    var hideDivs = document.getElementsByClassName("eventBasic");
                    for (var i = 0; i < hideDivs.length; i++) {
                        
                        hideDivs[i].style.display = "none";

                    }
                    divClick.click();
                }
            }

        }
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
            
            //var divClickText = divClick.innerText;

            //var hideDivs = document.getElementsByClassName("eventBasic");
            //for (var i = 0; i < hideDivs.length; i++) {
            //    var divID = hideDivs[i].id;
            //    var checkID = divID.endsWith(divClickText);
            //    alert(checkID + " this should be true or false");
            //    hideDivs[i].style.display = "none";
                
            //}

            //var showDivs = document.getElementsByClassName("eventBasic");
            
            //for (var i = 0; i < showDivs.length; i++) {
            //    var divID = showDivs[i].id;
            //    alert(divID + "this is supposed to be id");
            //    //showDivs[i].style.display = "block";
            //}
            //var alertNum = divClick.innerText.toString();
            //alert(alertNum);
            var hideDivs = document.getElementsByClassName("eventBasic");
            for (var i = 0; i < hideDivs.length; i++) {

                hideDivs[i].style.display = "none";

            }

            var showDivs = document.getElementsByClassName("eventBasic");
            for (var i = 0; i < showDivs.length; i++) {
                //var alertNum = divClick.innerText.toString();
                var divID = showDivs[i].id;
                var idString = divID.toString();
                var checker = idString.endsWith(divClick.innerText);
                if (checker) {
                    showDivs[i].style.display = "block";
                }
                
                //if (checkID) {
                //    showDivs[i].style.display = "block";
                //}
            }

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

        function showInfo() {
            window.location.replace("ViewEvent.aspx");
        }

        function goHome() {
            window.location.replace("TeamProfile.aspx");
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

    </script>

</asp:Content>
