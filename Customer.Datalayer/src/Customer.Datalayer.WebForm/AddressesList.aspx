<%@ Page Title="Addresses List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="Customer.Datalayer.WebForm.AddressesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center"><%=Title %></h1>

    <table ID="addressesTable" class="table text-center">
        <thead>
            <tr>
                <th class="text-center">Address ID</th>
                <th class="text-center">Customer ID</th>
                <th class="text-center">Address Line</th>
                <th class="text-center">Address Line 2</th>
                <th class="text-center">Address Type</th>
                <th class="text-center">City</th>
                <th class="text-center">Postal Code</th>
                <th class="text-center">State</th>
                <th class="text-center">Country</th>
                <th class="text-center"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></th>
                <th class="text-center"><asp:Button class="btn btn-danger" Text="Delete All" runat="server"/></th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var address in Addresses)
                {%>
                    <tr>
                        <td><%=address.AddressID %></td>
                        <td><%=address.CustomerID %></td>
                        <td><%=address.AddressLine %></td>
                        <td><%=address.AddressLine2 %></td>
                        <td><%=address.AddressType %></td>
                        <td><%=address.City %></td>
                        <td><%=address.PostalCode %></td>
                        <td><%=address.StateName %></td>
                        <td><%=address.Country %></td>
                        <td><a class="btn btn-default" href="AddressEdit.aspx?addressID=<%=address.AddressID %>">Edit</a></td>
                        <td><asp:Button class="btn btn-danger" Text="Delete" runat="server"/></td>
                    </tr>
            <%} %>
        </tbody>
    </table>
     <div class="text-center">
        <a runat="server" class="btn btn-success" href="AddressEdit.aspx">Add new address</a>
    </div>

</asp:Content>
