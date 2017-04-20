<%@ Page Title="Add Lift" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AddLift.aspx.cs" Inherits="ManageU.Pages.AddLift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <div id="liftContainer">
            <label id="liftNameLabel" runat="server">Name of lift</label>
            <asp:TextBox ID="liftName" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
            <asp:Button runat="server" ID="newLiftButton" Text="Add Lift" onclick="newLiftButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
            <br />
            <div id="newlyAddedLifts" runat="server"></div>
            <%--<div id="lift1" style="display: none;" runat="server">
                <label id="lift1NameLabel" runat="server">Lift Name</label>
                <asp:TextBox ID="lift1Name" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <label id="lift1SetsLabel" runat="server">Sets</label>
                <asp:TextBox ID="lift1Sets" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <label id="lift1RepsLabel" runat="server">Reps</label>
                <asp:TextBox ID="lift1Reps" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="deleteLift1" Text="Delete" onclick="delete_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
            </div>--%>
            <br />
            
    
        </div>

        <asp:Button runat="server" ID="addLiftButton" Text="Add Workout" onclick="addLiftButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
    </div>
</asp:Content>
