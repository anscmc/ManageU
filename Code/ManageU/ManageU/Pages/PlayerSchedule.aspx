<%@ Page Title="Player Schedule" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="PlayerSchedule.aspx.cs" Inherits="ManageU.Pages.PlayerSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
        <h2><%: Title %></h2>
        <hr/>

        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Add Class" OnClick="newClass" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
             <asp:Button runat="server" Text="x Delete" OnClick="deleteClass" onclientclick="deleteOptions();" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
            <asp:Button runat="server" Text="Edit" OnClick="editClass" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; text-align: center; color:#008CBA; background-color:white;" />
        </div>
        <div>
            <br />
        </div>
        <div id="classDiv" class="col-sm-6 col-sm-offset-3" style="padding:0px" runat="server">

        </div>

    </div>

    <asp:HiddenField ID="deleteHiddenField" runat="server" />

    <script type="text/javascript">
        function deleteClass() {

            if (!confirm('Are you sure you want to delete this class from your schedule?')) { return false; }
        }
        function editClass() {
            if (!confirm('Are you sure you want to edit this class?')) { return false;}
        }

        

    </script>

</asp:Content>
