<%@ Page Title="New customer information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Customer.Datalayer.WebForm.CustomerEdit" %>

<asp:Content data-toggle="validator" ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1 class="text-center"><%=Title %></h1>

    <div class="text-center">
        <div class="form-group">
            <asp:Label Text="First name (optional)" runat="server"></asp:Label>
            <asp:TextBox ID="firstName" maxlength="50" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="First name hould be less than 50." ValidationExpression="^.{,50}$"  ControlToValidate="firstName" runat="server" ></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Last name" runat="server"></asp:Label>
            <asp:TextBox ID="lastName" maxlength="50" class="form-control center-block" runat="server" required="required"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Last name is required." ControlToValidate="lastName" runat="server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="Last name should be less than 50." ValidationExpression="^.{,50}$"  ControlToValidate="lastName" runat="server"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Phone number (optional)" runat="server"></asp:Label>
            <asp:TextBox ID="phoneNumber" maxlength="15" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="Invalid phone number" ValidationExpression="^\+?\d{6,7}[2-9]\d{3}$" ControlToValidate="phoneNumber" runat="server"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Email (optional)" runat="server"></asp:Label>
            <asp:TextBox ID="email" type="email" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="Invalid email." ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"  ControlToValidate="email" runat="server"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Notes" runat="server"></asp:Label>
            <asp:TextBox ID="notes"  class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Notes is required." ControlToValidate="notes" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label Text="Total purchases amount" runat="server"></asp:Label>
            <asp:TextBox ID="totalPurchasesAmount" class="form-control center-block" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Total purchases amount is required." ControlToValidate="totalPurchasesAmount" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="text-center">
            <asp:Button class="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>
        </div>
    </div>


</asp:Content>
