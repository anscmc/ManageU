<%@ Page Title="Sandbox" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Sandbox.aspx.cs" Inherits="ManageU.Pages.Sandbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <div id="playerScheduleDiv" class="col-sm-10 col-sm-offset-1" runat="server" style="padding:0px;margin:0 auto;">
            <div class="classDiv">
                    <div id="classTimes" class="col-sm-4" runat="server" style="float:left;width:25%;border:1px solid white;vertical-align:middle;text-align:center;">
                        <label id="classStartTime" >3:00</label>
                        <br />
                        <label id="classEndTime" >4:20</label>

                    </div>
                    <div id="classDets" class="col-sm-4" runat="server" style="float:left;width:50%;border:1px solid white;vertical-align:middle;text-align:center;">
                        <label id="className" >Senior Design Lab</label>
                        <br />
                        <label id="classDays" > T TH</label>
                    </div>
                    <div id="classDates" class="col-sm-4" runat="server" style="float:left;width:25%;border:1px solid white;vertical-align:middle;text-align:center;">
                        <label id="classStartDate" >1/9/2017</label>
                        <br />
                        <label id="classEndDate" >5/5/2017</label>
                    </div>
            </div>
        </div>

        <div id="availableTimesDiv" class="col-sm-12" style="padding:0px" runat="server">



        </div>

        <div id="viewMeetingDiv" class="col-sm-12" style="padding:0px" runat="server">



        </div>

        <div id="viewTaskDiv" class="col-sm-12" style="padding:0px" runat="server">

            <%--<div id="task1" class="col-sm-4 taskDetails" runat="server">


            </div>--%>

        </div>

        <div id="misc" class="col-sm-6 col-sm-offset-3" style="padding:0px" runat="server">

        </div>

    </div>

</asp:Content>
