<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomersList.aspx.cs" Inherits="Customer.Datalayer.WebForm.CustomersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <tr>
            <th>Customer ID</th>
            <th>First name</th>
            <th>Last name</th>
            <th>Phone number</th>
            <th>Email</th>
            <th>Notes</th>
            <th>Total Purchases Amount</th>
        </tr>
        <%foreach(var customer in Customers) 
            {%>
                
                <tr>
                    <td><%=customer.CustomerID%></td>
                    <td><%=customer.FirstName%></td>
                    <td><%=customer.LastName%></td>
                    <td><%=customer.PhoneNumber%></td>
                    <td><%=customer.Email%></td>
                    <td><%=customer.Notes%></td>
                    <td><%=customer.TotalPurchasesAmount%></td>
                </tr>
            <%} %>
    </table>
</asp:Content>
