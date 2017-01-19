<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ManageU.Pages.Register" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <section id="loginForm">
                <div class="form-horizontal">

                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="form-group">
                    <div class="col-sm-6">
                    <select class="selectpicker" ID="sport" CssClass="form-control" style="color:black;">
                        <option>Mustard</option>
                        <option>Ketchup</option>
                        <option>Relish</option>
                    </select>

                    </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="email" CssClass="form-control" width=250 placeholder="Email" TextMode="Email" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                                CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="pass1" TextMode="Password" placeholder="Password" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="pass1" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="pass2" TextMode="Password" placeholder="Re-Enter Password" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="pass2" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="first" TextMode="SingleLine" placeholder="First Name" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="first" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="last" TextMode="SingleLine" placeholder="Last Name" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="last" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="phone" TextMode="Number" placeholder="Phone Number" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="phone" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="university" TextMode="SingleLine" placeholder="University" CssClass="form-control" width=250 style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="university" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:Button runat="server" Text="Register" CssClass="btn btn-default" PostBackUrl="~/Pages/Landing.aspx" width=125 style="display: block; margin: 0 auto;" ID="reg" />
                        </div>
                    </div>

                </div>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
            </section>
        </div>
    </div>
</asp:Content>
