<%@ Page Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamProfile.aspx.cs" Inherits="ManageU.Pages.TeamProfile" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    <div id="wrapper">

    <div id="a" class="panels">
        <div class="col-sm-6 col-sm-offset-3" style="text-align:center;padding-left:0px;padding-right:0px;">
            <h2><asp:Label class="info" id="teamName" runat="server" style="font-size:.75em; font-family:'Microsoft YaHei';"></asp:Label></h2>
        <img runat="server" src="~/prof/img/swimteam.jpg" />
    </div>

        <%--Labels--%>
        <div id="teamInfo1">
            <div class="container">
                <div id="teamDivision" runat="server" class="col-sm-4 square" style="display:inline-block;float:left;text-align:center;border:1px solid #008CBA; color:#008CBA;">
                    <%--<div class="content">--%>
                        <asp:Label class="info" id="division" runat="server"></asp:Label>
                    <%--</div>--%>
                </div>
                <div id="teamConference" runat="server" class="col-sm-4 square" style="display:inline-block;float:left;text-align:center;border:1px solid #008CBA; color:#008CBA;">
                    <%--<div class="content">--%>
                        <asp:Label class="info" id="conference" runat="server"></asp:Label>
                    <%--</div>--%>
                </div>
                <div id="teamRecord" runat="server" class="col-sm-4 square" style="display:inline-block;float:left;text-align:center;border:1px solid #008CBA; color:#008CBA;">
                    <%--<div class="content">--%>
                        <asp:Label id="wins" runat="server" style="display:none"></asp:Label>
                        <asp:Label id="losses" runat="server" style="display:none"></asp:Label>
                        <asp:Label class="info" ID="record" runat="server"></asp:Label>
                    <%--</div>--%>
                </div>
                <div id="teamLocation" runat="server" class="col-sm-4 square" style="display:inline-block;float:left;text-align:center;border:1px solid #008CBA; color:#008CBA;">
                    <%--<div class="content">--%>
                        <asp:Label class="info" id="location" runat="server"></asp:Label>
                    <%--</div>--%>
                </div>
            </div>

            <div id="coachInfo" runat="server" class="col-sm-4 box" style="display:inline-block;float:left;text-align:center; height:175px;border:1px solid #008CBA;color:#008CBA;width:50%">
                <br />
                <asp:Label class="info" id="headCoach" runat="server" ></asp:Label>
                <br />
                <br />
                <asp:Label class="info" id="coachNumber" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label class="info" id="coachEmail" runat="server"></asp:Label>
            </div>
            <div id="linkInfo" runat="server" class="col-sm-4 box" style="display:inline-block;float:left;text-align:center; height:175px;border:1px solid #008CBA;width:50%">
                <br />
                <asp:HyperLink class="info" ID="schoolSite" runat="server" style="font-size:1em !important">School Website</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink class="info" ID="siteTeam" runat="server" style="font-size:1em !important">Team Website</asp:HyperLink>
                <br />
                <br />
                <asp:Hyperlink class="info" ID="calendarHyp" href="TeamCalendar.aspx" runat="server" style="font-size:1em !important">Team Calendar</asp:Hyperlink>
            </div>
            </div>
        

        <%--Text Boxes--%>
        <div id="editTeam" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">Division</asp:Label>
            <asp:TextBox ID="divisionPicker" runat="server" CssClass="form-control inputBoxes" width=250 style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            
            <%--<select class="selectpicker" ID="divisionPicker" runat="server" CssClass="form-control" style="display:block; margin: 0 auto;text-align: center; color:black;width:250px;height:39px;border-radius:5px;">
                <option>I-A</option>
                <option>I-AA</option>
                <option>II</option>
                <option>III</option>
                <option>NAIA</option>
            </select>--%>
            
            <asp:Label runat="server" style="margin: 0 auto">Conference</asp:Label>
            <asp:TextBox ID="conference2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
        </div>
        <div id="editCoach" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">Location</asp:Label>
            <asp:TextBox ID="location2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto;border:1px solid black;"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Wins</asp:Label>
            <asp:TextBox ID="wins2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Losses</asp:Label>
            <asp:TextBox ID="losses2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>

        </div>
        <div id="editLink" runat="server" class="col-sm-4" style="text-align:center; height:auto;">
            <asp:Label runat="server" style="margin: 0 auto">School Website</asp:Label>
            <asp:TextBox ID="schoolSite2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            <asp:Label runat="server" style="margin: 0 auto">Team Website</asp:Label>
            <asp:TextBox ID="siteTeam2" runat="server" CssClass="form-control inputBoxes" style="text-align:center;display: block; margin: 0 auto"></asp:TextBox>
            
            <asp:Label runat="server" style="margin: 0 auto">Team Photo</asp:Label>
            <br />
            <asp:FileUpload ID="profilePicUpload" CssClass="btn btn-default" runat="server" style="display: none;"/>
            <asp:GridView ID="profilePicGrid" runat="server" CssClass="form-control" AutoGenerateColumns="false" ShowHeader="false" style="margin: 0 auto;">
                <Columns>
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>

        <div style="margin-top:5px;margin-bottom:5px;">
        <asp:Button ID="editButton" runat="server" OnClick="editButton_Click" Text="Edit Team Profile" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;"/>
        <asp:Button ID="saveTeamInfo" runat="server" OnClick="saveTeamInfoButton_Click" Text="Save Team Profile" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;height:39px;" />
        </div>
        <asp:Button ID="playerSched" runat="server" OnClick="playerSched_Click" Text="Sched" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;margin-top:10px !important;text-align: center;border: 2px solid white;width:95%;max-width:400px;height:39px;" />
        </div>

        <div>
        <%--<asp:Button ID="editButton" runat="server" OnClick="editButton_Click" Text="Edit Team Profile" CssClass="btn btn-default" style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white; padding:2px;margin-top:5px; margin-bottom:5px;border:1px solid black;"/>
        <asp:Button ID="saveTeamInfo" runat="server" OnClick="saveTeamInfoButton_Click" Text="Save Team Profile" CssClass="btn btn-default editBTN" style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white; padding:2px;margin-top:5px; margin-bottom:5px;border:1px solid black;width:95%;" />--%>
        </div>
        <%--<div class="col-sm-12" style="text-align:left;padding-top:20px;">
            <hr/>
            <footer id="footer">
                <p>&copy; <%: DateTime.Now.Year %> - ManageU</p>
            </footer>
        </div>--%>

    </div>

 

</asp:Content>


<%--Must uncomment in master file also--%>
<%--<asp:Content runat="server" ID="foot" ContentPlaceHolderID="foot">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    
    <%--Footer in TeamProfile.master

</asp:Content>--%>


