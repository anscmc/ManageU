<%@ Page Title="My Info" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="ManageU.Pages.MyInfo" %>
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
                        <div class="col-sm-6 col-sm-offset-3">

        <label id="fNameLabel" runat="server">First Name</label>
        <asp:TextBox ID="fName" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
        <label id="lNameLabel" runat="server">Last Name</label>
        <asp:TextBox ID="lName" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
        <label id="numLabel" runat="server">Phone Number</label>
        <asp:TextBox ID="phoneNum" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
        <label id="positionLabel" runat="server">Position</label>
        <asp:TextBox ID="position" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
        <label id="classLabel" runat="server">Class</label>
        <asp:TextBox ID="playerClass" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
        <label id="playerNumLabel" runat="server">Number</label>
        <asp:TextBox ID="playerNum" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>



                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" ID="saveInfoButton" Text="Save" onclick="saveInfoButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>

</asp:Content>
