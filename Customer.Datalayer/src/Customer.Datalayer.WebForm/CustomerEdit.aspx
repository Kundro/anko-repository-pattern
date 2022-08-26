<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Customer.Datalayer.WebForm.CustomerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label Text="First name" runat="server"></asp:Label>
        <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label Text="Last name" runat="server"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label Text="Phone number" runat="server"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label Text="Email" runat="server"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label Text="Notes" runat="server"></asp:Label>
        <asp:TextBox ID="notes" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label Text="Total purchases amount Name" runat="server"></asp:Label>
        <asp:TextBox ID="totalPurchasesAmount" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"/>

</asp:Content>
