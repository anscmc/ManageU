﻿<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TestCal.aspx.cs" Inherits="ManageU.Pages.TestCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    


    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        
                        <div class="col-sm-6 col-sm-offset-3" style="text-align:center;">
                            <asp:Button runat="server" id="createMeetingButton" Text="+ Add Event" OnClick="createEvent" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center; color:#008CBA; background-color:white;width:250px;" />
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    
        <asp:Button ID="nextMonthButton" runat="server" style="display:none;" OnClick="nextMonth" />
        <asp:Button ID="lastMonthButton" runat="server" style="display:none;" OnClick="lastMonth" />

        <%--<div style="background-color:white;height:auto;width:auto;">
            <asp:Calendar ID="Calendar1" class="testCal" runat="server"></asp:Calendar>
        </div>--%>

                <div id="outer" runat="server" style="height:auto;width:100%;clear:both;">
                    <div id="container2" class="container" runat="server" style="width:100%;margin-right:0px;margin-left:0px;text-align:center;">

                        <div class="monthInfo">
                            <i class="fa fa-long-arrow-left" aria-hidden="true" runat="server" onclick="lastMonth();" style="display:inline;font-size:40px;padding-right:50px"></i>
                            <label id="monthLabel" runat="server" style="display:none;font-size:16px;"></label>
                            <i class="fa fa-long-arrow-right" runat="server" onclick="nextMonth();" aria-hidden="true" style="display:inline;font-size:40px;padding-left:50px"></i>
                            <br />
                            <div class="square3" style="background-color:white !important;z-index:500;display:inline-block;margin: 0 auto !important;">
                                <div id="Div1" runat="server" class="content">
                                    <asp:Calendar ID="Calendar2" class="testCal" runat="server" style="height:100%;width:100%;"></asp:Calendar>     
                                </div>
                            </div>
                        </div>

                    <%--<div class="square2" style="background-color:#008CBA !important;color:white;z-index:1000;">
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
                    </div>--%>

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

            <%--<div class="square3" style="background-color:white !important;z-index:500;display:inline-block;">
                <div id="Div1" runat="server" class="content">
                       <asp:Calendar ID="Calendar2" class="testCal" runat="server" style="height:100%;width:100%;"></asp:Calendar>     
                </div>
            </div>--%>

        <div id="divClick" class="content" onclick="showLeftPanel()" style="display:none;">
        </div>
        
        <asp:Button runat="server" ID="hiddenView" Text="" CssClass="btn btn-default" OnClick="hiddenView_Click" style="display: none;" />
        <asp:HiddenField ID="viewHiddenField" runat="server" />
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

        

        window.onload = function () {

            $(function () {
                $('td a').on('click', function (event) { event.preventDefault(); });
            });

            var elemTDs = document.getElementsByTagName('td');
            for (var i = 0; i < elemTDs.length; i++) {
                var elemTD = elemTDs[i];
                elemTD.attributes
                elemTD.onclick = function () {
                    var hideDivs = document.getElementsByClassName("eventBasic");
                    for (var i = 0; i < hideDivs.length; i++) {
                        
                        hideDivs[i].style.display = "none";

                    }
                    divClick.click();
                }
            }

        }

        // window.onload = function populateDots() {
        //    var elemAs = document.getElementsByTagName("a");
        //    for (var i = 0; i < elemAs.length; i++) {
        //        var elemA = elemAs[i];
        //        var dayLabels = document.getElementsByClassName("daysClass");
        //        for (var i = 0; i < dayLabels.length; i++) {
        //            if (dayLabels[i].innerText == elemA.innerText) {
        //                elemA.innerText = elemA.innerText + " event";
        //            }
        //        }
        //    }
        //}

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

        function showInfo(row) {
            var showButton = $('#<%= hiddenView.ClientID %>');
            if (showButton != null) {
                document.getElementById('<%=viewHiddenField.ClientID %>').value = row;
                showButton.click();
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

    </script>

</asp:Content>
