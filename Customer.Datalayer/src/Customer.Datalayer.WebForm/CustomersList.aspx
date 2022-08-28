<%@ Page Title="Customers List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomersList.aspx.cs" Inherits="Customer.Datalayer.WebForm.CustomersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%=Title %></h1>
    <table class="table text-center">
        <thead>
            <tr>
                <th class="text-center">Customer ID</th>
                <th class="text-center">First name</th>
                <th class="text-center">Last name</th>
                <th class="text-center">Phone number</th>
                <th class="text-center">Email</th>
                <th class="text-center">Notes</th>
                <th class="text-center">Total Purchases Amount</th>
                <th class="text-center"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></th>
                <th class="text-center"><a class="btn btn-danger" href="CustomerDeleteAll.aspx">Delete All</a></th>
            </tr>
        </thead>
        <tbody>
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
                        <td><a class="btn btn-default" href="CustomerEdit.aspx?customerID=<%=customer.CustomerID %>">Edit</a></td>
                        <td><a class="btn btn-danger" href="CustomerDelete.aspx?customerID=<%=customer.CustomerID %>">Delete</a></td>
                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-success" href="~/CustomerEdit">Add new customer</a>
    </div>


     
</asp:Content>
