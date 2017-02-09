<%@ Page Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamProfile.aspx.cs" Inherits="ManageU.Pages.TeamProfile" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

<%--    <div style="top:5px; margin: 0 auto; text-align: center;">
        <h2><%: Title %></h2>
    </div>--%>


    <div id="wrapper">
    <div id="a" class="panels">
        <div class="col-sm-6 col-sm-offset-3" style="text-align:center;">
            <h2><%: Title %></h2>
        <img runat="server" src="~/prof/img/swimteam.jpg" />
        <div>
        <br />
        </div>
    </div>

        <div class="form-group">
                <%--<div class="col-sm-6 col-sm-offset-3">--%>
                <asp:Button id="editButton" runat="server" Text="Edit" CssClass="btn btn-default" OnClientClick="switchToSave();" OnClick="editButton_Click" style="display: block; margin: 0 auto; width:125px; height:25px;" />
                
        </div>

        <div class="col-sm-4" style="text-align:center; border:1px solid black; height:175px;">
            <br />
            <label id="teamName" runat="server"></label>
            <asp:Label class="info" id="division" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="conference" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="wins" runat="server"></asp:Label>
            <asp:Label class="info" id="losses" runat="server"></asp:Label>

            <br />
        </div>
        <div class="col-sm-4" style="text-align:center; border:1px solid black; height:175px;">
            <br />
            <asp:Label class="info" id="headCoach" runat="server"></asp:Label>
            <asp:Label class="info" id="coachNumber" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="location" runat="server"></asp:Label>
            <br />
            <br />
            <%--<asp:Label class="info" id="schoolName" runat="server"></asp:Label>--%>
            <br />
        </div>
        <div class="col-sm-4" style="text-align:center; border:1px solid black; height:175px;">
            <br />
            <asp:HyperLink class="info" ID="schoolSite" href="http://www.gannon.edu" runat="server"></asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink class="info" ID="siteTeam" href="http://www.gannonsports.com/index.aspx?path=mswim" runat="server"></asp:HyperLink>
            <br />
            <br />
            <asp:Hyperlink class="info" ID="calendarHyp" href="~/Pages/TeamCalendar.aspx" runat="server"></asp:Hyperlink>
            <br />
        </div>
        <div class="col-sm-4" style="text-align:center; border:1px solid black; height:175px;">
            <asp:TextBox ID="division2" runat="server"></asp:TextBox>

        <asp:TextBox ID="conference2" runat="server"></asp:TextBox>

        <asp:TextBox ID="wins2" runat="server"></asp:TextBox>

        <asp:TextBox ID="losses2" runat="server"></asp:TextBox>

        <asp:TextBox ID="location2" runat="server"></asp:TextBox>

        <asp:TextBox ID="schoolSite2" runat="server"></asp:TextBox>

        <asp:TextBox ID="siteTeam2" runat="server"></asp:TextBox>
        </div>
    </div>
    </div>

</asp:Content>


<%--Must uncomment in master file also--%>
<%--<asp:Content runat="server" ID="foot" ContentPlaceHolderID="foot">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    
    <%--Footer in TeamProfile.master

</asp:Content>--%>


