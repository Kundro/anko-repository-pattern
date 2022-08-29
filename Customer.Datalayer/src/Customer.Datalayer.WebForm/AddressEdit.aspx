<%@ Page Title="New address information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="Customer.Datalayer.WebForm.AddressEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="Customer ID" runat="server"></asp:Label>
            <asp:DropDownList ID="dropDownCustomerID" class="form-control center-block" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label Text="Address line 1" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine1" maxlength="100" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="addressLine1" Display="Static" ErrorMessage="Address line 1 is required." RunAt="Server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="text-danger center-block" ControlToValidate="addressLine1" ErrorMessage="Address line should be less than 100." RunAt="Server" ValidationExpression="^.{,100}"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Address line 2 (optional)" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine2" maxlength="100" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="text-danger center-block" ControlToValidate="addressLine2" ErrorMessage="Address line should be less than 100." RunAt="Server" ValidationExpression="^.{,100}"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Address type" runat="server"></asp:Label>
            <asp:TextBox ID="addressType" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="addressType" Display="Static" ErrorMessage="Address type is required." RunAt="Server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="City" runat="server"></asp:Label>
            <asp:TextBox ID="city" maxlength="50" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="city" Display="Static" ErrorMessage="City is required." RunAt="Server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="text-danger center-block" ControlToValidate="city" ErrorMessage="City name should be less than 50." RunAt="Server" ValidationExpression="^.{,50}"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Postal Code" runat="server"></asp:Label>
            <asp:TextBox ID="postalCode" maxlength="6" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="postalCode" Display="Static" ErrorMessage="Postal code is required." RunAt="Server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="text-danger center-block" ControlToValidate="postalCode" ErrorMessage="Postal code should be less than 6." RunAt="Server" ValidationExpression="^.{,6}"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="State" runat="server"></asp:Label>
            <asp:TextBox ID="state" maxlength="20" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="state" Display="Static" ErrorMessage="State is required." RunAt="Server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="text-danger center-block" ControlToValidate="state" ErrorMessage="State name should be less than 20." RunAt="Server" ValidationExpression="^.{,20}"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Country" runat="server"></asp:Label>
            <asp:TextBox ID="country" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="country" Display="Static" ErrorMessage="Country is required." RunAt="Server"></asp:RequiredFieldValidator>
        </div>
        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>

</asp:Content>
