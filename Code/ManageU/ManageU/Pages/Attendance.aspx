<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="ManageU.Pages.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

        <div id="atRecord" runat="server" style="padding:0px;text-align:center;">

                        <%--Programatically create divs in code-behind file--%>

                    </div>

    <div class="row" style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <section id="loginForm">
                <div class="form-horizontal">
                    
                </div>
            </section>
    </div>
    
    </div>



</asp:Content>
