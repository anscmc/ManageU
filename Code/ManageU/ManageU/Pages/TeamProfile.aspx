<%@ Page Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamProfile.aspx.cs" Inherits="ManageU.Pages.TeamProfile" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    <div id="wrapper">

    <div id="a" class="panels">
        <div class="col-sm-6 col-sm-offset-3" style="text-align:center;padding-left:0px;padding-right:0px;">
            <h2><asp:Label class="info" id="teamName" runat="server" style="font-size:.75em; font-family:'Microsoft YaHei';"></asp:Label></h2>
        <img runat="server" src="~/prof/img/swimteam.jpg" style="box-shadow: 0 0 10px #000;"/>

        <div>
            <asp:Button ID="editButton" runat="server" OnClick="editButton_Click" Text="Edit Team Profile" CssClass="btn btn-default" style="display:block;margin:0 auto;margin-top:5px; margin-bottom:5px; background:rgba(0,140,186,.2);padding:2px;border-radius:5px;border:1px solid black;box-shadow: 0 0 5px #000;"/>
            <asp:Button ID="saveTeamInfo" runat="server" OnClick="saveTeamInfoButton_Click" Text="Save Team Profile" CssClass="btn btn-default editBTN" style="display:block;margin: 0 auto; margin-top:5px; margin-bottom:5px; background:rgba(0,140,186,.2);padding:2px;border-radius:5px;border:1px solid black;box-shadow: 0 0 5px #000;" />
        </div>
    </div>

        <%--<div class="col-sm-12" style="display: block; margin: 0 auto; text-align:center">
            <br />
            <asp:Button ID="editButton" runat="server" OnClick="editButton_Click"  Text="Edit Team Profile" CssClass="btn btn-default" style="display:block;margin: 0 auto;"/>
            <asp:Button ID="saveTeamInfo" runat="server" OnClick="saveTeamInfoButton_Click" Text="Save Team Profile" CssClass="btn btn-default" style="display:block;margin: 0 auto;" />
            <br />
        </div>--%>

        <%--Labels--%>
        <div id="teamInfo" runat="server" class="col-sm-4 box" style="text-align:center; height:175px; box-shadow: 0 0 10px #000; ">
            <%--<div class="col-sm-12" runat="server" style="border:1px solid black;box-shadow: 0 0 10px #000;height:100%;">--%>
            <br />
            <asp:Label class="info" id="division" runat="server"></asp:Label>
            <%--<br />
            <br />
            <asp:Label class="info" id="conference" runat="server" style="font-size:1.5em;"></asp:Label>--%>
            <br />
            <br />
            <asp:Label class="info" id="wins" runat="server"></asp:Label>
            <asp:Label class="info" Text=" - " runat="server"></asp:Label>
            <asp:Label class="info" id="losses" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="location" runat="server"></asp:Label>
        </div>
        <div id="coachInfo" runat="server" class="col-sm-4 box" style="text-align:center; height:175px; box-shadow: 0 0 10px #000;">
            <br />
            <asp:Label class="info" id="headCoach" runat="server" ></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="coachNumber" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label class="info" id="coachEmail" runat="server"></asp:Label>
        </div>
        <div id="linkInfo" runat="server" class="col-sm-4 box" style="text-align:center; height:175px; box-shadow: 0 0 10px #000;">
            <br />
            <asp:HyperLink class="info" ID="schoolSite" runat="server">School Website</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink class="info" ID="siteTeam" runat="server">Team Website</asp:HyperLink>
            <br />
            <br />
            <asp:Hyperlink class="info" ID="calendarHyp" href="TeamCalendar.aspx" runat="server">Team Calendar</asp:Hyperlink>
        </div>

        <%--Text Boxes--%>
        <div id="editTeam" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">Division</asp:Label>
            <asp:TextBox ID="division2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Conference</asp:Label>
            <asp:TextBox ID="conference2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
        </div>
        <div id="editCoach" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">Location</asp:Label>
            <asp:TextBox ID="location2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Wins</asp:Label>
            <asp:TextBox ID="wins2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Losses</asp:Label>
            <asp:TextBox ID="losses2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>

        </div>
        <div id="editLink" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">School Website</asp:Label>
            <asp:TextBox ID="schoolSite2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Team Website</asp:Label>
            <asp:TextBox ID="siteTeam2" runat="server" CssClass="form-control" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <br />
            <br />
            <asp:FileUpload ID="profilePicUpload" runat="server" style="display: none;"/>
            <asp:GridView ID="profilePicGrid" runat="server" AutoGenerateColumns="false" ShowHeader="false" style="display: block; margin: 0 auto">
                <Columns>
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>

        </div>
        <div class="col-sm-12" style="text-align:left;padding-top:20px;">
            <hr/>
            <footer id="footer">
                <p>&copy; <%: DateTime.Now.Year %> - ManageU</p>
            </footer>
        </div>

    </div>

 

</asp:Content>


<%--Must uncomment in master file also--%>
<%--<asp:Content runat="server" ID="foot" ContentPlaceHolderID="foot">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    
    <%--Footer in TeamProfile.master

</asp:Content>--%>


