<%@ Page Title="Lifts" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Lifts.aspx.cs" Inherits="ManageU.Pages.Lifts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <asp:Button runat="server" ID="createLiftButton" Text="Add" onclick="createLiftButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>

    </div>

</asp:Content>
