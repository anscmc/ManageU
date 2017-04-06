<%@ Page Title="Team Calendar" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="TeamCalendar.aspx.cs" Inherits="ManageU.Pages.TeamCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTC.css" type="text/css" />
    
    <div style="margin: 0 auto; text-align: center;">
        <h2 ><%: Title %></h2>
        <hr />

        <asp:Button ID="nextMonthButton" runat="server" style="display:none;" OnClick="nextMonth" />
        <asp:Button ID="lastMonthButton" runat="server" style="display:none;" OnClick="lastMonth" />

        <div style="margin: 0 auto; text-align:center; align-content:center; align-items:center">
            <asp:Button runat="server" Text="+ Create Event" CssClass="btn btn-default" 
                style="display: block; margin: 0 auto; margin-bottom:10px !important;text-align: center; color:#008CBA; background-color:white;" />
        </div>

        <label id="monthLabel" runat="server"></label>
        <div class="calWrap" style="max-width:450px !important;">
            <div class="container"  style="max-width:450px !important;">
                <div class="calRow">
                    <div class="topCalRow">
                        <div class="content">
                            <i class="fa fa-long-arrow-left" aria-hidden="true" onclick="lastMonth();"></i>
                            <br />
                            <label style="bottom:0px !important; margin-bottom:0px !important;">sun</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label>mon</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label>tues</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label>wed</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label>thur</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <label>fri</label>
                        </div>
                    </div>
                    <div class="topCalRow">
                        <div class="content">
                            <i class="fa fa-long-arrow-right" onclick="nextMonth();" aria-hidden="true"></i>
                            <br />
                            <label>sat</label>
                        </div>
                    </div>
                </div>
                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>
            
                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>

                <div class="calRow">
                    <div class="square">
                        <div class="content">
                            
                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                    <div class="square">
                        <div class="content">

                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function lastMonth()
        { 
            var lastMonthButton = $('#<%= lastMonthButton.ClientID %>');

                lastMonthButton.click();
        }

        function nextMonth()
        { 
            var nextMonthButton = $('#<%= nextMonthButton.ClientID %>');

                nextMonthButton.click();
            
        }

    </script>


</asp:Content>
