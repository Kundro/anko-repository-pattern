﻿<%@ Page Title="New customer information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Customer.Datalayer.WebForm.CustomerEdit" %>

<asp:Content data-toggle="validator" ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="First name" runat="server"></asp:Label>
            <asp:TextBox ID="firstName" maxlength="50" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Last name" runat="server"></asp:Label>
            <asp:TextBox ID="lastName" maxlength="50" class="form-control center-block" runat="server" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Phone number" runat="server"></asp:Label>
            <asp:TextBox ID="phoneNumber" maxlength="15" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Email" runat="server"></asp:Label>
            <asp:TextBox ID="email" type="email" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Notes" runat="server"></asp:Label>
            <asp:TextBox ID="notes"  class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Total purchases amount" runat="server"></asp:Label>
            <asp:TextBox ID="totalPurchasesAmount" class="form-control center-block" runat="server"></asp:TextBox>
        </div>

        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>


</asp:Content>