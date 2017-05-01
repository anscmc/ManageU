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
        <br />
        <label id="complete" runat="server"></label>
    </div>

    <asp:Button ID="deleteTask" runat="server" Text="Delete" OnClick="deleteTask_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
    <asp:Button ID="editTask" runat="server" Text="Edit" OnClick="editTask_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
    <asp:Button ID="back" runat="server" Text="View All Tasks" OnClick="back_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />

</asp:Content>
