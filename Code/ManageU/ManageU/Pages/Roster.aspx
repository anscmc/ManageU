<%@ Page Title="Roster" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Roster.aspx.cs" Inherits="ManageU.Pages.Roster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrap.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr />

    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">

                    <div class="form-group">

                        <%--create programatically--%>
                        <div class="col-sm-6 col-sm-offset-3">

                            <label id="Label1" runat="server"></label>
                            <label id="Label2" runat="server"></label>
                            <label id="Label3" runat="server"></label>
                            <label id="Label4" runat="server"></label>
                            <label id="Label5" runat="server"></label>


                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>


</asp:Content>
