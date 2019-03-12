<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Basic Controls</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align="right">TextBox</td>
            <td>
                <asp:TextBox ID="TextBoxNumberChoice" runat="server"
                     ToolTip="Enter a choice of 1 to 4" ></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="SubmitButtonChoice" runat="server" Text="Submit Choice" OnClick="SubmitButtonChoice_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Choice (RadioButtonList):"
                     Font-Size="Medium" ForeColor="#33cc33" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 20px">
                <asp:Literal ID="Literal1" runat="server"
                    text="Choice (CheckBox):"></asp:Literal>
            </td>
            <td style="height: 20px">
                <asp:CheckBox ID="CheckBoxChoice" runat="server" 
                     Font-Bold="true" Text="Programming Course if active"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="Display Label:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayReadOnly" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="View Collection:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="SubmitList" runat="server" Text="Submit List" OnClick="SubmitList_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="MessageLabel" runat="server" ></asp:Label></td>
            
        </tr>
    </table>
</asp:Content>
