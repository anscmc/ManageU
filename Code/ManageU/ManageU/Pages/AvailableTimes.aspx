<%@ Page Title="Available Times" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AvailableTimes.aspx.cs" Inherits="ManageU.Pages.AvailableTimes" %>
<asp:Content ID="AvailableTimesContent" ContentPlaceHolderID="MainContent" runat="server">


 

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
    

        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Create Event"  OnClick="customButtonClick" class="btn btn-default" 
                style="display: block; margin: 0 auto; margin-bottom:10px !important;text-align: center; color:#008CBA; background-color:white;" />
        </div>

        <asp:Button runat="server" ID="btnHidden" OnClick="divButton_Click" style="display:none;" />
        <asp:HiddenField ID="hidden" runat="server" />

        <div id="displayTimesDiv" runat="server" style="text-align:center;width:100%;">
            

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
