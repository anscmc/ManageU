<%@ Page Title="Roster" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Roster.aspx.cs" Inherits="ManageU.Pages.Roster" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <%--<script type="text/javascript">
        xButtonClick=function(){
               
        }
    </script>--%>
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />


    <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
        <asp:Button runat="server" Text="Email Selected Players" AutoPostBack="false" OnClick="emailClick" CssClass="btn btn-default" 
            style="display: block; margin: 0 auto; text-align: center;" />
        <%--<br />--%>
        <asp:CheckBox id="selectAllBox" Text="Select All Players" runat="server" 
            OnCheckedChanged="selectAll" AutoPostBack="True" />
    </div>
    <div class="row" style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div id="playerInfo" runat="server" class="col-sm-10 col-sm-offset-1" style="padding:0px;">

                        <%--Programatically create divs in code-behind file--%>

                    </div>
                </div>
            </section>
    </div>
        <asp:HiddenField ID="deleteHiddenField" runat="server" />
        <asp:HiddenField ID="calHiddenField" runat="server" />

    <asp:Button runat="server" ID="hiddenDelete" Text="" OnClick="deleteP" CssClass="btn btn-default" 
                style="display: none;" />
        <asp:Button runat="server" ID="hiddenCal" Text="" OnClick="playerSched" CssClass="btn btn-default" 
                style="display: none;" />
    </div>

    <script type="text/javascript">
        function deletePlayer(row) {
            // click hidden button after "Are you sure" message to call C# method

            if (!confirm('Are you sure you want to delete this player?')) { return false; }
            else {
                var btnHidden = $('#<%= hiddenDelete.ClientID %>');

                if (btnHidden != null) {
                    document.getElementById('<%=deleteHiddenField.ClientID %>').value = row;
                    btnHidden.click();
                }
            }
        }

        function playerClasses(row) {
            var btnHidden = $('#<%= hiddenCal.ClientID %>');

            if (btnHidden != null) {
                document.getElementById('<%=calHiddenField.ClientID %>').value = row;
                    btnHidden.click();
                }
        }
        
        

    </script>

</asp:Content>
