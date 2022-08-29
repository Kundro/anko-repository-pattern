﻿<%@ Page Title="New address information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="Customer.Datalayer.WebForm.AddressEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="Customer ID" runat="server"></asp:Label>
            <asp:TextBox ID="customerID" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Address line 1" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine1" maxlength="100" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Address line 2" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine2" maxlength="100" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Address type" runat="server"></asp:Label>
            <asp:TextBox ID="addressType" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="City" runat="server"></asp:Label>
            <asp:TextBox ID="city" maxlength="50" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Postal Code" runat="server"></asp:Label>
            <asp:TextBox ID="postalCode" maxlength="6" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="State" runat="server"></asp:Label>
            <asp:TextBox ID="state" maxlength="20" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label Text="Country" runat="server"></asp:Label>
            <asp:TextBox ID="country" class="form-control center-block" runat="server"></asp:TextBox>
        </div>
        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>

</asp:Content>
