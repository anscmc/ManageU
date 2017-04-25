<%@ Page Title="View Task" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="ViewTask.aspx.cs" Inherits="ManageU.Pages.viewTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
    
    <label id="name" runat="server"></label>
        <br />
        <label id="duedate" runat="server"></label>
        <br />
        <label id="duetime" runat="server"></label>
        <br />
        <label id="desc" runat="server"></label>
    </div>

</asp:Content>
