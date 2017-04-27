﻿<%@ Page Title="Edit Task" Language="C#" MasterPageFile="~/Masters/TeamProfile.Master" AutoEventWireup="true" CodeBehind="EditTask.aspx.cs" Inherits="ManageU.Pages.EditTask" %>
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

                            <label id="taskNameLabel" runat="server">Task Name</label>
                            <asp:TextBox ID="taskName" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center;width:250px;height:39px;"></asp:TextBox>
                            <label id="taskDueDate" runat="server">Date Due</label>
                            <input type="date" name="dueDate" id="dueDate2" runat="server" CssClass="form-control" style="display: block; margin: 0 auto;text-align: center; width:250px;height:39px; color:black !important;">
                            <label id="taskTimeDue" runat="server">Time Due</label>
                            <br />
                            <%--onchange="if(parseInt(this.value,10)<10)this.value='0'+this.value;"--%>
                            <select class="selectpicker" ID="hour" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <select class="selectpicker" ID="minute" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
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
                                <select class="selectpicker" ID="amPM" runat="server" CssClass="form-control" style="display:inline; margin: 0 auto;text-align: center; color:black;width:50px;height:39px;border-radius:5px;">
                                        <option value="AM">AM</option>
                                        <option value="PM">PM</option>
                                </select>
                            <br />
                            <label id="taskDesLabel" runat="server">Task Description</label>
                            <asp:TextBox ID="taskDes" runat="server" CssClass="form-control" TextMode="MultiLine" style="display: block; margin: 0 auto;width:250px; height:100px; max-width:250px;"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button runat="server" id="saveTaskButton" Text="Save" OnClick="saveTask_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;" />
                            <asp:Button runat="server" id="cancel" Text="Cancel" OnClick="cancel_Click" CssClass="btn btn-default" style="display: block; margin: 0 auto; margin-bottom:10px;text-align: center;border: 2px solid white;width:250px;" />
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </div>
    </div>

</asp:Content>
