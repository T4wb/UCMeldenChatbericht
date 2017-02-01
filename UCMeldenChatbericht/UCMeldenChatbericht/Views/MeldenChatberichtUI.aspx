<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeldenChatberichtUI.aspx.cs" Inherits="UCMeldenChatbericht.Views.MeldenChatberichtUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            <asp:DropDownList ID="ddMessage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddMessage_SelectedIndexChanged" ViewStateMode="Enabled">
            </asp:DropDownList>
            <asp:Label ID="lblUserName" runat="server" Text="Label" BorderStyle="None" ViewStateMode="Enabled"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="tbReason" runat="server" ViewStateMode="Enabled"></asp:TextBox>
        </p>
        <asp:Button ID="btnSubmitReport" runat="server" OnClick="selectSubmitReport" Text="Button" />
    </form>
</body>
</html>
