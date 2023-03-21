<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationsPage.aspx.cs" Inherits="Cruise_Center_APJ.reservations" %>

<!DOCTYPE html>
<!--Author: Juan Rojas-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="~/Styles/common.css" rel="Stylesheet" type="text/css" />
    <title>Reservations</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <div class="center-reservation">
    
        <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="gvReservations" runat="server" OnRowCancelingEdit="gvReservations_RowCancelingEdit" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="resId" HeaderStyle-CssClass="hidden-field" ItemStyle-CssClass="hidden-field"/>
                <asp:ButtonField ButtonType="Button" Text="Cancel" CommandName="CANCEL" />
                <asp:BoundField DataField="shipName" HeaderText="Ship Name" />
                <asp:BoundField DataField="cabNo" HeaderText="Cabin Number" />
                <asp:BoundField DataField="destinations" HeaderText="Destinations" />
            </Columns>
        </asp:GridView>
    
        <asp:Label ID="lblNoReservations" runat="server" Text="There are currently no reservations." Visible="False" CssClass="errormsg"></asp:Label>
            <br />
        <asp:Button ID="btnReserve" runat="server" Text="Reserve" OnClick="btnReserve_Click" />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    
        </div>
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
