<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AvailableTimes.aspx.cs" Inherits="ManageU.Pages.AvailableTimes" %>
<asp:Content ID="AvailableTimesContent" ContentPlaceHolderID="MainContent" runat="server">


 

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
    
        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Create Event"  OnClick="customButtonClick" class="btn btn-default" 
                style="display: block; margin: 0 auto; margin-bottom:10px !important;text-align: center; color:#008CBA; background-color:white;" />
        </div>

        <asp:Button runat="server" ID="btnHidden" OnClick="divButton_Click" style="display:none;" />
        <asp:HiddenField ID="hidden" runat="server" />

        <div id="displayTimesDiv" runat="server">
            <asp:Label runat="server" ID="myLabel">This is a test</asp:Label>

        </div>
    
    </div>

    <script type="text/javascript">
        function divClick(row)
        { 
            var btnHidden = $('#<%= btnHidden.ClientID %>');

            if(btnHidden != null)
            {
                document.getElementById('<%=hidden.ClientID %>').value = row;
                btnHidden.click();
            }
        }

    </script>


</asp:Content>
