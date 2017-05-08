<%@ Page Title="Register" Language="C#" MasterPageFile="~/Masters/Landing.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ManageU.Pages.Register" Async="true" %>

<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
    <h2 style="margin-top:0px; padding-top:0px;"><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3"  style="height:40px !important">
                            <select class="selectpicker show-menu-arrow" ID="sportType" style="color:black;height:39px;width:250px;border-radius:5px;margin-bottom:20px;" runat="server">
                                <option value="" selected disabled>Select Your Sport</option>
                                <option value="Baseball">Baseball</option>
                                <option value="Basketball - Men's">Basketball - Men's</option>
                                <option value="Basketball - Women's">Basketball - Women's</option>
                                <option value="Cross Country - Men's">Cross Country - Men's</option>
                                <option value="Cross Country - Women's">Cross Country - Women's</option>
                                <option value="Field Hockey">Field Hockey</option>
                                <option value="Football">Football</option>
                                <option value="Golf - Men's">Golf - Men's</option>
                                <option value="Golf - Women's">Golf - Women's</option>
                                <option value="Ice Hockey - Men's">Ice Hockey - Men's</option>
                                <option value="Ice Hockey - Women's">Ice Hockey - Women's</option>
                                <option value="Lacrosse - Men's">Lacrosse - Men's</option>
                                <option value="Lacrosse - Women's">Lacrosse - Women's</option>
                                <option value="Soccer - Men's">Soccer - Men's</option>
                                <option value="Soccer - Women's">Soccer - Women's</option>
                                <option value="Softball">Softball</option>
                                <option value="Swimming - Men's">Swimming - Men's</option>
                                <option value="Swimming - Women's">Swimming - Women's</option>
                                <option value="Tennis - Men's">Tennis - Men's</option>
                                <option value="Tennis - Women's">Tennis - Women's</option>
                                <option value="Track & Field(Indoor) - Men's">Track & Field(Indoor) - Men's</option>
                                <option value="Track & Field(Indoor) - Women's">Track & Field(Indoor) - Women's</option>
                                <option value="Track & Field(Outdoor) - Men's">Track & Field(Outdoor) - Men's</option>
                                <option value="Track & Field(Outdoor) - Women's">Track & Field(Outdoor) - Women's</option>
                                <option value="Volleyball - Men's">Volleyball - Men's</option>
                                <option value="Volleyball - Women's">Volleyball - Women's</option>
                                <option value="Water Polo - Men's">Water Polo - Men's</option>
                                <option value="Water Polo - Women's">Water Polo - Women's</option>
                                <option value="Wrestling">Wrestling</option>
                        </select>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="email" CssClass="form-control inputBoxes" placeholder="Email" TextMode="Email" style="display: block; margin: 0 auto;"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                                CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="pass1" TextMode="Password" placeholder="Password" CssClass="form-control inputBoxes" style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="pass1" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="pass2" TextMode="Password" placeholder="Re-Enter Password" CssClass="form-control inputBoxes" style="display: block; margin: 0 auto;" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="pass2" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="first" TextMode="SingleLine" placeholder="First Name" CssClass="form-control inputBoxes" style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="first" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="last" TextMode="SingleLine" placeholder="Last Name" CssClass="form-control inputBoxes"  style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="last" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="phone" TextMode="Number" placeholder="Phone Number" min="1000000000" max="9999999999" CssClass="form-control inputBoxes" style="display: block; margin: 0 auto;width:250px;height:39px;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="phone" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:TextBox runat="server" ID="univ" TextMode="SingleLine" placeholder="University" CssClass="form-control inputBoxes" style="display: block; margin: 0 auto;" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="univ" CssClass="text-danger" ErrorMessage="Field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3" style="height:40px !important">
                            <asp:Button runat="server" Text="Register" onclick="registerButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;width:250px;height:39px;" ID="reg" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
        

<%--        <div class="col-md-4">
            <section id="socialLoginForm">
            </section>
        </div>--%>
    </div>
    </div>

</asp:Content>