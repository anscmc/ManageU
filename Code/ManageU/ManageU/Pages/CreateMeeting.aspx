<%@ Page Title="Create Meeting" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="CreateMeeting.aspx.cs" Inherits="ManageU.Pages.CreateMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="find" Text="Find a Time" OnClick="findTime" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center; color:#008CBA; background-color:white;" />
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">

                            <label id="meetingNameLabel" runat="server">Meeting Name</label>
                            <asp:TextBox ID="meetingName" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;color:black;"></asp:TextBox>
                            <label id="meetingDateLabel" runat="server">Date</label>

                            <input type="date" name="meetingDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">

                            <label id="meetingTimeLabel" runat="server">Time</label>
                            <br />
                            <input type="number" ID="meetingStartHour1" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="1" max="12" value="12" CssClass="form-control"  style="display:inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">
                            <label id="Label1" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                            <input type="number" ID="meetingStartMinute1" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="0" max="59" value="00" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;">
                            <select class="selectpicker" ID="amPM" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="createMeetingButton" Text="Create" OnClick="createMeeting" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-top:10px; margin-bottom:10px;text-align: center; color:#008CBA; background-color:white;padding-left:25px;padding-right:25px;" />
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>


    </div>

    <script>
        $('.datepicker').datepicker();
    </script>

</asp:Content>
