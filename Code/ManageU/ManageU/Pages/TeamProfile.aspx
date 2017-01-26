<%@ Page Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamProfile.aspx.cs" Inherits="ManageU.Pages.TeamProfile" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/prof/img/swimteam.jpg" />--%>



    <div id="wrapper">
    <div id="a" class="panels">
        <img runat="server" src="~/prof/img/swimteam.jpg" />
    </div>
    <div id="b" class="panels">Scrolling-Panel 1</div>
    <div id="c" class="panels">Scrolling-Panel 2</div>
    <div id="d" class="panels">Scrolling-Panel 3
                    <footer>
                <p>&copy; <%: DateTime.Now.Year %> - ManageU</p>
            </footer>
        </div>
    </div>


</asp:Content>


