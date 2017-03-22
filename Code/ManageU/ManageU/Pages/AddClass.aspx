<%@ Page Title="Add a Class" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="ManageU.Pages.AddClass" %>
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

                            <div class="form-group">
                                <label id="classNameLabel" runat="server">Class Name</label>
                                <asp:TextBox ID="className" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;height:39px;"></asp:TextBox>
                                <br />
<%--                            </div>--%>
                            <%--<br />--%>

<%--                            <div class="form-group">--%>
                                <label id="date1" runat="server" CssClass="form-control" style="display:block;">Start Date</label>
                                <input type="date" name="startDate" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;margin-bottom:5px !important;">
                                <label id="date2" runat="server" style="display:block;">End Date</label>
                                <input type="date" name="endDate" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">
                            </div>
                            <br />
                            <div class="form-group">
                                <label id="between" runat="server" CssClass="form-control">Between</label>
                                <br />
                                <select class="selectpicker" ID="startHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <input type="number" name="startMinute" runat="server" CssClass="form-control" min="0" max="59" style="display: inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">
                                <%--<select class="selectpicker" ID="startMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                </select>--%>
                                <select class="selectpicker" ID="amPMstart" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                                
                                <br />

                                <label id="and" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">and</label>
                                <br />
                                <select class="selectpicker" ID="endHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <input type="number" name="endMinute" runat="server" CssClass="form-control" min="0" max="59" style="display: inline; margin: 0 auto;text-align: center; width:50px;height:39px;border-radius:5px;">
                                <%--<select class="selectpicker" ID="endMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                </select>--%>
                                <select class="selectpicker" ID="amPMend" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                                <br />
                                <label id="days" runat="server">Days</label>
                                <br />

                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">Sun</label>
                                        <input type="checkbox" name="chk_group[]" id="sun" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">M</label>
                                        <input type="checkbox" name="chk_group[]" id="mon" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">T</label>
                                        <input type="checkbox" name="chk_group[]" id="tue" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">W</label>
                                        <input type="checkbox" name="chk_group[]" id="wed" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">TH</label>
                                        <input type="checkbox" name="chk_group[]" id="thu" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">F</label>
                                        <input type="checkbox" name="chk_group[]" id="fri" style="display: table-row;width: 100%;" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">Sat</label>
                                        <input type="checkbox" name="chk_group[]" id="sat" style="display: table-row;width: 100%;" />         
                                    </div>


                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="addClass" Text="Add to Schedule" OnClick="addButtonClick" CssClass="btn btn-default" style="display: block; margin: 0 auto;text-align: center; color:#008CBA; background-color:white; width:250px !important " />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    
    </div>

</asp:Content>
