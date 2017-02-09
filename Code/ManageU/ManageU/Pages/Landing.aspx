<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Masters/Landing.Master" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="ManageU.Pages.Landing" Async="true" %>

<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <script type="text/javascript">
        function loginError() {
            document.getElementById('loginErr').style.display = "inline-block";
        }
    </script>
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <%--<section id="loginForm">--%>
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" placeholder="Email" width=250 TextMode="Email" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" placeholder="Password" CssClass="form-control" style="display: block; margin: 0 auto; width:250px;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <%--<div class="col-sm-6 col-sm-offset-3">--%>
                            <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" OnClick="loginButton_Click" width=125 style="display: block; margin: 0 auto;" ID="loginButton" />
                            <label id="loginErr" style="color: Red; display: none;">Invalid username or password. Please try again.</label>
                        </div>
                        </div>
                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:HyperLink runat="server" ID="registerLink"  href="Register.aspx" ViewStateMode="Enabled">New User? Register</asp:HyperLink>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:HyperLink runat="server" ID="forgotpassLink"  ViewStateMode="Enabled">Forgot your password?</asp:HyperLink>
                        </div>
                    </div>

                </div>
            <%--</section>--%>
        </div>
    </div>

</asp:Content>


