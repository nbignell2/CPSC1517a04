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
                    <asp:GridView ID="CategoryProductList" runat="server" AllowPaging="True" PageSize="5" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Start" PagerSettings-LastPageText="End" PagerSettings-PageButtonCount="5" GridLines="Horizontal" AlternatingRowStyle-BackColor="#CCCCCC" AutoGenerateColumns="False" OnPageIndexChanging="CategoryProductList_PageIndexChanging" OnSelectedIndexChanged="CategoryProductList_SelectedIndexChanged" BorderStyle="None">
                      <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                        <Columns>
                            <asp:CommandField CausesValidation="False" SelectText="View" ShowSelectButton="True" >
                            <HeaderStyle BackColor="#999999" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" 
                                        Text='<%# string.Format("{0:0.00}",Eval("UnitPrice")) %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#999999" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QoH">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("UnitsInStock") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#999999" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Disc.">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Discontinued" runat="server"
                                        checked='<%# Eval("Discontinued") %>' Enabled="false"/>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#999999" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                 <ItemTemplate>
                                     <asp:Label ID="ProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="5"></PagerSettings>
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
