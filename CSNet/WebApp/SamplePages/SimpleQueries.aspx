<%@ Page Title="Simple Queries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQueries.aspx.cs" Inherits="WebApp.SamplePages.SimpleQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Queries</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Enter Product ID:"></asp:Label>
                <asp:TextBox ID="SearchArg" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Product ID:"></asp:Label>
                <asp:Label ID="ProductID" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Submit" />
                <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="false" />

            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
                <asp:Label ID="ProductName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="MessageLabel" runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
