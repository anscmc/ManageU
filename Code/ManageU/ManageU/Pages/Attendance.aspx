<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="ManageU.Pages.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>

    <div class="row" style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div id="atRecord" runat="server" class="col-sm-10 col-sm-offset-1" style="padding:0px;">

                        <%--Programatically create divs in code-behind file--%>

                    </div>
                </div>
            </section>
    </div>
    
    </div>

</asp:Content>
