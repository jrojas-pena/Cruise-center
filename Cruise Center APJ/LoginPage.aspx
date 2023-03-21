<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Cruise_Center_APJ.LoginPage" %>

<!DOCTYPE html>
<!--Author: Ali Umar-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Styles/common.css" type="text/css" />
    <title>Login</title>
</head>
<body>
    <header>
        <h1>Cruise Center APJ</h1>
        <h3>By Ali Pratham Juan</h3>
    </header>
     <div class="center-login">
        <form id="loginForm" runat="server">
            <div>
                <asp:Label ID="userLabel" runat="server" Text="Username (Traveller ID)"></asp:Label>
                <asp:TextBox cssClass="form-control"  ID="userTextbox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="userValidator" runat="server" ControlToValidate="userTextbox" ErrorMessage="Must enter username" CssClass="errormsg"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="passLabel" runat="server" Text="Password"></asp:Label>
                <asp:TextBox cssClass="form-control" ID="passTextbox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="passValidator" runat="server" ControlToValidate="passTextbox" ErrorMessage="Must enter password" CssClass="errormsg"></asp:RequiredFieldValidator>
                <div>
                    <asp:Label ID="errorLabel" runat="server" Text="Invalid username/password" Visible="False" CssClass="errormsg"></asp:Label>
                </div>
            </div>
            <div>
                <asp:Button cssClass="btn btn-primary" ID="loginButton" runat="server" Text="Logon" OnClick="loginButton_Click" />
            </div>
        </form>
    </div>
</body>
</html>
