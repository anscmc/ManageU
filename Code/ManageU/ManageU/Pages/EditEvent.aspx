<%@ Page Title="Edit Event" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="ManageU.Pages.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/Scripts/bootstrapTP.css" type="text/css" />

    <div style="margin: 0 auto; text-align: center;">
    <h2><%: Title %></h2>
    <hr/>
        <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <section id="loginForm">
                <div class="form-horizontal">


                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">



                            <label id="eventNameLabel" runat="server">Event Name</label>
                            <asp:TextBox ID="eventName" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;color:black;"></asp:TextBox>
                            <br />
                            <label id="Label5" runat="server">Event Type</label>
                            <br />
                            <select class="selectpicker" ID="eventType" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:250px;border-radius:5px;">
                                    <option value="Game">Game</option>
                                    <option value="Practice">Practice</option>
                                    <option value="Meeting">Meeting</option>
                                    <option value="Other">Other</option>
                            </select>
                            <br />
                            <label id="eventStartDateLabel" runat="server">Start Date</label>

                            <input type="date" name="eventStartDate" id="eventStartDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">

                            <label id="eventEndDateLabel" runat="server">End Date</label>
                            <br />
                            <input type="date" name="eventEndDate" id="eventEndDate" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">

                            <label id="eventStartTimeLabel" runat="server"> Start Time</label>
                            <br />
                            <select ID="eventStartHour" class="selectpicker" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                </select>
                            <label id="Label1" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
<select class="selectpicker" ID="eventStartMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="01">01</option>
                                        <option value="02">02</option>
                                        <option value="03">03</option>
                                        <option value="04">04</option>
                                        <option value="05">05</option>
                                        <option value="06">06</option>
                                        <option value="07">07</option>
                                        <option value="08">08</option>
                                        <option value="09">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                        <option value="31">31</option>
                                        <option value="32">32</option>
                                        <option value="33">33</option>
                                        <option value="34">34</option>
                                        <option value="35">35</option>
                                        <option value="36">36</option>
                                        <option value="37">37</option>
                                        <option value="38">38</option>
                                        <option value="39">39</option>
                                        <option value="40">40</option>
                                        <option value="41">41</option>
                                        <option value="42">42</option>
                                        <option value="43">43</option>
                                        <option value="44">44</option>
                                        <option value="45">45</option>
                                        <option value="46">46</option>
                                        <option value="47">47</option>
                                        <option value="48">48</option>
                                        <option value="49">49</option>
                                        <option value="50">50</option>
                                        <option value="51">51</option>
                                        <option value="52">52</option>
                                        <option value="53">53</option>
                                        <option value="54">54</option>
                                        <option value="55">55</option>
                                        <option value="56">56</option>
                                        <option value="57">57</option>
                                        <option value="58">58</option>
                                        <option value="59">59</option>
                                </select>                            <select class="selectpicker" ID="beginAmPM" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                            <br />
                            <label id="Label3" runat="server"> End Time</label>
                            <br />
<select ID="eventEndHour" class="selectpicker" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                </select>                            <label id="Label4" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
<select class="selectpicker" ID="eventEndMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="00">00</option>
                                        <option value="01">01</option>
                                        <option value="02">02</option>
                                        <option value="03">03</option>
                                        <option value="04">04</option>
                                        <option value="05">05</option>
                                        <option value="06">06</option>
                                        <option value="07">07</option>
                                        <option value="08">08</option>
                                        <option value="09">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                        <option value="31">31</option>
                                        <option value="32">32</option>
                                        <option value="33">33</option>
                                        <option value="34">34</option>
                                        <option value="35">35</option>
                                        <option value="36">36</option>
                                        <option value="37">37</option>
                                        <option value="38">38</option>
                                        <option value="39">39</option>
                                        <option value="40">40</option>
                                        <option value="41">41</option>
                                        <option value="42">42</option>
                                        <option value="43">43</option>
                                        <option value="44">44</option>
                                        <option value="45">45</option>
                                        <option value="46">46</option>
                                        <option value="47">47</option>
                                        <option value="48">48</option>
                                        <option value="49">49</option>
                                        <option value="50">50</option>
                                        <option value="51">51</option>
                                        <option value="52">52</option>
                                        <option value="53">53</option>
                                        <option value="54">54</option>
                                        <option value="55">55</option>
                                        <option value="56">56</option>
                                        <option value="57">57</option>
                                        <option value="58">58</option>
                                        <option value="59">59</option>
                                </select>                            <select class="selectpicker" ID="endingAmPm" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:50px;border-radius:5px;">
                                    <option value="AM">AM</option>
                                    <option value="PM">PM</option>
                            </select>
                            <br />

                            <label id="Label6" runat="server">Reoccurring</label>
                            <br />
                            <select class="selectpicker" ID="repeatPicker" runat="server" onchange="showRepeat()" CssClass="form-control" style="width:250px;display:inline; margin: 0 auto;text-align: center;height:39px; color:black;width:250px;border-radius:5px;">
                                    <option value="Never">Never</option>
                                    <option value="Daily">Daily</option>
                                    <option value="Weekly">Weekly</option>
                            </select>
                            <br />
                            <label id="Label2" style="display:none;">Until</label>
                            <input type="date" name="repeatUntilDate" id="repeatUntilDate" runat="server" CssClass="form-control" style="display: none; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">
                                   
                             <br />
                            <label id="Label7" runat="server">Description</label>
                            <br />
                                <asp:TextBox runat="server" ID="eventDes" TextMode="multiline" placeholder="Enter Description" CssClass="form-control" style="display: block; margin: 0 auto;"/>
                            <br />
                            <label for="male" style="display:inline;text-align:center;">Attendance Required</label>
                            <input type="checkbox" name="chk_group[]" id="required" style="display: inline;" runat="server" />  
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button ID="editEventButton" Text="Save" OnClick="editEventButton_Click" CssClass="btn btn-default" style="width:250px; max-height:200px; display:block; margin:0 auto; margin-top:10px; margin-bottom:10px; text-align:center; color:#008CBA; background-color:white; padding-left:25px; padding-right:25px;" runat="server"/>
                            <asp:Button ID="cancel" Text="Cancel" OnClick="cancel_Click" CssClass="btn btn-default" style="width:250px; max-height:200px; display:block; margin:0 auto; margin-top:10px; margin-bottom:10px; text-align:center; color:#008CBA; background-color:white; padding-left:25px; padding-right:25px;" runat="server"/>
                            <%--<label id="errLabel" style="color: Red; display: none;" runat="server">Unable to updated password. Please make sure you enter your correct email and password.</label>--%>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
        </div>

    <%--</div>--%>

    <script>
        $('.datepicker').datepicker();
        function showRepeat() {
            if (document.getElementById('<%=repeatPicker.ClientID %>').value == "Never") {
                document.getElementById("Label2").style.display = "none";
                document.getElementById('<%=repeatUntilDate.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById("Label2").style.display = "block";
                document.getElementById('<%=repeatUntilDate.ClientID %>').style.display = "block";
            }
        }
    </script>

</asp:Content>
