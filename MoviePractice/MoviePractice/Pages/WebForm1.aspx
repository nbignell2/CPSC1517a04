<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MoviePractice.Pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Movie Library</h1>
    </div>

    <div class="row col-md-12">
            <p>
                Fill out the form below to add information for your movie library
            </p>
    </div>

    <div class="row">
        <div class ="col-md-6">
            <fieldset class="form-horizontal">
                <legend>Library Form</legend>
                 &nbsp &nbsp
                <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                <asp:TextBox ID="Title" runat="server"
                    ToolTip="Enter the title of the movie">
                </asp:TextBox>
              </fieldset>   
        </div>

    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
