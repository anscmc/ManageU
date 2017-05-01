<%@ Page Title="Add a Class" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="ManageU.Pages.AddClass" %>
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

                            <div class="form-group">
                                <label id="classNameLabel" runat="server">Class Name</label>
                                <asp:TextBox ID="className" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;height:39px;"></asp:TextBox>
                                <br />
<%--                            </div>--%>
                            <%--<br />--%>

<%--                            <div class="form-group">--%>
                                <label id="date1" runat="server" CssClass="form-control" style="display:block;">Start Date</label>
                                <input type="date" id="startDate" name="startDate" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;margin-bottom:5px !important;">
                                <label id="date2" runat="server" style="display:block;">End Date</label>
                                <input type="date" id="endDate" name="endDate" runat="server" CssClass="form-control" style="display: inline; margin: 0 auto;text-align: center; width:250px;height:39px;border-radius:5px;">
                            </div>
                            <br />
                            <div class="form-group">
                                <label id="between" runat="server" CssClass="form-control">Start Time</label>
                                <br />
                                <select class="selectpicker" ID="startHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <label  runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                                <select class="selectpicker" ID="startMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                </select>
                                <select class="selectpicker" ID="amPMstart" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                                
                                <br />

                                <label id="and" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">End Time</label>
                                <br />
                                <select class="selectpicker" ID="endHour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <label runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center;">:</label>
                                <select class="selectpicker" ID="endMinute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                </select>
                                <select class="selectpicker" ID="amPMend" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                                <br />
                                <label id="days" runat="server">Days</label>
                                <br />

                                <div id="wrapper" style="text-align: center"> 
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">Sun</label>
                                        <input type="checkbox" name="chk_group[]" id="sun" style="display: table-row;width: 100%;" runat="server" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">M</label>
                                        <input type="checkbox" name="chk_group[]" id="mon" style="display: table-row;width: 100%;" runat="server"/>         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">T</label>
                                        <input type="checkbox" name="chk_group[]" id="tue" style="display: table-row;width: 100%;" runat="server"/>         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">W</label>
                                        <input type="checkbox" name="chk_group[]" id="wed" style="display: table-row;width: 100%;" runat="server"/>         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">TH</label>
                                        <input type="checkbox" name="chk_group[]" id="thu" style="display: table-row;width: 100%;" runat="server"/>         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">F</label>
                                        <input type="checkbox" name="chk_group[]" id="fri" style="display: table-row;width: 100%;" runat="server" />         
                                    </div>
                                    <div style="display:table;float:left;margin-right:20px;">
                                        <label for="male" style="display:table-row">Sat</label>
                                        <input type="checkbox" name="chk_group[]" id="sat" style="display: table-row;width: 100%;" runat="server"/>         
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="addClass" Text="Add to Schedule" OnClick="addClass_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;text-align: center; color:#008CBA; background-color:white; width:250px !important " />
                            <asp:Button runat="server" id="cancel" Text="Cancel" OnClick="cancel_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto;text-align: center; color:#008CBA; background-color:white; width:250px !important " />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    
    </div>

</asp:Content>
