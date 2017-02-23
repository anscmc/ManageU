<%@ Page Title="Contact Your Team" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ManageU.Pages.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="text-align:center">
                            <asp:TextBox runat="server" ID="emailAddresses" TextMode="multiline" placeholder="Enter email address(es)" CssClass="form-control" Width="250px" Height="120px" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="emailAddresses" CssClass="text-danger" ErrorMessage="Field is required." />
                            <asp:TextBox runat="server" ID="messageSubject" TextMode="SingleLine" placeholder="Enter Subject" CssClass="form-control" Width="250px" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="messageSubject" CssClass="text-danger" ErrorMessage="Field is required." />
                            <asp:TextBox runat="server" ID="messageBody" TextMode="multiline" placeholder="Enter Message" CssClass="form-control" Width="250px" Height="180px" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="messageBody" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" Text="Send" onclick="emailButton_Click" CssClass="btn btn-default" width=125 style="display: block; margin: 0 auto;" ID="emailButton" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>
</asp:Content>
