<%@ Page Title="Add Lift" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AddLift.aspx.cs" Inherits="ManageU.Pages.AddLift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <div id="liftContainer">
            <label id="liftNameLabel" runat="server">Name of lift</label>
            <asp:TextBox ID="liftName" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
            <asp:Button runat="server" ID="newLiftButton" Text="Add Lift" onClientClick="createDiv(); return false;" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
            <br />
            <div id="newlyAddedLifts" runat="server"></div>
            <%--<div id="lift1" style="display: none;" runat="server">
                <label id="lift1NameLabel" runat="server">Lift Name</label>
                <asp:TextBox ID="lift1Name" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <label id="lift1SetsLabel" runat="server">Sets</label>
                <asp:TextBox ID="lift1Sets" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <label id="lift1RepsLabel" runat="server">Reps</label>
                <asp:TextBox ID="lift1Reps" runat="server" CssClass="form-control" width=250 style="display: block; margin: 0 auto;"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="deleteLift1" Text="Delete" onclick="delete_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
            </div>--%>
            <br />
            
    
        </div>

        <asp:Button runat="server" ID="addLiftButton" Text="Add Workout" onclick="addLiftButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;"/>
        <asp:HiddenField ID="liftIDsHidden" runat="server" />
        <asp:HiddenField ID="liftNamesHidden" runat="server" />
        <asp:HiddenField ID="liftSetsHidden" runat="server" />
        <asp:HiddenField ID="liftRepsHidden" runat="server" />
    </div>

    <script type="text/javascript">
        var count = 0;
        function createDiv() {
            count++;
            var divID = "lift" + count;
            var nameID = "name" + count;
            var setID = "set" + count;
            var repID = "rep" + count;
            var newDiv = document.createElement('div');
            newDiv.setAttribute('id', divID);
            newDiv.setAttribute('runat', 'server');

            var nameTextBox = document.createElement('input');
            nameTextBox.type = 'text';
            nameTextBox.setAttribute('id', nameID);
            nameTextBox.setAttribute('runat', 'server');

            var setTextBox = document.createElement('input');
            setTextBox.type = 'text';
            setTextBox.setAttribute('id', setID);
            setTextBox.setAttribute('runat', 'server');

            var repTextBox = document.createElement('input');
            repTextBox.type = 'text';
            repTextBox.setAttribute('id', repID);
            repTextBox.setAttribute('runat', 'server');

            var deleteButton = document.createElement('span');
            deleteButton.innerHTML = '<button id="delete' + count + '" onclick="deleteDiv(' + count + ')" value="Delete" />';

            newDiv.appendChild(nameTextBox);
            newDiv.appendChild(setTextBox);
            newDiv.appendChild(repTextBox);


            document.getElementById("newlyAddedLifts").appendChild(newDiv);
            document.getElementById('<%=liftIDsHidden.ClientID %>').value = document.getElementById('<%=liftIDsHidden.ClientID %>').value + count + ",";
            document.getElementById('<%=liftNamesHidden.ClientID %>').value = document.getElementById('<%=liftNamesHidden.ClientID %>').value + "name" + count + ",";
            document.getElementById('<%=liftSetsHidden.ClientID %>').value = document.getElementById('<%=liftSetsHidden.ClientID %>').value + "set" + count + ",";
            document.getElementById('<%=liftRepsHidden.ClientID %>').value = document.getElementById('<%=liftRepsHidden.ClientID %>').value + "rep" + count + ",";
        }

        function deleteDiv(row) {
            if (!confirm('Are you sure you want to delete this lift from your workout?')) { return false; }
            else {
                var id = "lift" + row;
                var div = document.getElementById(id);
                if (div) {
                    div.parentNode.removeChild(div);
                    document.getElementById('<%=liftIDsHidden.ClientID %>').value = document.getElementById('<%=liftIDsHidden.ClientID %>').value.replace(id + ",", "");
                    document.getElementById('<%=liftNamesHidden.ClientID %>').value = document.getElementById('<%=liftNamesHidden.ClientID %>').value.replace("name" + row + ",", "");
                    document.getElementById('<%=liftSetsHidden.ClientID %>').value = document.getElementById('<%=liftSetsHidden.ClientID %>').value.replace("set" + row + "," + "");
                    document.getElementById('<%=liftRepsHidden.ClientID %>').value = document.getElementById('<%=liftRepsHidden.ClientID %>').value.replace("rep" + row + ",", "");
                }
            }
        }
    </script>
</asp:Content>
