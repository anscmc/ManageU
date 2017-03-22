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
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:TextBox runat="server" ID="emailAddresses" TextMode="multiline" placeholder="Enter email address(es)" CssClass="form-control" style="display: block; margin: 0 auto;width:250px;height:275px;max-width:250px;max-height:275px"/>
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
