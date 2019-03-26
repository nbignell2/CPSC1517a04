<%@ Page Title="Sql Proc" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SqlProcQueries.aspx.cs" Inherits="WebApp.SamplePages.SqlProcQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Sql Procedure queries</h1>
        <table align="center" style="width: 80%">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="Select a Product category"></asp:Label>
&nbsp;
                    <asp:DropDownList ID="CategoryList" runat="server"></asp:DropDownList>
               </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"   />
&nbsp;
                    <asp:Button ID="Clear" runat="server" Text="Clear"
                        CausesValidation="false" OnClick="Clear_Click" />
                </td>

            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="CategoryProductList" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BorderColor="Black" BorderStyle="Groove" CellPadding="5" CellSpacing="5" GridLines="None" OnPageIndexChanging="CategoryProductList_PageIndexChanging" PageSize="3" OnSelectedIndexChanged="CategoryProductList_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#CCCCCC" BorderColor="#66FFFF" BorderStyle="None" />
                        <Columns>
                              <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="ProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Double" Font-Names="Microsoft New Tai Lue" HorizontalAlign="Center"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price ($)">
                                <ItemTemplate>
                                    <asp:Label ID="UnitPrice" runat="server" Text='<%# string.Format("{0:0.00}",Eval("UnitPrice")) %>'></asp:Label> <%-- Can format date --%>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Double" Font-Names="Microsoft New Tai Lue" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QoH">
                                <ItemTemplate>
                                    <asp:Label ID="UnitsInStock" runat="server" Text='<%# Eval("UnitsInStock") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Double" Font-Names="Microsoft New Tai Lue"  HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Disc">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Discontinued" runat="server" Checked='<%# Eval("Discontinued") %>'></asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Double" Font-Names="Microsoft New Tai Lue" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                              <asp:CommandField CausesValidation="False" SelectText="View" ShowSelectButton="True">
                              <HeaderStyle BackColor="#CCFFFF" Font-Underline="True" />
                              </asp:CommandField>
                        </Columns>
                        <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
                    </asp:GridView>
                </td>

            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
                </td>

            </tr>
        </table>


</asp:Content>
