<%@ Page Title="Create Task" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="ManageU.Pages.WebForm1" %>
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

                            <label id="taskNameLabel" runat="server">Task Name</label>
                            <asp:TextBox ID="taskName" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;height:39px;"></asp:TextBox>
                            <label id="taskDueDate" runat="server">Date Due</label>
                            <input type="date" name="dueDate" id="dueDate2" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px; color:black !important;">
                            <label id="taskTimeDue" runat="server">Time Due</label>
                            <br />
                            <%--onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;"--%>
                            <input type="number" ID="meetingStartHour1" runat="server" min="1" max="12" value="12" CssClass="form-control"  style="display:inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;color:black !important;">
                            <label id="Label1" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                            <input type="number" ID="meetingStartMinute1" runat="server" min="0" max="59" value="00" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;width:50px;height:39px;border-radius:5px;color:black !important;">
                            <select class="selectpicker show-menu-arrow" ID="amPM" runat="server"  style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                            <br />
                            <label id="taskDesLabel" runat="server">Task Description</label>
                            <asp:TextBox ID="taskDes" runat="server" CssClass="form-control" TextMode="MultiLine" style="display: block; margin: 0 auto;width:250px; height:100px; max-width:250px;"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="createTaskButton" Text="Create" OnClick="createTask" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>
</asp:Content>
