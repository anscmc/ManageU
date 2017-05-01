<%@ Page Title="Event Details" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="ViewEvent.aspx.cs" Inherits="ManageU.Pages.ViewMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <div id="detailsDiv" class="detailsDiv" runat="server" style="text-align:center !important;">
            <label id="eventName" runat="server">Event Name</label>
            <br />
            <label id="eventType" runat="server">Event Type</label>
            <br />
            <label id="eventStart" runat="server">Event Start</label>
            <br />
            <label id="eventEnd" runat="server">Event end</label>
            <br />
        </div>

        <div class="row">
            <div id="attendingDiv" class="col-xs-6">
                Attending:
                <br />
                asdf
            </div>
            <div id="notAttendingDiv" class="col-xs-6">
                Not Attending:
                <br />
                asdf
            </div>
        </div>

        <div style="margin-top:5px;margin-bottom:5px;">
            <asp:Button ID="editEvent" runat="server" Text="Edit Event" CssClass="btn btn-default" style="margin: 0 auto;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;"/>
            <asp:Button ID="deleteEvent" runat="server" Text="Delete Event" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:1px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;height:39px;" />
        </div>
    
    
    
    </div>

</asp:Content>
