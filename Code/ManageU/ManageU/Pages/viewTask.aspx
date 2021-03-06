﻿<%@ Page Title="View Task" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="ViewTask.aspx.cs" Inherits="ManageU.Pages.viewTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>


        <label id="Label1" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Name</label>
        <br />
        <label id="name" runat="server"></label>
        <br />
        <label id="Label2" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Due Date</label>
        <br />
        <label id="duedate" runat="server"></label>
        <br />
        <label id="Label3" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Due Time</label>
        <br />
        <label id="duetime" runat="server"></label>
        <br />
        <label id="Label4" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Description</label>
        <br />
        <label id="desc" runat="server"></label>
        <br />
        <label id="Label5" runat="server" style="color:#ba9800;font-size:16px;font-weight:bold;">Completed By</label>
        <br />
        <label id="complete" runat="server"></label>
    </div>
    <asp:Button ID="deleteTask" runat="server" Text="Delete" OnClick="deleteTask_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;width:250px;" />
    <asp:Button ID="editTask" runat="server" Text="Edit" OnClick="editTask_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;width:250px;" />
    <asp:Button ID="back" runat="server" Text="View All Tasks" OnClick="back_Click" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;width:250px;" />

</asp:Content>
