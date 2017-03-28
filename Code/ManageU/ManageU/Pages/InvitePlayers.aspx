<%@ Page Title="Invite Players to Your ManageU" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="InvitePlayers.aspx.cs" Inherits="ManageU.Pages.InvitePlayers" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">
                        <label id="meetingLasting" runat="server" CssClass="form-control"># of players</label>
                        <br />
                        <select class="selectpicker" ID="hours" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                        </select>
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:TextBox runat="server" ID="emailAddresses" placeholder="Email Address" CssClass="form-control" style="display: block; margin: 0 auto;width:250px;height:275px;max-width:250px;max-height:275px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="emailAddresses" CssClass="text-danger" ErrorMessage="Field is required." />
                            <label id="userExistsErr" runat="server" style="color:red; display:none;">You have already invited one or more of the players</label>    
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" Text="Invite" onclick="inviteButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;width:250px;" ID="inviteButton" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>

</asp:Content>
