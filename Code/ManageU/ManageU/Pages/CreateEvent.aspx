<%@ Page Title="Create Event" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="ManageU.Pages.CreateMeeting" %>
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



                            <label id="eventNameLabel" runat="server">Event Name</label>
                            <asp:TextBox ID="EventName" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;color:black;"></asp:TextBox>
                            <br />
                            <label id="Label5" runat="server">Event Type</label>
                            <br />
                            <select class="selectpicker" ID="eventType" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:250px;border-radius:5px;">
                                    <option value="Game">Game</option>
                                    <option value="Practice">Practice</option>
                                    <option value="Meeting">Meeting</option>
                                    <option value="Other">Other</option>
                            </select>
                            <br />
                            <label id="eventStartDateLabel" runat="server">Start Date</label>

                            <input type="date" name="eventStartDate" id="eventStartDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">

                            <label id="eventEndDateLabel" runat="server">End Date</label>
                            <br />
                            <input type="date" name="eventEndDate" id="eventEndDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">

                            <label id="eventStartTimeLabel" runat="server"> Start Time</label>
                            <br />
                            
                            <input type="number" ID="eventStartHour" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="1" max="12" value="12" CssClass="form-control"  style="display:inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">
                            <label id="Label1" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                            <input type="number" ID="eventStartMinute" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="0" max="59" value="00" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;">
                            <select class="selectpicker" ID="beginAmPM" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                            <br />
                            <label id="Label3" runat="server"> End Time</label>
                            <br />
                            <input type="number" ID="eventEndHour" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="1" max="12" value="12" CssClass="form-control"  style="display:inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">
                            <label id="Label4" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                            <input type="number" ID="eventEndMinute" onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;" runat="server" min="0" max="59" value="00" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;">
                            <select class="selectpicker" ID="endingAmPm" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                            <br />

                            <label id="Label6" runat="server">Reoccurring</label>
                            <br />
                            <select class="selectpicker" ID="repeatPicker" runat="server" CssClass="form-control" style="width:250px;display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:250px;border-radius:5px;">
                                    <option value="Never">Never</option>
                                    <option value="Daily">Daily</option>
                                    <option value="Weekly">Weekly</option>
                            </select>
                            <br />
                            <label id="Label2" runat="server">Until</label>
                            <br />
                            <input type="date" name="repeatUntilDate" id="repeatUntilDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">
                            <br />
                            <label for="male" style="display:inline;text-align:center;">Attendance Required</label>
                            <input type="checkbox" name="chk_group[]" id="required" style="display: inline;" runat="server" />         
                             <br />
                            
                                <asp:TextBox runat="server" ID="eventDes" TextMode="multiline" placeholder="Enter Description" CssClass="form-control" style="display: block; margin: 0 auto;"/>
                            
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button ID="createEventButton" Text="Create" OnClick="createEventButton_Click" CssClass="btn btn-default" style="width:250px; max-height:200px; display:block; margin:0 auto; margin-top:10px; margin-bottom:10px; text-align:center; color:#008CBA; background-color:white; padding-left:25px; padding-right:25px;" runat="server"/>
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>


    <%--</div>--%>

    <script>
        $('.datepicker').datepicker();
    </script>

</asp:Content>
