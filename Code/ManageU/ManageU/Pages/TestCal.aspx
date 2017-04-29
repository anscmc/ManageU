<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TestCal.aspx.cs" Inherits="ManageU.Pages.TestCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <asp:Button ID="nextMonthButton" runat="server" style="display:none;" OnClick="nextMonth" />
        <asp:Button ID="lastMonthButton" runat="server" style="display:none;" OnClick="lastMonth" />
        <%--<div style="background-color:white;height:auto;width:auto;">
            <asp:Calendar ID="Calendar1" class="testCal" runat="server"></asp:Calendar>
        </div>--%>

                <div style="height:auto;width:100%;z-index:1500;">
                    <div class="container"  style="width:100%;margin-right:0px;margin-left:0px;">
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

                <div id="leftpanel" runat="server" class="leftpanel">
                    <div id="downArrow" onclick="showLeftPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                        <i class="fa fa-chevron-down" aria-hidden="true"></i>
                    </div>

                    <%--<div id="eventBasic" onclick="showInfo()" runat="server" class="eventBasic" style="color:black;">
                        event - click to see info
                    </div>--%>
                </div>
                <div id="rightpanel" >
                   <div id="leftArrow" onclick="showRightPanel()" style="height:auto;width:100%;margin-top:0px;font-size:20px;">
                       <i class="fa fa-chevron-down" aria-hidden="true"></i>
                   </div>

                    <%--[&gt;]()--%>
                </div>

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
        

        window.onload = function () {

            $(function () {
                $('a').on('click', function (event) { event.preventDefault(); });
            });

            //var anchor = document.getElementsByTagName('a');
            //link.onclick = function () { return false };

            //document.getElementsByTagName("a")[0].setAttribute("onclick", "return false");
            //anchor.onclick = function () { return false };
            
            var elemTDs = document.getElementsByTagName('td');
            for (var i = 0; i < elemTDs.length; i++) {
                var elemTD = elemTDs[i];
                elemTD.onclick = function () {
                    divClick.click();
                }

                //var anchors = document.getElementsByTagName('a');
                //for (var i = 0; i < anchors.length; i++){
                //    var anchor = anchors[i];
                //    anchor.onclick = function () {
                //        return false;
                //    }
                //}
                
                //document.getElementsByTagName("a")[0].setAttribute("onclick", "return false");
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
            
            //var anchors = document.getElementsByTagName('a');
            //for (var i = 0; i < elemTDs.length; i++) {
            //    var anchor = anchors[i];
            //    anchor.onclick = function () {
            //        return false;
            //    }
            //}

            var elem = document.getElementById("MainContent_leftpanel");
            <%--var elem = $('#<%= leftpanel.ClientID %>');--%>
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
            //alert('show event info');
            window.location.replace("ViewEvent.aspx");
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
