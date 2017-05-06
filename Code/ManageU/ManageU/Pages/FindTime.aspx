<%@ Page Title="Find Available Times" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="FindTime.aspx.cs" Inherits="ManageU.Pages.FindTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">

                            <div class="form-group">
                                <label id="meetingLasting" runat="server" CssClass="form-control">Meeting Lasting</label>
                                <br />
                                <select class="selectpicker" ID="hours" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="0">0</option>
                                        <option value="1">1</option>
                                        <option value="2">2</option>
                                        <option value="3">3</option>
                                        <option value="4">4</option>
                                        <option value="5">5</option>
                                        <option value="6">6</option>
                                        <option value="7">7</option>
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                </select>
                                <label id="hoursLabel" runat="server" CssClass="form-control" style="display:inline">hours</label>
                                <select class="selectpicker" ID="minutes" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="0">0</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                </select>
                                <label id="Label4" runat="server" CssClass="form-control" style="display:inline">minutes</label>
                            </div>
                            <br />

                            <div class="form-group" style="margin-bottom:0px">
                            <label id="meetingDateLabel" runat="server" CssClass="form-control" style="display:block;">Date Range</label>
                                <input type="date" id="date1" name="date1" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:200px;height:39px;border-radius:5px;color:black;">
                                <br />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="date1"
                                CssClass="text-danger" ErrorMessage="Field is required." />
                            <br />
                                <label id="days" runat="server" style="display:block;"> to </label>
                                
                                <input type="date" id="date2" name="date2" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:200px;height:39px;border-radius:5px;color:black;">
                                <br />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="date2"
                                CssClass="text-danger" ErrorMessage="Field is required." />
                            <br />
                                <%--<input type="number" ID="nextDays" min="1" max="60" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">--%>
                                <%--<label id="days" runat="server" style="display:inline">days</label>--%>
                            </div>
                            <br />
                            <div class="form-group">
                                <label id="between" runat="server" CssClass="form-control">Between</label>
                                <br />
                                <%--<input type="number" ID="meetingStartHour1" min="1" max="12" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">--%>
                                <select class="selectpicker" ID="meetingStartHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="1">1</option>
                                        <option value="2">2</option>
                                        <option value="3">3</option>
                                        <option value="4">4</option>
                                        <option value="5">5</option>
                                        <option value="6">6</option>
                                        <option value="7">7</option>
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                </select>
                                <label id="Label1" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                                <%--<input type="number" ID="meetingStartMinute1" min="0" max="59" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;">--%>
                                <select class="selectpicker" ID="meetingStartMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                </select>
                                <select class="selectpicker" ID="amPMstart" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                                
                                <br />

                                <label id="and" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">and</label>
                                <br />
                                <select class="selectpicker" ID="meetingEndHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="1">1</option>
                                        <option value="2">2</option>
                                        <option value="3">3</option>
                                        <option value="4">4</option>
                                        <option value="5">5</option>
                                        <option value="6">6</option>
                                        <option value="7">7</option>
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                </select>
                                <label id="Label2" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                                <%--<input type="number" ID="meetingStartMinute1" min="0" max="59" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;">--%>
                                <select class="selectpicker" ID="meetingEndMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                </select>
                                <select class="selectpicker" ID="amPMend" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="findMeetingTimes" Text="Find Available Times" OnClick="findTimes" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center; color:#008CBA; background-color:white;width:200px;" />
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    
    </div>

</asp:Content>
