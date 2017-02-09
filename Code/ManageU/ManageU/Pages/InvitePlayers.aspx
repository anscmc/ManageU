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
                            <asp:TextBox runat="server" ID="emailAddresses" TextMode="multiline" placeholder="Enter email address(es)" CssClass="form-control" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="emailAddresses" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" Text="Invite" onclick="inviteButton_Click" CssClass="btn btn-default" width=125 style="display: block; margin: 0 auto;" ID="reg" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>

</asp:Content>
