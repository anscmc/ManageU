<%@ Page Title="Invite Players to Your ManageU" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="InvitePlayers.aspx.cs" Inherits="ManageU.Pages.InvitePlayers" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />
<script type="text/javascript">

    function alertSuccess() {
        alert(document.getElementById('<%=hiddenSuccess.ClientID %>').value);
    }

</script>
    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">
                        
                        <div id="emailsDiv" runat="server" class="col-sm-6 col-sm-offset-3">
                            <label id="meetingLasting" runat="server" CssClass="form-control"># of players</label>
                            <select class="selectpicker" id="numOfemails" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;margin-bottom:10px !important;" onchange="numEmails();" >
                                            <option value="0">0</option>
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                            <option value="7">7</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                            </select>
                            <br />
                            <%--<asp:TextBox runat="server" ID="emailAddresses" placeholder="Email Address" CssClass="form-control" style="display: block; margin: 0 auto;width:250px;max-width:250px;"/>--%>
                            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="emailAddresses" CssClass="text-danger" ErrorMessage="Field is required." />--%>
                            <label id="userExistsErr" runat="server" style="color:red; display:none;">You have already invited the following players: </label>
                            <asp:TextBox ID="email1" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email2" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email3" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email4" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email5" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email6" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email7" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email8" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email9" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="email10" runat="server" placeholder="Email Address" CssClass="form-control" style="display: none; margin: 0 auto;width:250px;max-width:250px;"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" Text="Invite" OnClick="inviteButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;width:250px;" ID="inviteButton" />
                            
                            <%--<asp:Button runat="server" Text="Invite" onclick="inviteButton_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;width:250px;" ID="inviteButton" />--%>
                        </div>
                    </div>

                </div>
                <asp:HiddenField id="numPlayersHidden" runat="server"/>
                <asp:HiddenField ID="hiddenSuccess" runat="server" />
            </section>
        </div>
    </div>
    </div>

    <asp:HiddenField ID="hidden" runat="server" />
    <script type="text/javascript">
        function numEmails() {
            document.getElementById('<%=email1.ClientID %>').style.display = "none";
            document.getElementById('<%=email2.ClientID %>').style.display = "none";
            document.getElementById('<%=email3.ClientID %>').style.display = "none";
            document.getElementById('<%=email4.ClientID %>').style.display = "none";
            document.getElementById('<%=email5.ClientID %>').style.display = "none";
            document.getElementById('<%=email6.ClientID %>').style.display = "none";
            document.getElementById('<%=email7.ClientID %>').style.display = "none";
            document.getElementById('<%=email8.ClientID %>').style.display = "none";
            document.getElementById('<%=email9.ClientID %>').style.display = "none";
            document.getElementById('<%=email10.ClientID %>').style.display = "none";

            var selector = document.getElementById("numOfemails");
            var selectedValue = selector.options[selector.selectedIndex].value;

            document.getElementById('<%=numPlayersHidden.ClientID %>').value = selectedValue;

            for (var i = 1; i <= selectedValue; i++){
                switch (i) {
                        case 1:
                            document.getElementById('<%=email1.ClientID %>').style.display = "block";
                            break;
                        case 2:
                            document.getElementById('<%=email2.ClientID %>').style.display = "block";
                            break;
                        case 3:
                            document.getElementById('<%=email3.ClientID %>').style.display = "block";
                            break;
                        case 4:
                            document.getElementById('<%=email4.ClientID %>').style.display = "block";
                            break;
                        case 5:
                            document.getElementById('<%=email5.ClientID %>').style.display = "block";
                            break;
                        case 6:
                            document.getElementById('<%=email6.ClientID %>').style.display = "block";
                            break;
                        case 7:
                            document.getElementById('<%=email7.ClientID %>').style.display = "block";
                            break;
                        case 8:
                            document.getElementById('<%=email8.ClientID %>').style.display = "block";
                            break;
                        case 9:
                            document.getElementById('<%=email9.ClientID %>').style.display = "block";
                            break;
                        case 10:
                            document.getElementById('<%=email10.ClientID %>').style.display = "block";
                            break;
                        default:
                            break;
                }
            }

        }

    </script>

    

</asp:Content>
