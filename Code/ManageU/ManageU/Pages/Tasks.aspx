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
            <asp:Button id="createButtton" runat="server" Text="+ Create Task" OnClick="createTask" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
        </div>
        <div>
            <br />
        </div>
        <div id="tasksDiv" class="col-sm-6 col-sm-offset-3" style="padding:0px" runat="server">

        </div>
    
        <asp:HiddenField ID="deleteHiddenField" runat="server" />
        <asp:HiddenField ID="editHiddenField" runat="server" />
        <asp:HiddenField ID="detailsHiddenField" runat="server" />
        <asp:HiddenField ID="completeHiddenField" runat="server" />

        <asp:Button runat="server" ID="hiddenDelete" Text="" OnClick="deleteT" CssClass="btn btn-default" style="display:none;" />
        <asp:Button runat="server" ID="hiddenEdit" Text="" OnClick="editT" CssClass="btn btn-default" style="display:none;" />
        <asp:Button runat="server" ID="hiddenDetails" Text="" OnClick="detailsT" CssClass="btn btn-default" 
                style="display: none;" />
        <asp:Button runat="server" ID="hiddenComplete" Text="" OnClick="completeT" CssClass="btn btn-default" 
                style="display: none;" />

    </div>

    <script type="text/javascript">
        function deleteTask(row) {

            if (!confirm('Are you sure you want to delete this task?')) { return false; }
            else {
                var btnHidden = $('#<%= hiddenDelete.ClientID %>');

                if (btnHidden != null) {
                    document.getElementById('<%=deleteHiddenField.ClientID %>').value = row;
                    btnHidden.click();
                }
            }
        }
        function editTask(row) {
            var btnHidden = $('#<%= hiddenEdit.ClientID %>');

            if (btnHidden != null) {
                document.getElementById('<%=editHiddenField.ClientID %>').value = row;
                    btnHidden.click();
                }
        }

        function taskDetails(row) {
            var btnHidden = $('#<%= hiddenDetails.ClientID %>');

            if (btnHidden != null) {
                document.getElementById('<%=detailsHiddenField.ClientID %>').value = row;
                    btnHidden.click();
                }
        }

        function completeTask(row) {
            var btnHidden = $('#<%= hiddenComplete.ClientID %>');

            if (btnHidden != null) {
                document.getElementById('<%=completeHiddenField.ClientID %>').value = row;
                btnHidden.click();
            }
        }

        

    </script>

</asp:Content>
