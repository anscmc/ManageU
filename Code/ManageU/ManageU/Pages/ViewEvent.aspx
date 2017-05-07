<%@ Page Title="Event Details" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="ViewEvent.aspx.cs" Inherits="ManageU.Pages.ViewMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div runat="server" id="outerDiv" style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

            <label id="Label1" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Event Name</label>
            <br />
            <label id="eventName" runat="server">Event Name</label>
            <br />
            <label id="Label2" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Event Type</label>
            <br />
            <label id="eventType" runat="server">Event Type</label>
            <br />
            <label id="Label3" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Event Start</label>
            <br />
            <label id="eventStart" runat="server">Event Start</label>
            <br />
            <label id="Label4" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Event End</label>
            <br />
            <label id="eventEnd" runat="server">Event end</label>
            <br />
            <label id="Label5" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Reoccurence</label>
            <br />
            <label id="eventReoccur" runat="server">Reocurring</label>
            <br />
            <label id="Label6" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Attendence Required</label>
            <br />
            <label id="attendanceRequired" runat="server">Attendance Required</label>
            <br />
            <label id="Label7" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Description</label>
            <br />
            <label id="des" runat="server">Event Description</label>
            <br />


        <div class="row">
            <div id="Div1" class="col-xs-6" runat="server">
                <label style="color:#ba9800;font-size:16px;font-weight:bold;">Attending:</label>
                <br />
            </div>
            <div id="Div2" class="col-xs-6" runat="server">
                <label style="color:#ba9800;font-size:16px;font-weight:bold;">Not Attending:</label>
                <br />
            </div>
            <div id="attendingDiv" class="col-xs-6" runat="server">
                
            </div>

            <div id="notAttendingDiv" class="col-xs-6" runat="server">
                
            </div>
        </div>

        <div style="margin-top:5px;margin-bottom:5px;">
            <asp:Button ID="editEvent" runat="server" Text="Edit Event" CssClass="btn btn-default" style="margin: 0 auto;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;" OnClick="editEvent_Click"/>
            <asp:Button ID="deleteEvent" runat="server" Text="Delete Event" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:1px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;height:39px;" OnClick="deleteEvent_Click" />
            <asp:Button ID="back" runat="server" Text="Back to Calendar" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:1px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;height:39px;" OnClick="back_Click" />
        </div>
    
    
    
    </div>

</asp:Content>
