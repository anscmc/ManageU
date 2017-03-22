<%@ Page Title="Tasks" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="ManageU.Pages.Tasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    
    <%--<div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            
        </div>
    </div>
    </div>--%>

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Create Task" OnClick="createTask" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
        </div>
        <div>
            <br />
        </div>
        <div id="tasksDiv" class="col-sm-6 col-sm-offset-3" style="padding:0px" runat="server">

        </div>
    
    
    </div>

</asp:Content>
