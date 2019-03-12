<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestEntry.aspx.cs" Inherits="WebApp.SamplePages.ContestEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Contest Entry</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-style: italic">
                This illustrates some simple controls to fill out an entry form for a contest. 
                This form will use basic bootstrap formatting and illustrate Validation.
            </blockquote>
            <p>
                Please fill out the following form to enter the contest. This contest is only available to residents in Western Canada.
            </p>

        </div>
    </div>

    <%-- Enter all validation controls in one area --%>
    <asp:RequiredFieldValidator ID="RequiredFieldFirstName" runat="server" 
        ErrorMessage="First Name is required." ControlToValidate="FirstName"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldLastName" runat="server" 
        ErrorMessage="Last Name is required." ControlToValidate="LastName"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldStreetAddress1" runat="server" 
        ErrorMessage="Street Address1 is required." ControlToValidate="StreetAddress1"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldCity" runat="server" 
        ErrorMessage="City is required." ControlToValidate="City"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldCheckAnswer" runat="server" 
        ErrorMessage="You did not supply an answer to the skill testing question." ControlToValidate="CheckAnswer"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldPostalCode" runat="server" 
        ErrorMessage="PostalCode is required." ControlToValidate="PostalCode"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldEmailAddress" runat="server" 
        ErrorMessage="Email Address is required." ControlToValidate="EmailAddress"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
    </asp:RequiredFieldValidator>

    <%-- there is no field to demonstrate a Range Validation on this form
        the StreetAddress2 will be used for this demonstration--%>
    <asp:RangeValidator ID="RangeStreetAddress2" runat="server"
        ErrorMessage="Enter 1 to 5 according to liking (1 strongly like, 5 strongly dislike)." ControlToValidate="StreetAddress2" Display="None"
         SetFocusOnError="true" ForeColor="Firebrick" 
        Type="Integer" MaximumValue="5" MinimumValue="1">
    </asp:RangeValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionPostalCode" runat="server" 
        ErrorMessage="Invalid postal code format [AnAnAn]." ControlToValidate="PostalCode"
         SetFocusOnError="true" Display="None" ForeColor="Firebrick"
         ValidationExpression="[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]">
        </asp:RegularExpressionValidator>

       <asp:CompareValidator ID="CompareEmailAddress" runat="server" 
            ErrorMessage="Invalid Email" ControlToValidate="EmailAddress" Display="None"
             SetFocusOnError="true" ForeColor="Firebrick"
            Type="String" Operator="DataTypeCheck" ></asp:CompareValidator>

        <%-- sample of a datatype check using Compare --%>
<%--        <asp:CompareValidator ID="CompareCheckAnswer" runat="server" 
            ErrorMessage="Skill Testing answer is not a number"
            ControlToValidate="CheckAnswer" Display="None"
             SetFocusOnError="true" ForeColor="Firebrick"
            Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>--%>

        <%-- sample of a constant value using Compare --%>
         <asp:CompareValidator ID="CompareCheckAnswer" runat="server" 
            ErrorMessage="Skill Testing answer is not correct"
            ControlToValidate="CheckAnswer" Display="None"
             SetFocusOnError="true" ForeColor="Firebrick"
            Type="Integer" Operator="Equal" ValueToCompare="15"></asp:CompareValidator>

        <%-- sample of 2 field comparing using Compare
            we have no fields to test assume a password field--%>
 <%--       <asp:CompareValidator ID="ComparePassword" runat="server" 
            ErrorMessage="Confirm password not the same."
            ControlToValidate="ConfirmPassword" Display="None"
             SetFocusOnError="true" ForeColor="Firebrick"
           Type="String" Operator="Equal" 
            ControlToCompare="Password"></asp:CompareValidator>--%>
        
    <%-- display all errors in one place using the ValidationSummary Control --%>
    <asp:ValidationSummary ID="ValidationContestEntry" runat="server" 
         HeaderText="Correct the following concerns and resubmit"
         CssClass="alert alert-danger"/>

    <div class="row">
        <div class ="col-md-6">
            <fieldset class="form-horizontal">
                <legend>Application Form</legend>

                <asp:Label ID="Label1" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" 
                    ToolTip="Enter your first name." MaxLength="25"></asp:TextBox> 
                  
                 <asp:Label ID="Label6" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" 
                    ToolTip="Enter your last name." MaxLength="25"></asp:TextBox> 
                        
                <asp:Label ID="Label3" runat="server" Text="Street Address 1"
                     AssociatedControlID="StreetAddress1"></asp:Label>
                <asp:TextBox ID="StreetAddress1" runat="server" 
                    ToolTip="Enter your street address." MaxLength="75"></asp:TextBox> 
                  
                  <asp:Label ID="Label7" runat="server" Text="Street Address 2"
                     AssociatedControlID="StreetAddress2"></asp:Label>
                <asp:TextBox ID="StreetAddress2" runat="server" 
                    ToolTip="Enter your additional street address." MaxLength="75"></asp:TextBox> 
                  <br />
                 <asp:Label ID="Label8" runat="server" Text="City"
                     AssociatedControlID="City"></asp:Label>
                <asp:TextBox ID="City" runat="server" 
                    ToolTip="Enter your City name" MaxLength="50"></asp:TextBox> 
                  
                 <asp:Label ID="Label9" runat="server" Text="Province"
                     AssociatedControlID="Province"></asp:Label>
                <asp:DropDownList ID="Province" runat="server" Width="75px">
                    <asp:ListItem Value="AB" Text="AB"></asp:ListItem>
                     <asp:ListItem Value="BC" Text="BC"></asp:ListItem>
                     <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
                     <asp:ListItem Value="SK" Text="SK"></asp:ListItem>
                </asp:DropDownList>
                  
                 <asp:Label ID="Label10" runat="server" Text="Postal Code"
                     AssociatedControlID="PostalCode"></asp:Label>
                <asp:TextBox ID="PostalCode" runat="server" 
                    ToolTip="Enter your postal code"  MaxLength="6"></asp:TextBox> 
                 
                <asp:Label ID="Label2" runat="server" Text="Email"
                     AssociatedControlID="EmailAddress"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" 
                    ToolTip="Enter your email address"
                     TextMode="Email"></asp:TextBox> 
                  
              </fieldset>   
           <p>Note: You must agree to the contest terms in order to be entered.
               <br />
               <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of the contest" />
           </p>

            <p>
                Enter your answer to the following calculation instructions:<br />
                Multiply 15 times 6<br />
                Add 240<br />
                Divide by 11<br />
                Subtract 15<br />
                <asp:TextBox ID="CheckAnswer" runat="server" ></asp:TextBox>
            </p>
        </div>
        <div class="col-md-6">   
            <div class="col-md-offset-2">
                <p>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;&nbsp;
                    <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="true" OnClick="Clear_Click"  />
                </p>
                <asp:Label ID="Message" runat="server" ></asp:Label>
                <br />
                <hr style="width: 5px;" />
                <asp:GridView ID="ContestEntryList" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
